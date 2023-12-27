using LocadoraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Models
{
    public class BdContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;DataBase=LocadoraAPI;Uid=root;Pwd=;",
                new MySqlServerVersion(new Version(10, 4, 24))
            );
        }

        public DbSet<Filme> Filmes {get; set;}
        public DbSet<Locacao> Locacaos {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}