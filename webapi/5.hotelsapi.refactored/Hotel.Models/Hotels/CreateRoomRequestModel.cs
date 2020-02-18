using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Hotels
{
    public class CreateRoomRequestModel
    {
        [Required] public string Number { get; set; }

        [Required] public int  HotelId { get; set; }
    }

    public class CreateRoomRequestModel2
    {
        [Required] public string Number { get; set; }
    }
}