using System.Web;
using System.Web.Optimization;

namespace Sample.MVC.Angular.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/Scripts/angular.js",
            "~/Scripts/angular-cookies.js",
            "~/Scripts/angular-route.js",
            "~/Scripts/angular-local-storage.js",
            "~/Scripts/loading-bar.js",
            "~/Scripts/angular-messages.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css",
            "~/Content/loading-bar.css"
            ));
      
            #region "common spa Section"

            bundles.Add(new ScriptBundle("~/bundles/common-modules").Include(
                "~/MiniSpas/ModuleInitiator.js",
                "~/MiniSpas/Common/AppConstants.js",
                "~/MiniSpas/Common/IBaseVM.js",
                "~/MiniSpas/Common/IDictionary.js",
                "~/MiniSpas/Common/IMessageVM.js",
                "~/MiniSpas/Common/BaseController.js",
                "~/MiniSpas/Common/AuthenticationInterceptor.js"
            ));
            #endregion

            #region "Home spa Section"

            bundles.Add(new ScriptBundle("~/bundles/home-modules").Include(
                "~/MiniSpas/HomeSpa/HomeSpaRoutes.js",
                "~/MiniSpas/HomeSpa/HomeSpaApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-services").Include(
                "~/MiniSpas/HomeSpa/Services/AuthService.js",
                "~/MiniSpas/HomeSpa/Services/AuthInterceptorService.js",
                "~/MiniSpas/HomeSpa/Services/TokensManagerService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-directives").Include(
                "~/MiniSpas/Common/Directives/AntiForgeryTokenDirective.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-controllers").Include(
                "~/MiniSpas/HomeSpa/Controllers/HomeController.js",
                "~/MiniSpas/HomeSpa/Controllers/LoginController.js",
                "~/MiniSpas/HomeSpa/Controllers/AssociateController.js",
                "~/MiniSpas/HomeSpa/Controllers/RefreshController.js",
                "~/MiniSpas/HomeSpa/Controllers/SignupController.js",
                "~/MiniSpas/HomeSpa/Controllers/TokensManagerController.js"
            ));

            #endregion

            #region "User profile spa Section"

            bundles.Add(new ScriptBundle("~/bundles/userprofile-modules").Include(
            "~/MiniSpas/UserProfileSpa/UserProfileSpaRoutes.js",
            "~/MiniSpas/UserProfileSpa/UserProfileSpaApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userprofile-services").Include(
            "~/MiniSpas/UserProfileSpa/Services/UserProfileService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userprofile-viewmodels").Include(
            "~/MiniSpas/UserProfileSpa/ViewModels/IUserProfileVM.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userprofile-controllers").Include(
                "~/MiniSpas/UserProfileSpa/Controllers/UserProfileController.js"
            ));

            #endregion

            #region "Search profile spa Section"

            bundles.Add(new ScriptBundle("~/bundles/searchprofile-modules").Include(
            "~/MiniSpas/SearchProfileSpa/SearchProfileSpaRoutes.js",
            "~/MiniSpas/SearchProfileSpa/SearchProfileSpaApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/searchprofile-services").Include(
            "~/MiniSpas/SearchProfileSpa/Services/SearchProfileService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/searchprofile-viewmodels").Include(
            "~/MiniSpas/SearchProfileSpa/ViewModels/IUserProfileListVM.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/searchprofile-controllers").Include(
                "~/MiniSpas/SearchProfileSpa/Controllers/SearchProfileController.js"
            ));

            #endregion

        }
    }
}
