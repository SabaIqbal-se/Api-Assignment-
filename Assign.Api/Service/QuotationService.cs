using Assign.Api.Data;
using Assign.Api.DTO;
using Assign.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace Assign.Api.Service
{
    public class QuotationService : IQuotationService
    {
        private readonly DataContext _context;

        public QuotationService(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<City>> GetAllCities()
        {

            return await(_context.Cities.ToListAsync());
        }
        public async Task<List<Extras>> GetExtrasbyCityId(int id)
        {
            var city = await _context.Cities.Where(c => c.CityId == id)
                .Include(x => x.CityExtras)
                .ThenInclude(y => y.Extras)
                .SelectMany(a => a.CityExtras)
                 .Select(a => a.Extras).ToListAsync();

            return city;

        }
        public async Task<IQueryable> GetQuotation(int CityId, int squareMeter, string extras)
        {
            List<int> extraIds =  extras.Split(',').Select(int.Parse).ToList();
            var query = 
                    from a in _context.Cities
                    from b in a.CityExtras
                    where a.CityId == CityId && extraIds.Contains(b.ExtrasId)
                    group new { a, b } by new { a.PricePerSqM , a.Name, a.CityId } into g 
                    select new 
                    {
                        City = g.Key.Name,
                        PricePerSqM = g.Key.PricePerSqM,
                        TotalPrice = g.Sum(x => x.b.Price) + g.Key.PricePerSqM * squareMeter
                    };
            return query;
        }
    }
}
