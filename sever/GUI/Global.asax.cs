using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
namespace GUI
{
    public class WebApiApplication : System.Web.HttpApplication
    {

		private const string LOG_FILE = @"c:\tmp\g.txt";
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterCacheEntry();

            BL.LoadProjectBL.useFuncToLoadThisClass();
            //BL.ManagerLogic.ExportExcel();
        }
        private void RegisterCacheEntry()
        {
            // Prevent duplicate key addition
            if (null != HttpContext.Current.Cache["uu"]) return;

            HttpContext.Current.Cache.Add("uu", "Test", null, DateTime.MaxValue,
                TimeSpan.FromMinutes(0.5), CacheItemPriority.NotRemovable,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }

        /// <summary>
        /// Callback method which gets invoked whenever the cache entry expires.
        /// We can do our "service" works here.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        public void CacheItemRemovedCallback(
            string key,
            object value,
            CacheItemRemovedReason reason
            )
        {
            Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());

            // Do the service works
            DoWork();

            // We need to register another cache item which will expire again in one
            // minute. However, as this callback occurs without any HttpContext, we do not
            // have access to HttpContext and thus cannot access the Cache object. The
            // only way we can access HttpContext is when a request is being processed which
            // means a webpage is hit. So, we need to simulate a web page hit and then 
            // add the cache item.
            //  HitPage();
        }

        /// <summary>
        /// Hits a local webpage in order to add another expiring item in cache
        /// </summary>


        /// <summary>
        /// Asynchronously do the 'service' works
        /// </summary>
        private void DoWork()
        {
            Debug.WriteLine("Begin DoWork...");
            //     Debug.WriteLine("Running as: " + WindowsIdentity.GetCurrent().Name);

            DoSomeFileWritingStuff();

            //DoSomeEmailSendStuff();
            //DoSomeMSMQStuff();


            Debug.WriteLine("End DoWork...");
        }
        private void DoSomeFileWritingStuff()
        {
            Debug.WriteLine("Writing to file...");

            try
            {
                using (StreamWriter writer = new StreamWriter(LOG_FILE, true))
                {
                    writer.WriteLine("Cache Callback: {0}", DateTime.Now);
                    writer.Close();
                }
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }

            Debug.WriteLine("File write successful");
        }
        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(
                SessionStateBehavior.Required);
        }
    }
}
