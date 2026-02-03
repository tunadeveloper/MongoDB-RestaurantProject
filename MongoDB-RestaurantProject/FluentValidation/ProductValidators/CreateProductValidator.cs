using FluentValidation;
using MongoDB.Bson;
using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;

namespace MongoDB_RestaurantProject.FluentValidation.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Ürün adı boş olamaz.")
            .MaximumLength(100).WithMessage("Ürün adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz.");

            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Ağırlık bilgisi boş olamaz.");

            RuleFor(x => x.Dimensions)
                .NotEmpty().WithMessage("Boyut bilgisi boş olamaz.");

            RuleFor(x => x.PriceHalf)
                .GreaterThan(0).WithMessage("Yarım porsiyon fiyatı 0'dan büyük olmalıdır.");

            RuleFor(x => x.PriceFull)
                .GreaterThan(0).WithMessage("Tam porsiyon fiyatı 0'dan büyük olmalıdır.");

            RuleFor(x => x.Ingredients)
                .NotNull().WithMessage("Malzemeler boş olamaz.")
                .Must(list => list.Count > 0).WithMessage("En az 1 malzeme eklemelisiniz.");
        }
     
    }
}