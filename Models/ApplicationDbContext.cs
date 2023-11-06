using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AtletaBackend.Models;

namespace AtletaApi.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Atleta> Atletas { get; set; } = null!;
        public DbSet<AtletaRecord> AtletasRecords { get; set; } = null!;
        public DbSet<Treinador> Treinadores { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            options.UseSqlite($"Data Source={System.IO.Path.Join(path, "atleta.db")}");
        }
    }
}