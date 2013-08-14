using System.Web;
using System.Web.Mvc;

namespace MvcSiteMapProvider_Remember_User_Position
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}