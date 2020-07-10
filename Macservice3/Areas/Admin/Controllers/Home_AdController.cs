using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Macservice3.Areas.Admin.Controllers
{
    public class Home_AdController : Controller
    {
        // GET: Admin/Home_Ad
        public ActionResult Index()
        {
            return View();
        }
    }
}