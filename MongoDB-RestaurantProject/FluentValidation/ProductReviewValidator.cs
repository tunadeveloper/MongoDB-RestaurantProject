using FluentValidation;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.FluentValidation
{
    public class ProductReviewValidator : AbstractValidator<ProductReview>
    {
        public ProductReviewValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MaximumLength(100).WithMessage("Ad soyad 100 karakterden uzun olamaz.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alanı boş olamaz.")
                .MinimumLength(5).WithMessage("Yorum en az 5 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Yorum 1000 karakterden uzun olamaz.");

            RuleFor(x => x.Star)
                .InclusiveBetween(1, 5)
                .WithMessage("Puan 1 ile 5 arasında olmalıdır.");
        }
    }
}
