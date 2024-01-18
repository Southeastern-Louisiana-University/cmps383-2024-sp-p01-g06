using Microsoft.AspNetCore.Mvc;


namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("/api/hotels")]
    public class HotelController : ControllerBase
    {
        [HttpGet]
        public int HotelGet()
        {
            return 5;
        }

    }
}
