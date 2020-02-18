using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Rooms
{
    public class UpdateRoomRequestModel
    {
        [Required] public string Number { get; set; }
    }
}