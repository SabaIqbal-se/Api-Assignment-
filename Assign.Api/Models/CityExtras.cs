using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign.Api.Models
{
    public class CityExtras
    {

        public int CityId { get; set; }
        public City City { get; set; }
        public Extras Extras { get; set; }
        public int ExtrasId { get; set; }
        public int Price { get; set; }

    }
}
