using System.Threading.Tasks;
using AspNetCoreMvcEcommerce.Database;
using AspNetCoreMvcEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AspNetCoreMvcEcommerce.Controllers
{
    public class BaseController : Controller
    {
        public CestaDeCompra PegarCarrinhoDeCompras()
        {
            var cesta = HttpContext.Session.GetString("cesta");

            if(cesta == null)
            {
                return new CestaDeCompra();
            }

            return JsonConvert.DeserializeObject<CestaDeCompra>(cesta);
        }

        public void SalvarCarrinhoDeCompras(CestaDeCompra cesta)
        {
            var cestaString = JsonConvert.SerializeObject(cesta);
            HttpContext.Session.SetString("cesta", cestaString);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UsuarioAdmin = User.IsInRole("admin");
            ViewBag.CarrinhoDeCompras = PegarCarrinhoDeCompras();

            base.OnActionExecuting(context);
        }
    }
}