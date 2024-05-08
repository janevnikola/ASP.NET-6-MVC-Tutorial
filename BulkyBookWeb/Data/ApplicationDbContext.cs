using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> _DbOptions) :base(_DbOptions)
        {

        }
        public DbSet<Category> Categories { get; set; } //ova ke kreira tabela vo databazata, narecena Categories

    }
}
