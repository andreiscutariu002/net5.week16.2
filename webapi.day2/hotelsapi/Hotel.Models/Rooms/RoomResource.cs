namespace Hotels.Models.Rooms
{
    using System.ComponentModel.DataAnnotations;

    public class RoomResource
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
