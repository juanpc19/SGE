using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public static class clsListadosDAL
    {
        /// <summary>
        /// creara y devolvera listado de marcas con datos simulados
        /// </summary>
        /// <returns>listadoMarcas</returns>
        public static List<clsMarca> listadoMarcasDAL()
        {
            List<clsMarca> listadoMarcas = new List<clsMarca>();

            return listadoMarcas;
        }

        /// <summary>
        /// creara y devolvera listado de modelos con datos simulados
        /// </summary>
        /// <returns>listadoModelos</returns>
        public static List<clsModelo> listadoModelosDAL()
        {
            List<clsModelo> listadoModelos = new List<clsModelo>();

            return listadoModelos;
        }

        /// <summary>
        /// devolvera listado de modelos de marca igual a la proporcionada como param entrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listadoModelosFiltrados</returns>
        public static List<clsModelo> obtenerListaModelosPorIdDAL(int id)
        {
            List<clsModelo> listadoModelosFiltrados = new List<clsModelo>();
            //logica busqueda con LINQ
            return listadoModelosFiltrados;
        }

        /// <summary>
        /// devolvera el nombre de la marca asociado al idMarca del modelo cuya id sera recibida como param entrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>nombre</returns>
        public static string getNombreMarcaPorIdModeloDAL(int id)
        {
            string nombre = "";
            //logica busqueda con LINQ 
            return nombre;
        }

    }
}
