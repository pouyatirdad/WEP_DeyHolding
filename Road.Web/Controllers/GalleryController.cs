using Road.Infrastructure.Repositories;
using Road.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Road.Web.Controllers
{
    public class GalleryController : Controller
    {
        private readonly GalleriesRepository _repo;

        public GalleryController(GalleriesRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            var Galleries = _repo.GetAll().Where(x=>x.IsDeleted == false).ToList();

            #region BreadCrumb
            var breadCrumbVm = new List<BreadCrumbViewModel>();
            breadCrumbVm.Add(new BreadCrumbViewModel() { Title = "گالری ما", Href = "#" });
            ViewBag.BreadCrumb = breadCrumbVm;
            #endregion
            return View(Galleries);
        }
    }
}