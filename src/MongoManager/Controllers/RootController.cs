using System.Web.Mvc;
using MongoManager.Models;
using MongoManager.Services;

namespace MongoManager.Controllers
{
    public class RootController : Controller
    {
        public ActionResult Index()
        {
            var model = new ConnectionModel();
            return View(model);
        }

        public ActionResult SetConnection(ConnectionModel model)
        {
            var connections = new ConnectionService();
            var response = connections.SetConnection(model);
            if (!response.Success)
            {
                model.Message = response.Message;
                return View("Index", model);
            }
            return RedirectToAction("Index", "Browse", null);
        }
    }
}
