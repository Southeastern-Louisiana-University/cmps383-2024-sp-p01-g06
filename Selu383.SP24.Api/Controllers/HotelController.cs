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
        static List<Hotel> HotelsList = new List<Hotel>();

        //private readonly DbSet<Hotel> hotels;
        //private readonly DataContext dataContext;
        //private readonly ILogger<HotelController> _logger;

        //public HotelController(DbSet<Hotel> hotels, DataContext dataContext, ILogger<HotelController> logger)
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

            if ((dto.Name.Length > 120) || (dto.Name.Length == 0)) { 
                return BadRequest();
            }

            if (dto.Address.Length == 0) {
                return BadRequest();
            }


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

            return new ObjectResult(dto) { StatusCode = StatusCodes.Status201Created };

        }

        [HttpDelete]
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

            if ((dto.Name.Length > 120) || (dto.Name.Length == 0))
            {
                return BadRequest();
            }

            if (dto.Address.Length == 0)
            {
                return BadRequest();
            }


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
