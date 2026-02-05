namespace MongoDB_RestaurantProject.Context.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string AdminCollectionName { get; set; }
        public string BlogCollectionName { get; set; }
        public string BlogCommentCollectionName { get; set; }
        public string ChefCollectionName { get; set; }
        public string ContactInfoCollectionName { get; set; }
        public string FeedbackCollectionName { get; set; }
        public string GalleryCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string NewsletterCollectionName { get; set; }
        public string OfferCollectionName { get; set; }
        public string ProductReviewCollectionName { get; set; }
        public string PromationCollectionName { get; set; }
        public string ReservationCollectionName { get; set; }
    }
}
