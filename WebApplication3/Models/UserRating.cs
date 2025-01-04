namespace WebApplication3.Models
{
    public class UserRating
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } 
    }




}
