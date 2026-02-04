using FluentValidation;
using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;

namespace MongoDB_RestaurantProject.FluentValidation.CategoryValidators
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Kategori adı boş olamaz.")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
        }
    }
}
