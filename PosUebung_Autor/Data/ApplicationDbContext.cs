using Microsoft.EntityFrameworkCore;
using PosUebung_Autor.Models;

namespace PosUebung_Autor.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DBSet
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Buch> Books { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
