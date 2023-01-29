using FluentValidation;

namespace Service.Features.Catalog.Commands.AddCategory
{
    public class AddCategoryCommandValidation : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidation()
        {
            RuleFor(addCategoryCommand =>
            addCategoryCommand.Name).NotEmpty().MaximumLength(32);
        }
    }
}
