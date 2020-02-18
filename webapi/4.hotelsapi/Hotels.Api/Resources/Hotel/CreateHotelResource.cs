using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Api.Resources.Hotel
{
    public class CreateHotelResource
    {
        [Required]
        public string Name { get; set; }

        public string City { get; set; }
    }
}
