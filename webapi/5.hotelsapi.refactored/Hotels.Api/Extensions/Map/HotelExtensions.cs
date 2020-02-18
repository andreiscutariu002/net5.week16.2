using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Data.Entities;
using Hotels.Models.Hotels;

namespace Hotels.Api.Extensions.Map
{
    public static class HotelExtensions
    {
        public static Hotel MapAsNewEntity(this CreateHotelRequestModel model)
        {
            return new Hotel
            {
                Name = model.Name,
                City = model.City
            };
        }

        public static HotelModel MapAsModel(this Hotel model)
        {
            return new HotelModel
            {
                Name = model.Name,
                City = model.City,
                Id = model.Id
            };
        }
    }
}
