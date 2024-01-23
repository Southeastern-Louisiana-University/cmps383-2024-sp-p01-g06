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

        private readonly DbSet<Hotel> hotels;
        private readonly DataContext dataContext;

        public HotelController(DbSet<Hotel> hotels, DataContext dataContext)
        {
            this.hotels = hotels;
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("/{Id}")]
        public int HotelGetById(int Id)
        {
            return 5;
        }

        [HttpGet]
        public int HotelGetAll()
        {
            return 5;
        }

        [HttpPost]
        public ActionResult<HotelDto> HotelCreate(HotelDto dto)
        {
            var newHotel = new Hotel();
            newHotel.Name = dto.Name;
            newHotel.Address = dto.Address;

            hotels.Add(newHotel);

            dataContext.SaveChanges();

            dto.Id = newHotel.Id;

            return dto;

        }

    }
}
