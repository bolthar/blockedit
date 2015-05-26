using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BlockEdit.App_Start
{
    public class BundleConfig
    {        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.3.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/note").Include(
                        "~/Scripts/Note/Note.js"));

            bundles.Add(new ScriptBundle("~/bundles/element")
                            .Include("~/Scripts/Element/Element.ViewModels.js")
                            .Include("~/Scripts/Element/Element.js"));
                
                

            bundles.Add(new ScriptBundle("~/bundles/shell")
                .Include("~/Scripts/Shell.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.js"));
        }
    }
}