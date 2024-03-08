using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PosUebung_Autor.Data;
using PosUebung_Autor.Models;

namespace PosUebung_Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Fill")]
        public void FillData()
        {
            Autor autor = new Autor() { Name = "Haramdin", Age = 19, Description = "Haramdin is haramdin" };
            Buch b1 = new Buch() { Title = "Haramdins Krankenhausbesuch", Genres = new List<string>{ "Tod", "Mord", "Ebola" }, Pages = 69, Stars = 5 };
            Buch b2 = new Buch() { Title = "Haramdins Klobesuch", Genres = new List<string>{ "Gestank", "Würgen", "Ersticken" }, Pages = 88, Stars = 4 };

            Autor autor2 = new Autor() { Name = "Haramdin2", Age = 20, Description = "Haramdin2 is haramdin2" };
            Buch b3 = new Buch() { Title = "Haramdins Insel", Genres = new List<string> { "Hohohodin", "Halaldin", "Haramdin" }, Pages = 420, Stars = 2 };
            Buch b4 = new Buch() { Title = "Haramdins Java ist", Genres = new List<string> { "Java", "Insel", "tohl" }, Pages = 18, Stars = 1 };

            autor.Books.Add(b1);
            autor.Books.Add(b2);

            autor2.Books.Add(b3);
            autor2.Books.Add(b4);

            _context.Autors.Add(autor);
            _context.Autors.Add(autor2);
            _context.SaveChanges();
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Autor> GetAutors()
        {
            var autors = _context.Autors.Include(a => a.Books).ToList();
            return autors;
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var authorFromDB = _context.Autors.SingleOrDefault(x => x.Id == id);
            if (authorFromDB is null)
            {
                return NotFound();
            }
            _context.Autors.Remove(authorFromDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
