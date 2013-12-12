using System.Collections.Generic;
using DrawingLib;
using DrawingLib.Data.Entities;
using InfastructureLib;
using InfastructureLib.Data.Entities;
namespace Drawing.Models{
    public class ImageViewModel{
        public IEnumerable<IEnumerable<DPage>> navSection { get; set; }
        public DImage image { get; set; }
        
        public static ImageViewModel ForImageUserPage(int Image_ID, string username, int Page_ID) {
            IDrawingService service = new DrawingService();
            IInfastructureService infastructure = new InfastructureService();

            return new ImageViewModel {
                navSection = infastructure.PageStructure_GetBySelected(Page_ID),
                image = service.Image_GetTarget(username, Image_ID) ?? new DImage()
            };
        }
    }
}
