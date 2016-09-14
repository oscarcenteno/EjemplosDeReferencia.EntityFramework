using System.Web;
using System.Web.Mvc;

namespace Ejemplos.EntityFramework.WebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
