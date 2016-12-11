using Sample.Utility;

namespace Sample.DomainServices.Mails
{

    public class UserRegistrationMail : RootMail
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public UserRegistrationMail(string email, string userPassword)
        {
            this.Subject = AppMessages.EMAIL_REGISTRATION_SUBJECT;
            this.Email = email;
            this.UserPassword = userPassword;
        }

        public override string RenderHtml()
        {
            Content = LoadHtmlFromFile(AppProperties.BasePhysicalPath + AppConstants.EmailTemplates + "UserRegistrationMail.htm");
            Content = Content.Replace("{{UserName}}", UserName);
            Content = Content.Replace("{{Email}}", Email);
            Content = Content.Replace("{{UserPassword}}", UserPassword);

            return base.RenderHtml();
        }
    }

}
