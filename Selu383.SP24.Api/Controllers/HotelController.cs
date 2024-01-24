using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Entities;
using Selu383.SP24.Api.Data;
using Microsoft.EntityFrameworkCore;


namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("/api/hotels")]
    public class HotelController : ControllerBase
    {
        static List<Hotel> HotelsList = new List<Hotel>();

        //private readonly DbSet<Hotel> hotels;
        //private readonly DataContext dataContext;
        //private readonly ILogger<WeatherForecastController> _logger;

        //public HotelController(DbSet<Hotel> hotels, DataContext dataContext, ILogger<WeatherForecastController> logger)
        //{
        //    this.hotels = hotels;
        //    this.dataContext = dataContext;
        //    _logger = logger;
        //}

        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Hotel> HotelGetById(int Id)
        {
            var Hotel = HotelsList.FirstOrDefault(x => x.Id == Id);
            if (Hotel == null)
            {
                return NotFound();
            }
            return Hotel;
        }

        [HttpGet]
        public IEnumerable<Hotel> HotelGetAll()
        {
            return HotelsList;
        }

        [HttpPost]
        public ActionResult<HotelDto> HotelCreate(HotelDto dto)
        {
            var newHotel = new Hotel();
            newHotel.Name = dto.Name;
            newHotel.Address = dto.Address;

            newHotel.Id = dto.Id;

            HotelsList.Add(newHotel);

            //dataContext.SaveChanges();

            dto.Id = newHotel.Id;

            return dto;

        }

        [HttpDelete]//TODO
        [Route("{Id}")]
        public ActionResult<HotelDto> HotelDelete(int Id)
        {
            return StatusCode(500);

        }

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<HotelDto> HotelChange(HotelDto dto, int Id)
        {
            return StatusCode(500);


        }
    }
}
