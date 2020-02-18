using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Hotels
{
    public class CreateHotelRequestModel
    {
        [Required] public string Name { get; set; }

        public string City { get; set; }
    }
}