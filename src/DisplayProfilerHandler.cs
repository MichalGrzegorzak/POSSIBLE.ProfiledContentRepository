using System.Web;

namespace POSSIBLE.ProfiledContentRepository
{
    public delegate bool ShouldStartProfiler(HttpContextBase httpContext);
    public delegate bool ShowProfilerToAuthenticatedUser(HttpContextBase httpContext);
    
    public static class DisplayProfilerHandler
    {
        public static ShouldStartProfiler ShouldStart;
        public static ShowProfilerToAuthenticatedUser ShowToUser;
        
        public static void SetDefaultBehaviour()
        {
            if (ShouldStart == null)
                ShouldStart = DefaultStartBehavior;

            if (ShowToUser == null)
                ShowToUser = DefaultUserAuthenticatedBehavior;
        }

        private static bool DefaultStartBehavior(HttpContextBase httpContext)
        {
            return true;
        }

        private static bool DefaultUserAuthenticatedBehavior(HttpContextBase httpContext)
        {
            if (httpContext.User == null)
                return false;

            return httpContext.User.IsInRole("WebAdmins") || httpContext.User.IsInRole("Administrators");
        }

        public static void SetLocalBehaviour()
        {
            ShouldStart = httpContext => httpContext.Request.ServerVariables["REMOTE_ADDR"].Equals("127.0.0.1");;
            ShowToUser = httpContext => true;
        }

        public static void SetCustomHeaderBehaviour()
        {
            ShouldStart = httpContext => httpContext.Request.Headers["X-Profiler"] != null;
            ShowToUser = DefaultUserAuthenticatedBehavior;
        }
    }
}