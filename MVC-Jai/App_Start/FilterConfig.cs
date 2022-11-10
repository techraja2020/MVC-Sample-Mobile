using System.Web;
using System.Web.Mvc;
using MVC_Jai.App_Start;
namespace MVC_Jai
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionFilter());
        }
    }
}
