namespace WebApplication3.Models
{
    public class Reservation
    {
            public int Id { get; set; } // Primary Key
            public int MovieId { get; set; }
            public string UserId { get; set; }
            public DateOnly ReservationDate { get; set; }
            public TimeOnly ReservationTime { get; set; }
            public string MovieTitle { get; set; }
        }

    }