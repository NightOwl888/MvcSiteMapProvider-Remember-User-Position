using System.Web;
using System.Web.Mvc;

namespace MvcSiteMapProvider_Forcing_A_Match_2_Levels
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}