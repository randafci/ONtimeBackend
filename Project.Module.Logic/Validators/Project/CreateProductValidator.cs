using FluentValidation;
using OnTime.Module.Logic.Commands.Project;

namespace OnTime.Module.Logic.Validators.Project
{
 
        public class CreateProductValidator : AbstractValidator<CreateProductCommand>
        {
            public CreateProductValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Product name is required.");

                RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than zero.");
            }
        }
    

}
