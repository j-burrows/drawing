using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrawingLib;
using DrawingLib.Data.Entities;
using InfastructureLib;
using InfastructureLib.Data.Entities;

namespace Drawing.Models{
    public class HomeIndexViewModel{
        public IEnumerable<IEnumerable<DPage>> navSection { get; set; }
        public IEnumerable<DImage> Images { get; set; }

        public static HomeIndexViewModel ForUserPage(string username, int Page_ID){
            IInfastructureService infastructure = new InfastructureService();
            IDrawingService service = new DrawingService();
            
            return new HomeIndexViewModel { 
                navSection = infastructure.PageStructure_GetBySelected(Page_ID),
                Images = service.Image_GetByUser(username)
            };
        }
    }
}
