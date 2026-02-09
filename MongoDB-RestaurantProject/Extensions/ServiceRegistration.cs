using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;
using MongoDB_RestaurantProject.Services.AboutService;
using MongoDB_RestaurantProject.Services.AdminService;
using MongoDB_RestaurantProject.Services.BlogCommentService;
using MongoDB_RestaurantProject.Services.BlogService;
using MongoDB_RestaurantProject.Services.CategoryService;
using MongoDB_RestaurantProject.Services.ChefService;
using MongoDB_RestaurantProject.Services.ContactInfoService;
using MongoDB_RestaurantProject.Services.FeedbackService;
using MongoDB_RestaurantProject.Services.GalleryService;
using MongoDB_RestaurantProject.Services.GenericService;
using MongoDB_RestaurantProject.Services.MessageService;
using MongoDB_RestaurantProject.Services.NewsletterService;
using MongoDB_RestaurantProject.Services.OfferService;
using MongoDB_RestaurantProject.Services.ProductReviewService;
using MongoDB_RestaurantProject.Services.ProductService;
using MongoDB_RestaurantProject.Services.PromationService;
using MongoDB_RestaurantProject.Services.ReservationService;
using MongoDB_RestaurantProject.Services.SMTPService;

namespace MongoDB_RestaurantProject.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddMongoDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });

            services.AddSingleton<IMongoCollection<About>>(sp => GetCollection<About>(sp, s => s.AboutCollectionName));
            services.AddSingleton<IMongoCollection<Admin>>(sp => GetCollection<Admin>(sp, s => s.AdminCollectionName));
            services.AddSingleton<IMongoCollection<Blog>>(sp => GetCollection<Blog>(sp, s => s.BlogCollectionName));
            services.AddSingleton<IMongoCollection<BlogComment>>(sp => GetCollection<BlogComment>(sp, s => s.BlogCommentCollectionName));
            services.AddSingleton<IMongoCollection<Chef>>(sp => GetCollection<Chef>(sp, s => s.ChefCollectionName));
            services.AddSingleton<IMongoCollection<ContactInfo>>(sp => GetCollection<ContactInfo>(sp, s => s.ContactInfoCollectionName));
            services.AddSingleton<IMongoCollection<Feedback>>(sp => GetCollection<Feedback>(sp, s => s.FeedbackCollectionName));
            services.AddSingleton<IMongoCollection<Gallery>>(sp => GetCollection<Gallery>(sp, s => s.GalleryCollectionName));
            services.AddSingleton<IMongoCollection<Message>>(sp => GetCollection<Message>(sp, s => s.MessageCollectionName));
            services.AddSingleton<IMongoCollection<Newsletter>>(sp => GetCollection<Newsletter>(sp, s => s.NewsletterCollectionName));
            services.AddSingleton<IMongoCollection<Offer>>(sp => GetCollection<Offer>(sp, s => s.OfferCollectionName));
            services.AddSingleton<IMongoCollection<ProductReview>>(sp => GetCollection<ProductReview>(sp, s => s.ProductReviewCollectionName));
            services.AddSingleton<IMongoCollection<Promation>>(sp => GetCollection<Promation>(sp, s => s.PromationCollectionName));
            services.AddSingleton<IMongoCollection<Reservation>>(sp => GetCollection<Reservation>(sp, s => s.ReservationCollectionName));
            services.AddSingleton<IMongoCollection<SmtpSettings>>(sp => sp.GetRequiredService<IMongoDatabase>().GetCollection<SmtpSettings>("SmtpSettings"));
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBlogCommentService, BlogCommentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<INewsletterSerivce, NewsletterService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromationService, PromationService>();
            services.AddScoped<IReservationService, ReservationService>();
        }
        private static IMongoCollection<T> GetCollection<T>(IServiceProvider sp, Func<MongoDbSettings, string> collectionNameSelector)
        {
            var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            var db = sp.GetRequiredService<IMongoDatabase>();
            return db.GetCollection<T>(collectionNameSelector(settings));
        }
    }
}