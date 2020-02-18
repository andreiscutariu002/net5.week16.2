namespace Hotels.Data.Entities
{
    using System.Collections.Generic;

    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public IList<Room> Rooms { get; set; }
    }
}
