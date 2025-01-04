using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // Właściwość nawigacyjna
        public ICollection<UserRating> UserRatings { get; set; }
    }



}
