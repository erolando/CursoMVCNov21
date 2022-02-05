using HomeDepot.DomainLayer.BusinessObject;
using HomeDepot.DomainLayer.DTO;
using System.Web.Mvc;

namespace HomeDepot.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        BOProducts bussinessProduct = new BOProducts("");
        public ActionResult Insertar(string nombre)
        {
            var rq = new DomainLayer.RQ.RQProduct()
            {
                Nombre = nombre
            };
            DTOProduct result = bussinessProduct.Insert(rq);
            return View(result);
        }
    }
}