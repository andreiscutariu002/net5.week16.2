namespace Hotels.Api.Extensions.Map
{
    using Data.Entities;
    using Models.Hotels;

    public static class HotelExtensions
    {
        public static Hotel MapAsNewEntity(this CreateHotelResource model)
        {
            return new Hotel
            {
                Name = model.Name,
                City = model.City
            };
        }

        public static HotelResource MapAsModel(this Hotel model)
        {
            return new HotelResource
            {
                Name = model.Name,
                City = model.City,
                Id = model.Id
            };
        }

        public static void UpdateWith(this Hotel room, UpdateHotelResource model)
        {
            room.City = model.City;
        }
    }
}
