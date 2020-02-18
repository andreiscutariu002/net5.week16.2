namespace Hotels.Models.Hotels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateHotelResource
    {
        [Required]
        public string Name { get; set; }

        public string City { get; set; }
    }
}
