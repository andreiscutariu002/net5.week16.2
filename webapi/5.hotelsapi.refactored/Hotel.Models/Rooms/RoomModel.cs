using System.ComponentModel.DataAnnotations;

namespace Hotels.Models.Rooms
{
    public class RoomModel
    {
        public int Id { get; set; }

        [Required] public string Number { get; set; }
    }
}