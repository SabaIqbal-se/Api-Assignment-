using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace assign
{

    public interface ICityPriceRepo<CityPrice>
    {
        public IEnumerable<CityPrice> GetAll();
        Task<CityPrice> GetByCity(string city, CancellationToken cancellationToken = default);
        Task<CityPrice> GetById(string id, CancellationToken cancellationToken = default);


    }
}
