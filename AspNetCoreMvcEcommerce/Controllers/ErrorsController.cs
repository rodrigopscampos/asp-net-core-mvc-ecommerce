using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcEcommerce.Controllers {
    public class ErrorsController : Controller {

        public ActionResult Index (int id)
         {
            if (id == 500) 
            {
                return RedirectToAction (nameof (InternalServerError));
            }

            return RedirectToAction(nameof (NotFound));
        }

        public ActionResult InternalServerError () {
            return View ();
        }

        public ActionResult NotFound () {
            return View ();
        }
    }
}