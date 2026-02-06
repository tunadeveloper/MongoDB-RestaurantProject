using FluentValidation;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.FluentValidation
{
    public class ContactInfoValidator : AbstractValidator<ContactInfo>
    {
        public ContactInfoValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\+?[0-9\s\-]{7,15}$")
                .WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(300).WithMessage("Adres 300 karakterden uzun olamaz.");

            RuleFor(x => x.email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.MapUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .When(x => !string.IsNullOrWhiteSpace(x.MapUrl))
                .WithMessage("Geçerli bir harita URL'si giriniz.");
        }
    }
}
