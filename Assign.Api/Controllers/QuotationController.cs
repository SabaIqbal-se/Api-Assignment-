using Assign.Api.DTO;
using Assign.Api.Models;
using Assign.Api.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assign.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationController : ControllerBase
    {
        
        private readonly IQuotationService quotationService;
        private readonly IMapper _mapper;

        public QuotationController(IQuotationService cityPriceService, IMapper mapper)
        {
            this.quotationService = cityPriceService;
            this._mapper = mapper;
        }


        [HttpGet(Name = "GetAllCities")]
        public async Task<IActionResult> Get()
        {

            var cities = await quotationService.GetAllCities();
            if (cities.Any())
            {
                return Ok(_mapper.Map<IEnumerable<CityDTO>>(cities));
            }
            return NotFound();

        }

        //    [HttpGet(Name = "GetExtras")]
        [HttpGet("Cityid")]
        public async Task<IActionResult> GetById(int Cityid)
        {
          var cityExtras = await quotationService.GetExtrasbyCityId(Cityid);
            if (cityExtras.Any())
            {
            return Ok(_mapper.Map<IEnumerable<ExtrasDTO>> (cityExtras));
            }
            return NotFound();

        }

        [HttpGet("{CityId}/{SquareMeters}/{Extras}")]
        public async Task<IActionResult> GetQuotation(int CityId,int SquareMeters, string Extras)
        {
            var qutation = await quotationService.GetQuotation(CityId, SquareMeters, Extras);
               return Ok(qutation);

        }

    }
}