using System.ComponentModel.DataAnnotations;

namespace API.Modelos
{
    public class Generos
    {   [Key]
        public int ID_Genero { get; set; }
        public string Nombre { get; set; }
    }
}