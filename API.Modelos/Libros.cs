using System.ComponentModel.DataAnnotations;

namespace API.Modelos
{
    public class Libros
    {
        [Key]
        public int ID_Libro { get; set; }
        public string Titulo { get; set; }
        public int ID_Autor { get; set; }
        public int ID_Genero { get; set; }
        public DateTime Fecha_Publicacion { get; set; }
        public string ISBN { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}