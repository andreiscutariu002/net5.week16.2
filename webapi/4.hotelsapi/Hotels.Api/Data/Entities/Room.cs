using System.ComponentModel.DataAnnotations;

namespace Hotels.Api.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }
    }
}