using API.Core.Interfaces;
using API.Modelos;

namespace API.Core.Servicios
{
    public class GenerosServicio : IGeneros
    {
        public Task<bool> GuardarGenero(Generos generos)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from gen in conexion.Generos where gen.ID_Genero == generos.ID_Genero select gen)
                    .FirstOrDefault();

                if (consulta == null)
                {
                    Generos gen = new Generos();
                    gen.ID_Genero = generos.ID_Genero;
                    gen.Nombre = generos.Nombre;
                    conexion.Generos.Add(gen);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarGenero(Generos generos)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from gen in conexion.Generos where gen.ID_Genero == generos.ID_Genero select gen)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Generos.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarGenero(Generos generos)
        {
            bool resultado = false;
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                        from gen in conexion.Generos where gen.ID_Genero == generos.ID_Genero select gen)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    consulta.ID_Genero = generos.ID_Genero;
                    consulta.Nombre = generos.Nombre;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Generos>> ListarGenero()
        {
            List<Generos> listaMembresias = new List<Generos>();
            using (var conexion = new Data.DB.BaseDeDatos())
            {
                var consulta = (
                    from gen in conexion.Generos select gen)
                    .ToList();

                foreach (var gen in consulta)
                {
                    listaMembresias.Add(new Generos()
                    {
                        ID_Genero = gen.ID_Genero,
                        Nombre = gen.Nombre
                    });
                }

                return Task.FromResult(listaMembresias);

            }
        }

    }
}