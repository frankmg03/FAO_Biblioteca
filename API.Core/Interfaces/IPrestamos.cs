namespace API.Core.Interfaces;

public interface IPrestamos
{
    Task<bool> GuardarPrestamo(Modelos.Prestamos prestamos);
    Task<bool> EliminarPrestamo(Modelos.Prestamos prestamos);
    Task<bool> ActualizarPrestamo(Modelos.Prestamos prestamos);
    Task<List<Modelos.Prestamos>> ListarPrestamos();
}