using Assign.Api.Models;

namespace Assign.Api.Service
{
    public interface IQuotationService
    {
        public Task<List<City>> GetAllCities();
        public Task<List<Extras>> GetExtrasbyCityId(int id);
        public Task<IQueryable> GetQuotation(int CityId, int squareMeter, string extras);



    }
}
