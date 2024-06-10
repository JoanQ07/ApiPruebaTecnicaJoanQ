using Microsoft.EntityFrameworkCore;
using ruleta_api.Models;

namespace ruleta_api.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}