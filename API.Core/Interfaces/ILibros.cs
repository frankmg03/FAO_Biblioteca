namespace API.Core.Interfaces
{
    public interface ILibros
    {
        Task<bool> GuardarLibro(Modelos.Libros libros);
        Task<bool> EliminarLibro(Modelos.Libros libros);
        Task<bool> ActualizarLibro(Modelos.Libros libros);
        Task<List<Modelos.Libros>> ListarLibro();
    }
}