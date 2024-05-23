using API.Core.Interfaces;
using API.Modelos;

namespace API.Core.Servicios
{
    public class AutoresServicio : IAutores
    {
        public Task<bool> GuardarAutor(Autores autores)
        {
            bool resultado = false;
            
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from aut in conexion.Autores where aut.ID_Autor == autores.ID_Autor select aut
                    ).FirstOrDefault();

                if (consulta == null)
                {
                    Autores aut = new Autores();
                    aut.ID_Autor = autores.ID_Autor;
                    aut.Nombre = autores.Nombre;
                    aut.Apellidos = autores.Apellidos;
                    aut.Fecha_Nacimiento = autores.Fecha_Nacimiento;
                    aut.Nacionalidad = autores.Nacionalidad;
                    conexion.Autores.Add(aut);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarAutor(Autores autores)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from aut in conexion.Autores where aut.ID_Autor == autores.ID_Autor select aut)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Autores.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarAutor(Autores autores)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from aut in conexion.Autores where aut.ID_Autor == autores.ID_Autor select aut
                    ).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.ID_Autor = autores.ID_Autor;
                    consulta.Nombre = autores.Nombre;
                    consulta.Apellidos = autores.Apellidos;
                    consulta.Fecha_Nacimiento = autores.Fecha_Nacimiento;
                    consulta.Nacionalidad = autores.Nacionalidad;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Autores>> ListAutor()
        {
            List<Autores> lista = new List<Autores>();
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from c in conexion.Autores select c)
                    .ToList();

                foreach (var aut in consulta)
                {
                    lista.Add(new Autores()
                    {
                        ID_Autor = aut.ID_Autor,
                        Nombre = aut.Nombre,
                        Apellidos = aut.Apellidos,
                        Fecha_Nacimiento = aut.Fecha_Nacimiento,
                        Nacionalidad = aut.Nacionalidad,
                    });
                }

                return Task.FromResult(lista);

            }
        }

    }
}