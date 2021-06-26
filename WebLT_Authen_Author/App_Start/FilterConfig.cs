using System.Web;
using System.Web.Mvc;

namespace WebLT_Authen_Author
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
