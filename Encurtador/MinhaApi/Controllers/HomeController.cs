using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;


namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/{urlShorted}")]
        public IActionResult GetByUrl(
            [FromRoute] string urlShorted,
            [FromServices] AppDbContext context
        )
        {
            var link = context.Link.Where(l => l.urlShorted == urlShorted).FirstOrDefault();

            Console.Write(link);
            if (link == null)
            {
                return Redirect("/");
            }
            else
            {
                return Redirect(link.url);
            }
        }
        [HttpPost("/link")]
        public IActionResult Post(
         [FromBody] LinksModel link,
         [FromServices] AppDbContext context)
        {
            var urlShorted = ReplaceLink(link.url);


            link.urlShorted = urlShorted;
            context.Link.Add(link);
            context.SaveChanges();

            return Created($"/{urlShorted}", link);
        }

        static string ReplaceLink(string linkFormated)
        {
            var generator = new RandomString();
            var replacedUrl = generator.GenerateString(6);

            linkFormated = replacedUrl;

            return linkFormated;
        }
    }
}