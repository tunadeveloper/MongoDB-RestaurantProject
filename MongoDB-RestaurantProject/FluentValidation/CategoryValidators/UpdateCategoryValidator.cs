using FluentValidation;
using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;

namespace MongoDB_RestaurantProject.FluentValidation.CategoryValidators
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz.")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
        }
    }
}
