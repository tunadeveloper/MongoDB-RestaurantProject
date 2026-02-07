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

builder.Services.AddSingleton<IMongoCollection<About>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<About>(opt.AboutCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Admin>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Admin>(opt.AdminCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Blog>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Blog>(opt.BlogCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<BlogComment>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<BlogComment>(opt.BlogCommentCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Chef>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Chef>(opt.ChefCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<ContactInfo>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<ContactInfo>(opt.ContactInfoCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Feedback>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Feedback>(opt.FeedbackCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Gallery>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Gallery>(opt.GalleryCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Message>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Message>(opt.MessageCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Newsletter>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Newsletter>(opt.NewsletterCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Offer>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Offer>(opt.OfferCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<ProductReview>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<ProductReview>(opt.ProductReviewCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Promation>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Promation>(opt.PromationCollectionName);
});

builder.Services.AddSingleton<IMongoCollection<Reservation>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<Reservation>(opt.ReservationCollectionName);
});

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

builder.Services.AddSingleton<IMongoCollection<SmtpSettings>>(sp =>
{
    var opt = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<SmtpSettings>("SmtpSettings");
});

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddScoped<IMailService, MailService>();

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
