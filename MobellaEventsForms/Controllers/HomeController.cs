using System.Web.Mvc;

using MobellaEventsForms.Database;

namespace MobellaEventsForms.Controllers
{
    public class HomeController : Controller
    {
        private FormsDb _db;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var serverRootPath = Server.MapPath("~");
            _db = new FormsDb(serverRootPath);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            var clientInfos = _db.ClientInfoModels;
            return View(clientInfos);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
