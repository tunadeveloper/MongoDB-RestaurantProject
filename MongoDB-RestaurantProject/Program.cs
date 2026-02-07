using FluentValidation;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;
using MongoDB_RestaurantProject.Mapping;
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

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection(nameof(MongoDbSettings))
);

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddSingleton(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;

    return new
    {
        About = db.GetCollection<About>(settings.AboutCollectionName),
        Admin = db.GetCollection<Admin>(settings.AdminCollectionName),
        Blog = db.GetCollection<Blog>(settings.BlogCollectionName),
        BlogComment = db.GetCollection<BlogComment>(settings.BlogCommentCollectionName),
        Chef = db.GetCollection<Chef>(settings.ChefCollectionName),
        ContactInfo = db.GetCollection<ContactInfo>(settings.ContactInfoCollectionName),
        Feedback = db.GetCollection<Feedback>(settings.FeedbackCollectionName),
        Gallery = db.GetCollection<Gallery>(settings.GalleryCollectionName),
        Message = db.GetCollection<Message>(settings.MessageCollectionName),
        Newsletter = db.GetCollection<Newsletter>(settings.NewsletterCollectionName),
        Offer = db.GetCollection<Offer>(settings.OfferCollectionName),
        ProductReview = db.GetCollection<ProductReview>(settings.ProductReviewCollectionName),
        Promation = db.GetCollection<Promation>(settings.PromationCollectionName),
        Reservation = db.GetCollection<Reservation>(settings.ReservationCollectionName)
    };
});

builder.Services.AddSingleton<IMongoCollection<About>>(sp => sp.GetRequiredService<dynamic>().About);
builder.Services.AddSingleton<IMongoCollection<Admin>>(sp => sp.GetRequiredService<dynamic>().Admin);
builder.Services.AddSingleton<IMongoCollection<Blog>>(sp => sp.GetRequiredService<dynamic>().Blog);
builder.Services.AddSingleton<IMongoCollection<BlogComment>>(sp => sp.GetRequiredService<dynamic>().BlogComment);
builder.Services.AddSingleton<IMongoCollection<Chef>>(sp => sp.GetRequiredService<dynamic>().Chef);
builder.Services.AddSingleton<IMongoCollection<ContactInfo>>(sp => sp.GetRequiredService<dynamic>().ContactInfo);
builder.Services.AddSingleton<IMongoCollection<Feedback>>(sp => sp.GetRequiredService<dynamic>().Feedback);
builder.Services.AddSingleton<IMongoCollection<Gallery>>(sp => sp.GetRequiredService<dynamic>().Gallery);
builder.Services.AddSingleton<IMongoCollection<Message>>(sp => sp.GetRequiredService<dynamic>().Message);
builder.Services.AddSingleton<IMongoCollection<Newsletter>>(sp => sp.GetRequiredService<dynamic>().Newsletter);
builder.Services.AddSingleton<IMongoCollection<Offer>>(sp => sp.GetRequiredService<dynamic>().Offer);
builder.Services.AddSingleton<IMongoCollection<ProductReview>>(sp => sp.GetRequiredService<dynamic>().ProductReview);
builder.Services.AddSingleton<IMongoCollection<Promation>>(sp => sp.GetRequiredService<dynamic>().Promation);
builder.Services.AddSingleton<IMongoCollection<Reservation>>(sp => sp.GetRequiredService<dynamic>().Reservation);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogCommentService, BlogCommentService>();
builder.Services.AddScoped<IChefService, ChefService>();
builder.Services.AddScoped<IContactInfoService, ContactInfoService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INewsletterSerivce, NewsletterService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IProductReviewService, ProductReviewService>();
builder.Services.AddScoped<IPromationService, PromationService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
