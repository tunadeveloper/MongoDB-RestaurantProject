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
using MongoDB_RestaurantProject.DataTransferObject.LoginDTOs;
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
            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();

            CreateMap<Admin, ResultAdminDTO>().ReverseMap();
            CreateMap<Admin, CreateAdminDTO>().ReverseMap();
            CreateMap<Admin, UpdateAdminDTO>().ReverseMap();
            CreateMap<Admin, LoginDTO>().ReverseMap();

            CreateMap<Blog, ResultBlogDTO>().ReverseMap();
            CreateMap<Blog, CreateBlogDTO>().ReverseMap();
            CreateMap<Blog, UpdateBlogDTO>().ReverseMap();

            CreateMap<BlogComment, ResultBlogCommentDTO>().ReverseMap();
            CreateMap<BlogComment, CreateBlogCommentDTO>().ReverseMap();
            CreateMap<BlogComment, UpdateBlogCommentDTO>().ReverseMap();

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Chef, ResultChefDTO>().ReverseMap();
            CreateMap<Chef, CreateChefDTO>().ReverseMap();
            CreateMap<Chef, UpdateChefDTO>().ReverseMap();

            CreateMap<ContactInfo, ResultContactInfoDTO>().ReverseMap();
            CreateMap<ContactInfo, CreateContactInfoDTO>().ReverseMap();
            CreateMap<ContactInfo, UpdateContactInfoDTO>().ReverseMap();

            CreateMap<Feedback, ResultFeedbackDTO>().ReverseMap();
            CreateMap<Feedback, CreateFeedbackDTO>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackDTO>().ReverseMap();

            CreateMap<Gallery, ResultGalleryDTO>().ReverseMap();
            CreateMap<Gallery, CreateGalleryDTO>().ReverseMap();
            CreateMap<Gallery, UpdateGalleryDTO>().ReverseMap();

            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();

            CreateMap<Newsletter, ResultNewsletterDTO>().ReverseMap();
            CreateMap<Newsletter, CreateNewsletterDTO>().ReverseMap();
            CreateMap<Newsletter, UpdateNewsletterDTO>().ReverseMap();

            CreateMap<Offer, ResultOfferDTO>().ReverseMap();
            CreateMap<Offer, CreateOfferDTO>().ReverseMap();
            CreateMap<Offer, UpdateOfferDTO>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<ProductReview, ResultProductReviewDTO>().ReverseMap();
            CreateMap<ProductReview, CreateProductReviewDTO>().ReverseMap();
            CreateMap<ProductReview, UpdateProductReviewDTO>().ReverseMap();
  
            CreateMap<Promation, ResultPromationDTO>().ReverseMap();
            CreateMap<Promation, CreatePromationDTO>().ReverseMap();
            CreateMap<Promation, UpdatePromationDTO>().ReverseMap();

            CreateMap<Reservation, ResultReservationDTO>().ReverseMap();
            CreateMap<Reservation, CreateReservationDTO>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDTO>().ReverseMap();

            CreateMap<SmtpSettings, ResultSmtpDTO>().ReverseMap();
            CreateMap<SmtpSettings, CreateSmtpDTO>().ReverseMap();
            CreateMap<SmtpSettings, UpdateSmtpDTO>().ReverseMap();
        }
    }
}