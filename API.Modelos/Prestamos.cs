using System.ComponentModel.DataAnnotations;

namespace API.Modelos
{
    public class Prestamos
    {
        [Key]
        public int ID_Prestamo { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Libro { get; set; }
        public DateTime Fecha_Prestamo { get; set; }
        public DateTime? Fecha_Devolucion { get; set; }
        public bool Devuelto { get; set; }
    }
}