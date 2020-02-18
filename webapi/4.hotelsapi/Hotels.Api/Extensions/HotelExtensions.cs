using Hotels.Api.Data.Entities;
using Hotels.Api.Resources.Hotel;

namespace Hotels.Api.Extensions
{
    public static class HotelExtensions
    {
        public static Hotel MapAsEntity(this CreateHotelResource resource)
        {
            return new Hotel
            {
                City = resource.City,
                Name = resource.Name
            };
        }

        public static HotelResource MapAsResource(this Hotel entity)
        {
            return new HotelResource
            {
                City = entity.City,
                Name = entity.Name,
                Id =  entity.Id
            };
        }
    }
}
