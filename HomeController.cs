using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/FileUpload

        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void FileUpload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(file.FileName);
                        // TODO: need to define destination
                        var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
                        file.SaveAs(path);
                    }
                }
            }
        }
    }
}
