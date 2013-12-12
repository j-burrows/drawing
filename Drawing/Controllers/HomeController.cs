using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drawing.Models;
using DrawingLib;
using DrawingLib.Data.Entities;

namespace Drawing.Controllers{
    [Authorize]
    public class HomeController : Controller{
        private IDrawingService drawingService = new DrawingService();

        public ActionResult Index(){
            return View(HomeIndexViewModel.ForUserPage(User.Identity.Name, 32));
        }

        [HttpPost]
        public void Image_Create(DImage creating) {
            drawingService.Image_Create(creating, User.Identity.Name);
        }

        [HttpPost]
        public void Image_Update(DImage updating) {
            drawingService.Image_Update(updating, User.Identity.Name);
        }

        [HttpPost]
        public void Image_Delete(DImage deleting) {
            drawingService.Image_Delete(deleting, User.Identity.Name);
        }

        [HttpPost]
        public JsonResult Shape_GetByImage(int Image_ID) {
            var shapes = drawingService.Shape_GetByImage(Image_ID);
            return Json(shapes);
        }

        [HttpPost]
        public void Shape_Create(DShape creating) {
            drawingService.Shape_Create(creating, User.Identity.Name);
        }

        [HttpPost]
        public void Shape_Update(DShape updating) {
            drawingService.Shape_Update(updating, User.Identity.Name);
        }

        [HttpPost]
        public void Shape_Delete(DShape deleting) {
            drawingService.Shape_Delete(deleting, User.Identity.Name);
        }
    }
}
