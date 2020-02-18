using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Hotels
{
    public class HotelModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string City { get; set; }
    }
}