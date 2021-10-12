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
    public class SliderController : Controller
    {
        private readonly SliderRepository _sliderRepository;

        public SliderController(SliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public ActionResult Index()
        {
            return View(_sliderRepository.GetAll());
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider image, HttpPostedFileBase GalleryImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (GalleryImage != null)
                {
                    var newFileName = Guid.NewGuid() + Path.GetExtension(GalleryImage.FileName);
                    GalleryImage.SaveAs(Server.MapPath("/Files/Slider/" + newFileName));
                    image.Image = newFileName;
                }
                #endregion

                _sliderRepository.Add(image);
                return RedirectToAction("Index");
            }

            return View(image);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider image = _sliderRepository.Get(id.Value);
            if (image == null)
            {
                return HttpNotFound();
            }
            return PartialView(image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider gallery, HttpPostedFileBase GalleryImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (GalleryImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("/Files/Slider/" + gallery.Image)))
                        System.IO.File.Delete(Server.MapPath("/Files/Slider/" + gallery.Image));

                    var newFileName = Guid.NewGuid() + Path.GetExtension(GalleryImage.FileName);
                    GalleryImage.SaveAs(Server.MapPath("/Files/Slider/" + newFileName));
                    gallery.Image = newFileName;
                }
                #endregion

                _sliderRepository.Update(gallery);
                return RedirectToAction("Index");
            }
            return View(gallery);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider image = _sliderRepository.Get(id.Value);
            if (image == null)
            {
                return HttpNotFound();
            }
            return PartialView(image);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var image = _sliderRepository.Get(id);

            _sliderRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}