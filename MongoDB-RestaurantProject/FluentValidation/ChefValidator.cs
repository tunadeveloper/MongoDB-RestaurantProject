using FluentValidation;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.FluentValidation
{
    public class ChefValidator : AbstractValidator<Chef>
    {
        public ChefValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MaximumLength(100).WithMessage("Ad soyad 100 karakterden uzun olamaz.");

            RuleFor(x => x.PositionName)
                .NotEmpty().WithMessage("Pozisyon boş olamaz.")
                .MaximumLength(100).WithMessage("Pozisyon adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir resim URL'si giriniz.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[0-9\s\-]{7,15}$")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.InstagramUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .When(x => !string.IsNullOrWhiteSpace(x.InstagramUrl))
                .WithMessage("Geçerli bir Instagram URL'si giriniz.");

            RuleFor(x => x.FacebookUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .When(x => !string.IsNullOrWhiteSpace(x.FacebookUrl))
                .WithMessage("Geçerli bir Facebook URL'si giriniz.");

            RuleFor(x => x.LinkedInUrlh)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .When(x => !string.IsNullOrWhiteSpace(x.LinkedInUrlh))
                .WithMessage("Geçerli bir LinkedIn URL'si giriniz.");
        }
    }
}
