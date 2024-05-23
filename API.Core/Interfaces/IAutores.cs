namespace API.Core.Interfaces
{
    public interface IAutores
    {
        Task<bool> GuardarAutor(Modelos.Autores autores);
        Task<bool> EliminarAutor(Modelos.Autores autores);
        Task<bool> ActualizarAutor(Modelos.Autores autores);
        Task<List<Modelos.Autores>> ListAutor();
    }    
}

