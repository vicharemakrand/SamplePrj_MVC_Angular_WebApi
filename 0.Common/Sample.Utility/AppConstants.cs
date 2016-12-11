namespace Sample.Utility
{
    public class AppConstants
    {
        public const long SysUserId = 1;
        public const string SysAdminEmail = "admin@criminalsearch.com";
        public const string DefaultPassword = "Password";
        public const string EmailTemplates = @"\MailTemplates\Html\";

        public const string Session_UserID = "Session_UserID";
        public const string Session_LoggedInEmail = "Session_LoggedInEmail";
        public const string Session_IsAuthenticated = "Session_IsAuthenticated";
        public const string GenerateFileAt = @"\GeneratedPDFs\";
        public const string PdfConvertorPath = @"\PdfCreator\wkhtmltopdf.exe";

        public const string SmtpMailSettings = "SmtpMailSettings";
        public const string BasePhysicalPath = "BasePhysicalPath";

        public const string CriminalProfileTemplate_xslt = @"\XsltTemplates\CriminalProfileTemplate.xslt";

        public const int MaxProfileAllowePerEmail = 10;

        public const string XsrfHeader = "XSRF-TOKEN";
        public const string XsrfCookie = "xsrf-token"; 


    }
}
