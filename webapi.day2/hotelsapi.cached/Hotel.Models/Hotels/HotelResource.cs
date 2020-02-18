namespace Hotels.Models.Hotels
{
    using System.ComponentModel.DataAnnotations;

    public class HotelResource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }
    }
}
