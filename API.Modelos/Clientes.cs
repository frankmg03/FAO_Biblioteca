using System.ComponentModel.DataAnnotations;

namespace API.Modelos
{
    public class Clientes
    {   
        [Key]
        public int ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo_Electronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}