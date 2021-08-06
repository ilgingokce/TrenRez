using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrenRez.Controllers
{
    public class VagonlarController : Controller
    {
        // GET: Trenler
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Vagonlar()
        {
            return View();
        }
    }
}