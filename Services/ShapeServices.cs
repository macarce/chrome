using ChromeShape.Models;
using ChromeShape.Models.ControllerParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChromeShape.Services
{
    public class ShapeServices : IShapeServices
    {
        public GetShapeDetailsResponse GetShapeDetail(GetShapeDetailsParam param)
        {
            GetShapeDetailsResponse details = null;
            switch (param.ShapeType)
            {
                case ShapeType.Circle:
                    var c = new Circle() { Radius = param.Radius };
                    details = new GetShapeDetailsResponse() { Area = c.Area(), Perimeter = c.Perimeter() };
                    break;
                case ShapeType.Square:
                    var s = new Square() { Side = param.Side };
                    details = new GetShapeDetailsResponse() { Area = s.Area(), Perimeter = s.Perimeter() };
                    break;
                case ShapeType.Rectangle:
                    var r = new Rectangle() { Width = param.Width, Height = param.Height };
                    details = new GetShapeDetailsResponse() { Area = r.Area(), Perimeter = r.Perimeter() };
                    break;
                default:
                    break;
            }
            return details;
        }
    }
}