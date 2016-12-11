namespace Sample.Utility
{
    public class AppMessages
    {
        public const string RETRIEVED_DETAILS_SUCCESSFULLY = "Retrieved the details successfully.";
        public const string SAVED_DETAILS_SUCCESSFULLY = "Saved the details successfully.";
        public const string DELETED_DETAILS_SUCCESSFULLY = "Deleted the details successfully.";

        public const string ACTION_FAILED = "Unknown error occured.";
        public const string INPUT_MINCHARSALLOWED = "Minimum 5 characters required.";
        public const string INPUT_MAXCHARSALLOWED = "Maximum {1} characters required.";

        public const string ACTIONMESSAGE_SUCCEED = "The record is retrieved successfully.";
        public const string ACTIONMESSAGE_FAILED = "The action is failed.";

        public const string USER_AUTHENTICATIONFAILED = "User authentication failed!.Check you login credentials.";

        public const string EMAIL_FAILED_MESSAGE = "Failed to send your email.please check email id(s).";
        public const string EMAIL_SUCCEED_MESSAGE = "Your email sent successfully.";

        public const string SEND_EMAIL_CANCEL = "Send canceled.";

        public const string SEND_EMAIL_FAILED = "Sending email failed.";
        public const string SEND_EMAIL_SUCCEED = "Sent your email successfully.";

        public const string EMAIL_REGISTRATION_SUBJECT = "National Criminal DB : Registration email.";
        public const string EMAIL_PDFRESULT_SUBJECT = "National Criminal DB : Search results  for your request for criminal details.";

        public const string CRIMINAL_SEARCH_REQUEST_FAILED = "Your request failed. please try again.";

        public const string CRIMINAL_SEARCH_REQUEST_SUCCEED = "Your request is in the process. on completion of the request , the results(criminal profiles in pdf format) will be sent at your registered email id";

        public const string PDF_QUEUE_PROCESSING_FAILED = "Pdf processing in queue failed.";

        public const string PDF_QUEUE_PROCESSING_SUCCEED = "Pdf processing in queue succeed. now go for email queue processing";

        public const string REQUEST_QUEUE_PROCESSING_FAILED = "Request in queue failed.";

        public const string REQUEST_QUEUE_PROCESSING_SUCCEED = "Request in queue succeed. now go for email queue processing";

        public const string EMAIL_QUEUE_PROCESSING_FAILED = "Email in queue failed.";

        public const string EMAIL_QUEUE_PROCESSING_SUCCEED = "Email in queue succeed. Users should receive the email with attached pdf files.";

        public const string CRIMINAL_SEARCH_REQUEST_SELECTION_REQUIRED = "You must select at lease one search criteria to process your request.";


        public const string SIGNUP_SUCCESS_REDIRECT_TIMEOUT_MESSAGE = "Your registration is done successfully. you will be redirect to login in a minute.";

    }
}
