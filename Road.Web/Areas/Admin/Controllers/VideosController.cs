using Road.Core.Models;
using Road.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Road.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class VideosController : Controller
    {
        private readonly VideoRepository _videoRepository;

        public VideosController(VideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        // GET: Admin/Videos
        public ActionResult Index()
        {
            return View(_videoRepository.GetAll());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video file = _videoRepository.Get(id.Value);
            if (file == null)
            {
                return HttpNotFound();
            }
            return PartialView(file);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase File, Video video)
        {
            #region Upload Video
            if (File != null)
            {

                var newFileName = Guid.NewGuid() + Path.GetExtension(File.FileName);
                File.SaveAs(Server.MapPath("/Files/Videos/" + newFileName));
                video.FileName = newFileName;
                _videoRepository.Update(video);
                //image.Image = newFileName;
                return RedirectToAction("Index");
            }
            #endregion
            return View();
        }
    }
}