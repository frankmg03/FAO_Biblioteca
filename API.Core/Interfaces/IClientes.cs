namespace API.Core.Interfaces
{
    public interface IClientes
    {
        Task<bool> GuardarCliente(Modelos.Clientes clientes);
        Task<bool> EliminarCliente(Modelos.Clientes clientes);
        Task<bool> ActualizarCliente(Modelos.Clientes clientes);
        Task<List<Modelos.Clientes>> ListarCliente();
    }
}