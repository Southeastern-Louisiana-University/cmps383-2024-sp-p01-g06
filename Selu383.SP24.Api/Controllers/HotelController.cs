using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Entities;
using Selu383.SP24.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("/api/hotels")]
    public class HotelController : ControllerBase
    {
        //static List<Hotel> hotels = new List<Hotel>();

        private readonly DbSet<Hotel> hotels;
        private readonly DataContext dataContext;
        private readonly ILogger<HotelController> _logger;

        public HotelController(DataContext dataContext, ILogger<HotelController> logger)
        {
            this.dataContext = dataContext;
            _logger = logger;
            hotels = dataContext.Hotels;
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Hotel> HotelGetById(int Id)
        {
            var Hotel = hotels.FirstOrDefault(x => x.Id == Id);
            if (Hotel == null)
            {
                return NotFound();
            }
            return Hotel;
        }

        [HttpGet]
        public IEnumerable<Hotel> HotelGetAll()
        {
            return hotels;
        }

        [HttpPost]
        public ActionResult<HotelDto> HotelCreate(HotelDto dto)
        {

            if ((dto.Name.Length > 120) || (dto.Name.Length == 0)) { 
                return BadRequest();
            }

            if (dto.Address.Length == 0) {
                return BadRequest();
            }


            var newHotel = new Hotel();
            newHotel.Name = dto.Name;
            newHotel.Address = dto.Address;

            hotels.Add(newHotel);


            dto.Id = newHotel.Id;
            dataContext.SaveChanges();

            return new ObjectResult(dto) { StatusCode = StatusCodes.Status201Created };

        }

        [HttpDelete]
        [Route("{Id}")]
        public ActionResult<HotelDto> HotelDelete(int Id)
        {
            var HotelToRemove = hotels.FirstOrDefault(x => x.Id == Id);
            if (HotelToRemove == null)
            {
                return NotFound();
            }

            hotels.Remove(HotelToRemove);

            HotelDto dto = new HotelDto() { 
                Id = HotelToRemove.Id, 
                Name = HotelToRemove.Name, 
                Address = HotelToRemove.Address 
            };

            dataContext.SaveChanges();
            return dto;
        }

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<HotelDto> HotelChange(HotelDto dto, int Id)
        {

            if ((dto.Name.Length > 120) || (dto.Name.Length == 0))
            {
                return BadRequest();
            }

            if (dto.Address.Length == 0)
            {
                return BadRequest();
            }


            var Hotel = hotels.FirstOrDefault(x => x.Id == Id);
            if (Hotel == null)
            {
                return NotFound();
            }

            Hotel.Name = dto.Name;
            Hotel.Address = dto.Address;

            

            dto.Id = Id;
            dataContext.SaveChanges();
            return dto;

        }
    }
}
