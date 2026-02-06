using FluentValidation;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(200).WithMessage("Başlık 200 karakterden uzun olamaz.");

            RuleFor(x => x.BlogDetails)
                .NotEmpty().WithMessage("Blog içeriği boş olamaz.")
                .MinimumLength(20).WithMessage("Blog içeriği en az 20 karakter olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir resim URL'si giriniz.");

            RuleFor(x => x.Tags)
                .NotNull().WithMessage("Etiket listesi boş olamaz.")
                .Must(list => list.Count > 0).WithMessage("En az bir etiket girilmelidir.");
        }
    }
}
