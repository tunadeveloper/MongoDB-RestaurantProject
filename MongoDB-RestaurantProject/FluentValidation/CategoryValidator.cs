using FluentValidation;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Kategori adı 100 karakterden uzun olamaz.");
        }
    }
}
