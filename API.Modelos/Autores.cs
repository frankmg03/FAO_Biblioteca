using System.ComponentModel.DataAnnotations;

namespace API.Modelos
{
    public class Autores
    {
        [Key]
        public int ID_Autor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
    }
}