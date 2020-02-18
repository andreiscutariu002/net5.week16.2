using Hotels.Data.Entities;
using Hotels.Models.Hotels;
using Hotels.Models.Rooms;

namespace Hotels.Api.Extensions.Map
{
    public static class RoomExtensions
    {
        public static Room MapAsNewEntity(this CreateRoomRequestModel model, Hotel hotel)
        {
            return new Room
            {
                Number = model.Number,
                Hotel = hotel
            };
        }

        public static Room MapAsNewEntity(this CreateRoomRequestModel2 model, Hotel hotel)
        {
            return new Room
            {
                Number = model.Number,
                Hotel = hotel
            };
        }

        public static RoomModel MapAsModel(this Room model)
        {
            return new RoomModel
            {
                Number = model.Number,
                Id = model.Id
            };
        }

        public static void UpdateWith(this Room room, UpdateRoomRequestModel model)
        {
            room.Number = model.Number;
        }
    }
}