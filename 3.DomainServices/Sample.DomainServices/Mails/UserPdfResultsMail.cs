using Sample.Utility;
using Sample.ViewModels.Identity.WebApi;


namespace Sample.DomainServices.Mails
{

    public class UserPdfResultsMail : RootMail
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public UserPdfResultsMail(IdentityUserViewModel user)
        {
            this.Subject = AppMessages.EMAIL_PDFRESULT_SUBJECT;
            this.Email = user.Email;
            this.UserName = user.UserName;
        }

        public override string RenderHtml()
        {
            Content = LoadHtmlFromFile(AppProperties.BasePhysicalPath + AppConstants.EmailTemplates + "UserPdfResultsMail.htm");
            Content = Content.Replace("{{UserName}}", UserName);
            Content = Content.Replace("{{Email}}", Email);

            return base.RenderHtml();
        }
    }

}
