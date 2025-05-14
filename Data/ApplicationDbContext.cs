using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using turismoTCC.Models;

namespace turismoTCC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {   ////////////////////////////////////////////////////////////////////////////////////////
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<turismoTCC.Models.Sugestao> Sugestao { get; set; } = default!;
    }   //////////////////////////////////////////////////////////////////////////////////////////
}