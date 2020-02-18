namespace Hotels.Models.Rooms
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRoomResource
    {
        [Required]
        public string Number { get; set; }
    }
}
