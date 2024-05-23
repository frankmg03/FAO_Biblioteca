namespace API.Core.Interfaces
{
    public interface IGeneros
    {
        Task<bool> GuardarGenero(Modelos.Generos generos);
        Task<bool> EliminarGenero(Modelos.Generos generos);
        Task<bool> ActualizarGenero(Modelos.Generos generos);
        Task<List<Modelos.Generos>> ListarGenero();
    }
}