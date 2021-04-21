using System.Web;
using System.Web.Mvc;

namespace m5d1_info_ctlr_vers_vue
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
