using ChromeShape.Models.ControllerParameters;
using System.Threading.Tasks;

namespace ChromeShape.Services
{
    public interface IShapeServices
    {
        GetShapeDetailsResponse GetShapeDetail(GetShapeDetailsParam param);
    }
}