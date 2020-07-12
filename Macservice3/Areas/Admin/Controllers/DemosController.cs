using Macservice3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Macservice3.Areas.Admin.Controllers
{
    public class DemosController : Controller
    {
        Macservice db = new Macservice();
        Xuly xl = new Xuly();

        // GET: Admin/Demos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string _FileName = "DemoUploadFile.xlsx";
                string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
                file.SaveAs(_path);
                ViewBag.upload = _path;
                DataTable dt = new DataTable();
                dt = xl.ReadDataFromExcelFile(_path);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Bangchamcong bcc = new Bangchamcong();
                    bcc.Mabangcong = "BCC01";
                    bcc.Maphongban = dt.Rows[i][0].ToString();
                    db.Bangchamcongs.Add(bcc);
                    db.SaveChanges();
                }
            }
            else
            {
                ViewBag.upload = "Upload file không thành công";
            }


            return View();
        }
    }
}
