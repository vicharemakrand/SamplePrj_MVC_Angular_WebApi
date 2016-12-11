using StructureMap.Attributes;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Linq;
using Sample.ViewModels;
using Sample.IDomainServices;
using Sample.Utility;
using Sample.IDomainServices.Queues;
using Sample.InfraStructure.Logging;

namespace Sample.DomainServices.Mails
{
    public class RootMail
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string FromEmail { get; set; }

        [SetterProperty]
        public IEmailQueueService emailQueueService { get; set; }

        public virtual string RenderHtml()
        {
            string html = LoadHtmlFromFile(AppProperties.BasePhysicalPath + AppConstants.EmailTemplates + "Root.htm");

            if (String.IsNullOrEmpty(Subject))
                html = html.Replace("{{SUBJECT}}", "Email from National Criminal DB");
            else
                html = html.Replace("{{SUBJECT}}", Subject);

            html = html.Replace("{{CONTENT}}", Content);

            return html;
        }

        public EmailQueueViewModel CreateEmailQueueViewModel(string toEmailIds, string attachedFiles = "")
        {
            var viewModel = new EmailQueueViewModel();

            viewModel.fromEmailId = string.IsNullOrEmpty(FromEmail) ? AppProperties.SmtpMailSettings.From : FromEmail;
            viewModel.ToEmailId = toEmailIds;
            viewModel.EmailSubject = Subject;
            viewModel.MessageBody  = RenderHtml();
            viewModel.AttachedFiles = attachedFiles;
            viewModel.UpdatedBy = AppConstants.SysUserId;
            viewModel.UpdatedOn = DateTime.Now;
            viewModel.IsActive = true;

            return viewModel;
        }

        private MailMessage PopulateMailObject(EmailQueueViewModel viewModel,SmtpSection smtpSection)
        {
            MailMessage eMailMessage = new MailMessage();
            eMailMessage.From = new MailAddress(smtpSection.Network.UserName);
            eMailMessage.ReplyToList.Add(smtpSection.Network.UserName);
            eMailMessage.To.Add(viewModel.ToEmailId);
            eMailMessage.Subject = viewModel.EmailSubject;
            eMailMessage.IsBodyHtml = true;
            eMailMessage.Body = viewModel.MessageBody;
            eMailMessage.Priority = MailPriority.High;

            if (!String.IsNullOrEmpty(viewModel.AttachedFiles))
            {
                var files = viewModel.AttachedFiles.Split(',').ToList();

                foreach (string fileName in files)
                {
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        var fileFullPath = AppProperties.BasePhysicalPath + AppConstants.GenerateFileAt + fileName;
                        if (File.Exists(fileFullPath))
                        {
                            var attachmentItem = new Attachment(fileFullPath);
                            eMailMessage.Attachments.Add(attachmentItem);
                        }
                    }
                }
            }

            return eMailMessage;
        }

        private SmtpClient GetSmtpClient(SmtpSection smtpSection)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
            smtpClient.EnableSsl = smtpSection.Network.EnableSsl;
            smtpClient.DeliveryMethod = smtpSection.DeliveryMethod;
            smtpClient.Port = smtpSection.Network.Port;
            smtpClient.Host = smtpSection.Network.Host;
            smtpClient.Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);

            return smtpClient;
        }

        private bool SendEmail(EmailQueueViewModel viewModel)
        {
            try
            {
                using (var emailMessage = PopulateMailObject(viewModel,AppProperties.SmtpMailSettings))
                {
                    var smtpClient = GetSmtpClient(AppProperties.SmtpMailSettings);
                    smtpClient.Send(emailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex);
                return false;
            }
        }

        public void SendEmailAsync(EmailQueueViewModel viewModel, SmtpSection smtpSection)
        {
            try
            {
                var emailMessage = PopulateMailObject(viewModel, smtpSection);

                var smtpClient = GetSmtpClient(smtpSection);

                object userState = viewModel;
                smtpClient.SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);
                smtpClient.SendAsync(emailMessage, userState);

            }
            catch (Exception ex)
            {
                    viewModel.ErrorMessage = ex.Message;
                    viewModel.UpdatedOn = DateTime.Now;
                    if (emailQueueService != null)
                    {
                        emailQueueService.Save(viewModel);
                    }
            }
        }

        public void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            EmailQueueViewModel viewModel = (EmailQueueViewModel)e.UserState;

            if (e.Cancelled)
            {
                viewModel.ErrorMessage = AppMessages.SEND_EMAIL_CANCEL;
            }
            if (e.Error != null)
            {
                viewModel.ErrorMessage = e.Error.ToString();
            }
            else
            {
                viewModel.ErrorMessage = AppMessages.SEND_EMAIL_SUCCEED;
                viewModel.UpdatedOn = DateTime.Now; 
                viewModel.IsActive = false; 
            }

            if (emailQueueService != null)
            {
                emailQueueService.Save(viewModel);
            }
        }

        protected static string LoadHtmlFromFile(string filename)
        {
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex);
                return null;
            }

        }
    }

}