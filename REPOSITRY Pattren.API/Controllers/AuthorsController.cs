using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositry_Pattern.core;

namespace REPOSITRY_Pattren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly Ibaserepositry<Author> _authorsrepositry;

        public AuthorsController(Ibaserepositry<Author> authorsrepositry)
        {
            _authorsrepositry = authorsrepositry;
        }

        [HttpGet]
        public IActionResult Getbyid(int id)
        {
            return Ok(_authorsrepositry.getbyid(1));
        }

            [HttpGet("getbyidasync")]
            public async Task<IActionResult> getbyidasync(int id)
            {
                return Ok(await _authorsrepositry.getbyidasync(1));


            }
        }
    }
