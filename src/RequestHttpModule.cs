using System;
using System.Configuration;
using System.Web;
using StackExchange.Profiling;

namespace POSSIBLE.ProfiledContentRepository
{
    public class RequestHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            if (ConfigManager.EnableProfiledRepository)
            {
                SetUpDefaultDisplayDelegate();
                BindMiniProfilerApplicationEvents(context);        
            }
        }

        private void SetUpDefaultDisplayDelegate()
        {
            DisplayProfilerHandler.SetDefaultBehaviour();
        }

        private void BindMiniProfilerApplicationEvents(HttpApplication context)
        {
            context.BeginRequest -= context_BeginRequest;
            context.BeginRequest += context_BeginRequest;

            context.PostAuthorizeRequest -= context_OnPostAuthorizeRequest;
            context.PostAuthorizeRequest += context_OnPostAuthorizeRequest;

            context.EndRequest -= context_EndRequest;
            context.EndRequest += context_EndRequest;
        }

        private void context_BeginRequest(object sender, System.EventArgs e)
        {
            if (DisplayProfilerHandler.ShouldStart(new HttpContextWrapper(HttpContext.Current)))
                MiniProfiler.Start();
        }

        private void context_OnPostAuthorizeRequest(object sender, EventArgs eventArgs)
        {
            if (!DisplayProfilerHandler.ShowToUser(new HttpContextWrapper(HttpContext.Current)))
                MiniProfiler.Stop(discardResults: true);
        }

        private void context_EndRequest(object sender, EventArgs eventArgs)
        {
            MiniProfiler.Stop();
        }       

        public void Dispose()
        {
            
        }
    }
}