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
            Shape s = null;
            switch (param.ShapeType)
            {
                case ShapeType.Circle:
                    s = new Circle() { Radius = param.Radius };
                    break;
                case ShapeType.Square:
                    s = new Square() { Side = param.Side };
                    break;
                case ShapeType.Rectangle:
                    s = new Rectangle() { Width = param.Width, Height = param.Height };
                    break;
                default:
                    break;
            }
            return new GetShapeDetailsResponse() { Area = s.Area(), Perimeter = s.Perimeter() };
        }
    }
}