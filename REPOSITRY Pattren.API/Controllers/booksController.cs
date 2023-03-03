using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositry_Pattern.core;
using Repositry_Pattern.core.consts;

namespace REPOSITRY_Pattren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {

        private readonly Ibaserepositry<book> _booksrepositry;

        public booksController(Ibaserepositry<book> booksrepositry)
        {
            _booksrepositry = booksrepositry;
        }

        [HttpGet]
        public IActionResult Getbyid(int id)
        {
            return Ok(_booksrepositry.getbyid(1));

        }
        [HttpGet("getall")]
        public IActionResult getall(int id)
        {
            return Ok(_booksrepositry.getall());

        }

        [HttpGet("getbyname")]
        public IActionResult getbyname(int id)
        {
            return Ok(_booksrepositry.Find(t => t.title == "net", new[] {"authors"}));

        }
        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_booksrepositry.Findall(t => t.title.Contains("net"), new[] { "authors" }));
        }
        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_booksrepositry.Findall(b => b.title.Contains("net"), null, null, t => t.id, orderdby.Descending));
        }
        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _booksrepositry.Add(new book { title = "Test 4", authorid = 1 });
          
            return Ok(book);
        }

    }
}
