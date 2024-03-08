using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosUebung_Autor.Data;
using PosUebung_Autor.Models;
using System.Diagnostics;

namespace PosUebung_Autor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var autoren = _context.Autors.Include(autoren => autoren.Books).ToList();
            return View(autoren);
        }
        public IActionResult CreateAutorForm()
        {
            return View();
        }

        public IActionResult CreateAutor(Autor autor)
        {
            _context.Autors.Add(autor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBookForm(int? id)
        {
            if(id is not null && id>0)
            {
                var autorenFromDb = _context.Autors.FirstOrDefault(s=>s.Id == id);
                if (autorenFromDb is not null)
                {
                    Buch book = new();
                    book.AutorId = id;
                    return View(book);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBook(Buch book)
        {
            if(book.AutorId is not null && book.AutorId > 0)
            {
                Autor? autorFromDb = _context.Autors.FirstOrDefault(x => x.Id == book.AutorId);

                if(autorFromDb is not null)
                {
                    List<string> genres = book.Genres[0].Split(",").ToList();
                    book.Genres = genres;

                    autorFromDb.Books.Add(book);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteAuthor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var authorFromDB = _context.Autors.Include(author => author.Books).FirstOrDefault(m => m.Id == id);
            if (authorFromDB is null)
            {
                return NotFound();
            }
            _context.Autors.Remove(authorFromDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
