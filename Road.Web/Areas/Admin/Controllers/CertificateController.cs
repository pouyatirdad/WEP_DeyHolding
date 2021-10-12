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
    public class CertificateController : Controller
    {
        private readonly CertificateRepository _certificateRepository;

        public CertificateController(CertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }
        public ActionResult Index()
        {
            return View(_certificateRepository.GetAll());
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Certificate image, HttpPostedFileBase GalleryImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (GalleryImage != null)
                {
                    var newFileName = Guid.NewGuid() + Path.GetExtension(GalleryImage.FileName);
                    GalleryImage.SaveAs(Server.MapPath("/Files/Certificate/" + newFileName));
                    image.Image = newFileName;
                }
                #endregion

                _certificateRepository.Add(image);
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
            Certificate image = _certificateRepository.Get(id.Value);
            if (image == null)
            {
                return HttpNotFound();
            }
            return PartialView(image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Certificate gallery, HttpPostedFileBase GalleryImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (GalleryImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("/Files/Certificate/" + gallery.Image)))
                        System.IO.File.Delete(Server.MapPath("/Files/Certificate/" + gallery.Image));

                    var newFileName = Guid.NewGuid() + Path.GetExtension(GalleryImage.FileName);
                    GalleryImage.SaveAs(Server.MapPath("/Files/Certificate/" + newFileName));
                    gallery.Image = newFileName;
                }
                #endregion

                _certificateRepository.Update(gallery);
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
            Certificate image = _certificateRepository.Get(id.Value);
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
            var image = _certificateRepository.Get(id);

            _certificateRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}