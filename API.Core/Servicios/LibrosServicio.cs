using API.Core.Interfaces;
using API.Modelos;

namespace API.Core.Servicios
{
    public class LibrosServicio : ILibros
    {
        public Task<bool> GuardarLibro(Libros libros)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from lib in conexion.Libros where lib.ID_Libro == libros.ID_Libro select lib)
                    .FirstOrDefault();

                if (consulta == null)
                {
                    Libros lib = new Libros();
                    lib.ID_Libro = libros.ID_Libro;
                    lib.Titulo = libros.Titulo;
                    lib.ID_Autor = libros.ID_Autor;
                    lib.ID_Genero = libros.ID_Genero;
                    lib.Fecha_Publicacion = libros.Fecha_Publicacion;
                    lib.ISBN = libros.ISBN;
                    lib.Precio = libros.Precio;
                    lib.Stock = libros.Stock;
                    conexion.Libros.Add(lib);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarLibro(Libros libros)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from lib in conexion.Libros where lib.ID_Libro == libros.ID_Libro select lib)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Libros.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarLibro(Libros libros)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from lib in conexion.Libros where lib.ID_Libro == libros.ID_Libro select lib)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    consulta.ID_Libro = libros.ID_Libro;
                    consulta.Titulo = libros.Titulo;
                    consulta.ID_Autor = libros.ID_Autor;
                    consulta.ID_Genero = libros.ID_Genero;
                    consulta.Fecha_Publicacion = libros.Fecha_Publicacion;
                    consulta.ISBN = libros.ISBN;
                    consulta.Precio = libros.Precio;
                    consulta.Stock = libros.Stock;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Libros>> ListarLibro()
        {
            List<Libros> listaPlanes = new List<Libros>();
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from lib in conexion.Libros select lib)
                    .ToList();

                foreach (var lib in consulta)
                {
                    listaPlanes.Add(new Libros()
                    {
                        ID_Libro = lib.ID_Libro,
                        Titulo = lib.Titulo,
                        ID_Autor = lib.ID_Autor,
                        ID_Genero = lib.ID_Genero,
                        Fecha_Publicacion = lib.Fecha_Publicacion,
                        ISBN = lib.ISBN,
                        Precio = lib.Precio,
                        Stock = lib.Stock
                    });
                }

                return Task.FromResult(listaPlanes);

            }
        }

    }
}