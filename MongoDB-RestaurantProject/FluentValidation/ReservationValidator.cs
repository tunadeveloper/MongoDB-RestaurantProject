using FluentValidation;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.FluentValidation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad soyad alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad soyad en az 3 karakter olmalıdır.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası zorunludur.")
                .Matches(@"^[0-9+\s-]{10,15}$").WithMessage("Telefon numarası formatı geçersiz.");

            RuleFor(x => x.NumberOfPeople)
                .NotEmpty().WithMessage("Kişi sayısı belirtilmelidir.")
                .Must(x => int.TryParse(x, out var value) && value > 0)
                .WithMessage("Kişi sayısı pozitif bir sayı olmalıdır.");

            RuleFor(x => x.ReservationAt)
                .NotEmpty().WithMessage("Rezervasyon tarihi seçilmelidir.")
                .GreaterThan(DateTime.Now)
                .WithMessage("Rezervasyon tarihi geçmiş bir tarih olamaz.");
        }
    }
}
