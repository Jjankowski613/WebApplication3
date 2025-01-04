namespace WebApplication3.Models
{
    public class MovieRating
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public required string ImageUrl { get; set; }
    }
}
