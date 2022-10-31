using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assign
{
    public class CityPriceRepo : ICityPriceRepo<CityPrice>
    {

        /*private readonly List<CityPrice> _cityPrices;*/
        public CityPriceRepo()
        {
        }

        private readonly List<CityPrice> _cityPrices = new List<CityPrice>()
        {
            new CityPrice()
            {
                Id = 1, City = "Stockholm", SquareMeter = 65, Balcony = 150, Window = 300
            },
           new CityPrice()
            {
                Id = 2, City = "Uppsala", SquareMeter = 55, Balcony = 100, Window = 250, Trash = 400
            }
        };

        public IEnumerable<CityPrice> GetAll()
        {
            return _cityPrices; 
        }

        public Task<CityPrice> GetByCity(string city, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CityPrice> GetById(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
