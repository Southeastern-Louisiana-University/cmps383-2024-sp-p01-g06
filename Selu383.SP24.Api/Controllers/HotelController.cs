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

           var last = HotelsList.LastOrDefault();

            if (last == null)
            {
                newHotel.Id = 0;
            }
            else
            {
                newHotel.Id = last.Id + 1;
            }

            HotelsList.Add(newHotel);

            //dataContext.SaveChanges();

            dto.Id = newHotel.Id;

            return dto;

        }

        [HttpDelete]//TODO
        [Route("{Id}")]
        public ActionResult<HotelDto> HotelDelete(int Id)
        {
            var HotelToRemove = HotelsList.FirstOrDefault(x => x.Id == Id);
            if (HotelToRemove == null)
            {
                return NotFound();
            }

            HotelsList.Remove(HotelToRemove);

            HotelDto dto = new HotelDto() { 
                Id = HotelToRemove.Id, 
                Name = HotelToRemove.Name, 
                Address = HotelToRemove.Address 
            };


            return dto;
        }

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<HotelDto> HotelChange(HotelDto dto, int Id)
        {

            var Hotel = HotelsList.FirstOrDefault(x => x.Id == Id);
            if (Hotel == null)
            {
                return NotFound();
            }

            Hotel.Name = dto.Name;
            Hotel.Address = dto.Address;

            

            dto.Id = Id;
            return dto;

        }
    }
}
