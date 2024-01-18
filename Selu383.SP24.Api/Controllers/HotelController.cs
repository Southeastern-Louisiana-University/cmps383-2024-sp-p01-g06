using Microsoft.AspNetCore.Mvc;


namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("/api/hotels")]
    public class HotelController
    {
        [HttpGet]
        public int Get()
        {
            return 5;
        }

    }
}
