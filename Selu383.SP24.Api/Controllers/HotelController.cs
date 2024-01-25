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
        public ActionResult<HotelDto> HotelGetById(int Id)

        {   var Hotel = hotels.FirstOrDefault(x => x.Id == Id);
            if (Hotel == null)
            {
                return NotFound();
            }

            var dto = new HotelDto() {
                Id = Hotel.Id,
                Name = Hotel.Name,
                Address = Hotel.Address,
            };
            
            return dto;
        }

        [HttpGet]
        public IEnumerable<HotelDto> HotelGetAll()
        {
            var dtos = new List<HotelDto>();

            foreach (var hotel in hotels)
            {
                var dto = new HotelDto()
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Address = hotel.Address,
                };
                dtos.Add(dto);
            }
            return dtos;
        }

        [HttpPost]
        public ActionResult<HotelDto> HotelCreate(HotelCreateDto dtoToCreate)
        {

            if ((dtoToCreate.Name.Length > 120) || (dtoToCreate.Name.Length == 0)) { 
                return BadRequest();
            }

            if (dtoToCreate.Address.Length == 0) {
                return BadRequest();
            }


            var newHotel = new Hotel() { 
                Name = dtoToCreate.Name,
                Address = dtoToCreate.Address
            };


            hotels.Add(newHotel);

            dataContext.SaveChanges();
            
            return CreatedAtAction(nameof(HotelGetById), new { id = newHotel.Id }, newHotel);

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
