using Microsoft.AspNetCore.Mvc;
using System;
using assign;
using System.Collections.Generic;
using System.Linq;

[ApiController]
	[Route(template: "api/[controller]")]
public class CityController: ControllerBase 
{
	//private ICityPriceRepo<CityPrice> _cityPriceRepo;
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
    public CityController()
	{
	}
    [HttpGet]
    public ActionResult<IEnumerable<CityPrice>> GetCities()
    {
        return _cityPrices;
    }
    //[HttpGet("{id}")]

    //public ActionResult<IEnumerable<CityPrice>> GetCities(int id)
    //{
    //    var city =  _cityPrices.FirstOrDefault(x => x.Id == id);
    //    if (city == null)
    //        return BadRequest(error: "Invalid city");
    //    return Ok(city);
    //}

    [HttpGet("{city}")]

    public ActionResult<IEnumerable<CityPrice>> GetCitiesByCity(string city)
    {
        var cityprice = _cityPrices.FirstOrDefault(x => x.City == city);
        if (city == null)
            return BadRequest(error: "Invalid city");
        return Ok(cityprice);
    }

    //[HttpGet]
    //public async Task<ActionResult<List<SuperHero>>> Get()
    //{
    //    return Ok(await _context.SuperHeroes.ToListAsync());
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<CityPrice>> Get(int id)
    //{
    //    var hero = await _context.SuperHeroes.FindAsync(id);
    //    if (hero == null)
    //        return BadRequest("Hero not found.");
    //    return Ok(hero);
    //}


}
