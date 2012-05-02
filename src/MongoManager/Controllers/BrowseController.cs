using System.Web.Mvc;
using MongoManager.Services;

namespace MongoManager.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ConnectionService _connections = new ConnectionService();

        public ActionResult Index()
        {
            var url = _connections.GetConnection();
            var browser = new BrowseService(url);
            var model = browser.BrowseDatabases();
            return View(model);
        }

        public ActionResult Database(string db)
        {
            var url = _connections.GetConnection();
            var browser = new BrowseService(url);
            var model = browser.BrowseCollections(db);
            return View(model);
        }

        public ActionResult Collection(string db, string collection, int? page)
        {
            var url = _connections.GetConnection();
            var browser = new BrowseService(url);
            var model = browser.BrowseDocuments(db, collection, (page ?? 1) - 1);
            return View(model);
        }

    }
}
