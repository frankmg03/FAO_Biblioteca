using API.Core.Interfaces;
using API.Modelos;

namespace API.Core.Servicios
{
    public class ClientesServicio : IClientes
    {
        public Task<bool> GuardarCliente(Clientes clientes)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from cli in conexion.Clientes where cli.ID_Cliente == clientes.ID_Cliente select cli).
                    FirstOrDefault();

                if (consulta == null)
                {
                    Clientes cli = new Clientes();
                    cli.ID_Cliente = clientes.ID_Cliente;
                    cli.Nombre = clientes.Nombre;
                    cli.Apellidos = clientes.Apellidos;
                    cli.Correo_Electronico = clientes.Correo_Electronico;
                    cli.Telefono = clientes.Telefono;
                    cli.Direccion = clientes.Direccion;
                    conexion.Clientes.Add(cli);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarCliente(Clientes clientes)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from cli in conexion.Clientes where cli.ID_Cliente == clientes.ID_Cliente select cli)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Clientes.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);        
        }

        public Task<bool> ActualizarCliente(Clientes clientes)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from cli in conexion.Clientes where cli.ID_Cliente == clientes.ID_Cliente select cli
                ).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.ID_Cliente = clientes.ID_Cliente;
                    consulta.Nombre = clientes.Nombre;
                    consulta.Apellidos = clientes.Apellidos;
                    consulta.Correo_Electronico = clientes.Correo_Electronico;
                    consulta.Telefono = clientes.Telefono;
                    consulta.Direccion = clientes.Direccion;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);        
        }

        public Task<List<Clientes>> ListarCliente()
        {
            List<Clientes> listaClientes = new List<Clientes>();
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from cli in conexion.Clientes select cli)
                    .ToList();

                foreach (var cli in consulta)
                {
                    listaClientes.Add(new Clientes()
                    {
                        ID_Cliente = cli.ID_Cliente,
                        Nombre = cli.Nombre,
                        Apellidos = cli.Apellidos,
                        Correo_Electronico = cli.Correo_Electronico,
                        Telefono = cli.Telefono,
                        Direccion = cli.Direccion
                    });
                }
            
                return Task.FromResult(listaClientes);
            }        
        }
    }    
}
