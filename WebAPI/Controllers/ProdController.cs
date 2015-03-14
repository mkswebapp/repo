using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class ProdController : Controller
    {
        //
        // GET: /Prod/

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
