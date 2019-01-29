using System.Threading.Tasks;
using AspNetCoreMvcEcommerce.Data;
using AspNetCoreMvcEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AspNetCoreMvcEcommerce.Controllers
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class BaseController : Controller
    {
        protected CestaDeCompra CarrinhoDeCompras
        {
            get
            {
                var cesta = HttpContext.Session.Get<CestaDeCompra>("cesta");

                if (cesta == null)
                {
                    cesta = new CestaDeCompra();
                    HttpContext.Session.Set("cesta", cesta);
                }

                return cesta;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UsuarioAdmin = User.IsInRole("admin");
            ViewBag.CarrinhoDeCompras = this.CarrinhoDeCompras;

            base.OnActionExecuting(context);
        }
    }
}