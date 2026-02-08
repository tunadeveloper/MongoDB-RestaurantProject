using AutoMapper;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.AboutDTOs;
using MongoDB_RestaurantProject.DataTransferObject.AdminDTOs;
using MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs;
using MongoDB_RestaurantProject.DataTransferObject.BlogDTOs;
using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ChefDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ContactInfoDTOs;
using MongoDB_RestaurantProject.DataTransferObject.FeedbackDTOs;
using MongoDB_RestaurantProject.DataTransferObject.GalleryDTOs;
using MongoDB_RestaurantProject.DataTransferObject.MessageDTOs;
using MongoDB_RestaurantProject.DataTransferObject.NewsletterDTOs;
using MongoDB_RestaurantProject.DataTransferObject.OfferDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductReviewDTOs;
using MongoDB_RestaurantProject.DataTransferObject.PromationDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ReservationDTOs;
using MongoDB_RestaurantProject.DataTransferObject.SmtpDTOs;

namespace MongoDB_RestaurantProject.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Category, ResultCategoryDTO>();

            CreateMap<CreateBlogDTO, Blog>();
            CreateMap<UpdateBlogDTO, Blog>();
            CreateMap<Blog, ResultBlogDTO>();

            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, ResultProductDTO>();

            CreateMap<CreateAboutDTO, About>();
            CreateMap<About, UpdateAboutDTO>();
            CreateMap<About, ResultAboutDTO>();

            CreateMap<CreateAdminDTO, Admin>();
            CreateMap<UpdateAdminDTO, Admin>();
            CreateMap<Admin, ResultAdminDTO>();

            CreateMap<CreateBlogCommentDTO, BlogComment>();
            CreateMap<UpdateBlogCommentDTO, BlogComment>();
            CreateMap<BlogComment, ResultBlogCommentDTO>();

            CreateMap<CreateChefDTO, Chef>();
            CreateMap<UpdateChefDTO, Chef>();
            CreateMap<Chef, ResultChefDTO>();

            CreateMap<CreateContactInfoDTO, ContactInfo>();
            CreateMap<ContactInfo, UpdateContactInfoDTO>();
            CreateMap<ContactInfo, ResultContactInfoDTO>();

            CreateMap<CreateFeedbackDTO, Feedback>();
            CreateMap<UpdateFeedbackDTO, Feedback>();
            CreateMap<Feedback, ResultFeedbackDTO>();

            CreateMap<CreateGalleryDTO, Gallery>();
            CreateMap<UpdateGalleryDTO, Gallery>();
            CreateMap<Gallery, ResultGalleryDTO>();

            CreateMap<CreateMessageDTO, Message>();
            CreateMap<UpdateMessageDTO, Message>();
            CreateMap<Message, ResultMessageDTO>();

            CreateMap<CreateNewsletterDTO, Newsletter>();
            CreateMap<UpdateNewsletterDTO, Newsletter>();
            CreateMap<Newsletter, ResultNewsletterDTO>();

            CreateMap<Offer, CreateOfferDTO>().ReverseMap();
            CreateMap<Offer, UpdateOfferDTO>().ReverseMap();
            CreateMap<Offer, ResultOfferDTO>().ReverseMap();

            CreateMap<CreateProductReviewDTO, ProductReview>();
            CreateMap<UpdateProductReviewDTO, ProductReview>();
            CreateMap<ProductReview, ResultProductReviewDTO>();

            CreateMap<CreatePromationDTO, Promation>();
            CreateMap<UpdatePromationDTO, Promation>();
            CreateMap<Promation, ResultPromationDTO>();

            CreateMap<CreateReservationDTO, Reservation>();
            CreateMap<UpdateReservationDTO, Reservation>();
            CreateMap<Reservation, ResultReservationDTO>();

            CreateMap<CreateSmtpDTO, SmtpSettings>();
            CreateMap<UpdateSmtpDTO, SmtpSettings>();
            CreateMap<SmtpSettings, ResultSmtpDTO>();
        }
    }
}
