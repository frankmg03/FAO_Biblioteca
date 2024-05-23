using API.Core.Interfaces;
using API.Modelos;

namespace API.Core.Servicios
{
    public class PrestamosServicio : IPrestamos
    {
        public Task<bool> GuardarPrestamo(Prestamos prestamos)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from pmos in conexion.Prestamos where pmos.ID_Prestamo == prestamos.ID_Prestamo select pmos)
                    .FirstOrDefault();

                if (consulta == null)
                {
                    Prestamos pmos = new Prestamos();
                    pmos.ID_Prestamo = prestamos.ID_Prestamo;
                    pmos.ID_Cliente = prestamos.ID_Cliente;
                    pmos.ID_Libro = prestamos.ID_Libro;
                    pmos.Fecha_Prestamo = prestamos.Fecha_Prestamo;
                    pmos.Fecha_Devolucion = prestamos.Fecha_Devolucion;
                    pmos.Devuelto = prestamos.Devuelto;
                    conexion.Prestamos.Add(pmos);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarPrestamo(Prestamos prestamos)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from pmos in conexion.Prestamos where pmos.ID_Libro == prestamos.ID_Libro select pmos)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Prestamos.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarPrestamo(Prestamos prestamos)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (from pmos in conexion.Prestamos where pmos.ID_Libro == prestamos.ID_Libro select pmos)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    consulta.ID_Libro = prestamos.ID_Libro;
                    consulta.ID_Cliente = prestamos.ID_Cliente;
                    consulta.ID_Libro = prestamos.ID_Libro;
                    consulta.Fecha_Prestamo = prestamos.Fecha_Prestamo;
                    consulta.Fecha_Devolucion = prestamos.Fecha_Devolucion;
                    consulta.Devuelto = prestamos.Devuelto;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Prestamos>> ListarPrestamos()
        {
            List<Prestamos> listaPlanes = new List<Prestamos>();
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (from pmos in conexion.Prestamos select pmos).ToList();

                foreach (var pmos in consulta)
                {
                    listaPlanes.Add(new Prestamos()
                    {
                        ID_Prestamo = pmos.ID_Prestamo,
                        ID_Cliente = pmos.ID_Cliente,
                        ID_Libro = pmos.ID_Libro,
                        Fecha_Prestamo = pmos.Fecha_Prestamo,
                        Fecha_Devolucion = pmos.Fecha_Devolucion,
                        Devuelto = pmos.Devuelto
                    });
                }

                return Task.FromResult(listaPlanes);

            }
        }

    }
}