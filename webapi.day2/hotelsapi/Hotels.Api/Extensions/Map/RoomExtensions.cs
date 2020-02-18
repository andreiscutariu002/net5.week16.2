namespace Hotels.Api.Extensions.Map
{
    using Data.Entities;
    using Models.Rooms;

    public static class RoomExtensions
    {
        public static Room MapAsNewEntity(this CreateRoomResource model, Hotel hotel)
        {
            return new Room
            {
                Number = model.Number,
                Hotel = hotel
            };
        }

        public static RoomResource MapAsResource(this Room model)
        {
            return new RoomResource
            {
                Number = model.Number,
                Id = model.Id
            };
        }

        public static void UpdateWith(this Room room, UpdateRoomResource model)
        {
            room.Number = model.Number;
        }
    }
}
