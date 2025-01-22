using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // Define the GET route for the Merhaba action
        [HttpGet("merhaba")]
        public string Merhaba()
        {
            return "Merhaba";
        }
    }
}