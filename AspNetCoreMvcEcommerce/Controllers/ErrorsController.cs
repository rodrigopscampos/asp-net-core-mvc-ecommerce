using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcEcommerce.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}