using System.Web.Http.ModelBinding;
using FluentValidation.Results;

namespace ChromeShape.Extensions
{    public static class ModelStateExtensions
    {
        public static void Update(this ModelStateDictionary modelState, ValidationResult result, bool usePropertyNames = false)
        {
            foreach (var error in result.Errors)
            {
                var propertyName = usePropertyNames ? error.PropertyName : "";
                modelState.AddModelError(propertyName, error.ErrorMessage);
            }
        }
    }
}