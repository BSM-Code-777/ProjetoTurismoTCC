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
        public DbSet<turismoTCC.Models.Viagem> Viagem { get; set; } = default!;
        public DbSet<turismoTCC.Models.Registro> Registro { get; set; } = default!;
        public DbSet<turismoTCC.Models.Localidade> Localidade { get; set; } = default!;
        public DbSet<turismoTCC.Models.Premium> Premium { get; set; } = default!;
        public DbSet<turismoTCC.Models.Parceria> Parceria { get; set; } = default!;
        public DbSet<turismoTCC.Models.Beneficio> Beneficio { get; set; } = default!;
    }   //////////////////////////////////////////////////////////////////////////////////////////
}