using API.Helper;
using API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DB
{
    public class BaseDeDatos : DbContext
    {
        public virtual DbSet<Autores> Autores { get; set; }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
    
        public virtual DbSet<Generos> Generos { get; set; }
        
        public virtual DbSet<Libros> Libros { get; set; }
        
        public virtual DbSet<Prestamos> Prestamos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuracion.CadenaConexxion,
                    builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
            }
        }
    }
}