using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;

namespace SitecoreCookBook.CustomPipelines
{
    public class Set404Status : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.Items["Is404Page"] != null && Sitecore.Context.Items["Is404Page"].ToString() == "true")
            {
                HttpContext.Current.Response.StatusCode = 404;
                HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}