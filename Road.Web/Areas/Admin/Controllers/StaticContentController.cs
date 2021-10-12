using Road.Core.Models;
using Road.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Road.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class StaticContentController : Controller
    {
        private readonly StaticContentRepository _staticContentRepository;
        public StaticContentController(StaticContentRepository staticContentRepository)
        {
            _staticContentRepository = staticContentRepository;
        }

        public ActionResult Index()
        {
            var model = _staticContentRepository.Get(1);
            model = model ?? new StaticContent { Id = 0 };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(StaticContent model , HttpPostedFileBase ImageLogoSend)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Save = "ثبت شد";
                if (model.Id == 0)
                {
                    #region Upload Image
                    if (ImageLogoSend != null)
                    {
                        var newFileName = Guid.NewGuid() + Path.GetFileNameWithoutExtension(ImageLogoSend.FileName) + ".png";
                        ImageLogoSend.SaveAs(Server.MapPath("/Files/Logo/" + newFileName));
                        model.ImageLogo = newFileName;
                    }

                    _staticContentRepository.Add(model);
                }

                #endregion
                else
                {
                    #region Upload Image
                    if (ImageLogoSend != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("/Files/Logo/" + model.ImageLogo)))
                            System.IO.File.Delete(Server.MapPath("/Files/Logo/" + model.ImageLogo));

                        var newFileName = Guid.NewGuid() + Path.GetFileNameWithoutExtension(ImageLogoSend.FileName) + ".png";
                        ImageLogoSend.SaveAs(Server.MapPath("/Files/Logo/" + newFileName));
                        model.ImageLogo = newFileName;
                    }
                    #endregion
                    _staticContentRepository.Update(model);
                }

                return RedirectToAction("index", "dashboard");
            }
            else
            {
                ViewBag.Message = "مشکلی وجود دارد!";
            }

            return View(model);

        }
        public ActionResult LogoImage()
        {
            ViewBag.Logo = _staticContentRepository.Get(1).ImageLogo;
            return PartialView();
        }
    }
}