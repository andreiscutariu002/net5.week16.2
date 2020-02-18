namespace Hotels.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public Hotel Hotel { get; set; }
    }
}
