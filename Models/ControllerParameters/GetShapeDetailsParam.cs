using FluentValidation;

namespace ChromeShape.Models.ControllerParameters
{
    public class GetShapeDetailsParam
    {
        public ShapeType ShapeType { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Side { get; set; }
        public double Radius { get; set; }
    }
    public class GetShapeDetailsParamValidator : AbstractValidator<GetShapeDetailsParam>
    {
        public GetShapeDetailsParamValidator()
        {
            RuleFor(x => x.ShapeType).IsInEnum();
            RuleFor(x => x.Width).NotEmpty().NotNull().When(w => w.ShapeType == ShapeType.Rectangle);
            RuleFor(x => x.Height).NotEmpty().NotNull().When(w => w.ShapeType == ShapeType.Rectangle);
            RuleFor(x => x.Radius).NotEmpty().NotNull().When(w => w.ShapeType == ShapeType.Circle);
            RuleFor(x => x.Side).NotEmpty().NotNull().When(w => w.ShapeType == ShapeType.Square);
        }
    }
}