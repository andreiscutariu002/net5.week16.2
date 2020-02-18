using System.Collections.Generic;

namespace Hotels.Data.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public IList<Room> Rooms { get; set; }
    }
}