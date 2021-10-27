using ChromeShape.Extensions;
using ChromeShape.Models.ControllerParameters;
using ChromeShape.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ChromeShape.Controllers
{
    [RoutePrefix("Shape")]
    public class ShapeController : ApiController
    {
        private readonly IShapeServices _service;
        public ShapeController(IShapeServices service)
        {
            _service = service;
        }


        /// <summary>
        /// Get Details of the Shape
        /// </summary>
        [ResponseType(typeof(GetShapeDetailsResponse))]
        [Route("Details")]
        public IHttpActionResult Get([FromUri] GetShapeDetailsParam param)
        {
            #region FluentValidation
            var validator = new GetShapeDetailsParamValidator();
            var results = validator.Validate(param);

            if (!results.IsValid)
            {
                ModelState.Update(results, true);
                return BadRequest(ModelState);
            }
            #endregion

            var result = _service.GetShapeDetail(param);

            return Ok(result);
        }
    }
}
