using Capa_Entidades;
using CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL
{
    public static class clsListadosBL
    {
        /// <summary>
        /// recibira listado de marcas de DAL y lo pasara a UI tras aplicarle reglas de negocio pertinentes
        /// </summary>
        /// <returns>listadoMarcas</returns>
        public static List<clsMarca> listadoMarcasBL()
        {
            List<clsMarca> listadoMarcas = clsListadosDAL.listadoMarcasDAL();

            return listadoMarcas;
        }

        /// <summary>
        /// recibira listado de modelos de DAL y lo pasara a UI tras aplicarle reglas de negocio pertinentes
        /// </summary>
        /// <returns>listadoModelos</returns>
        public static List<clsModelo> listadoModelosBL()
        {
            List<clsModelo> listadoModelos = clsListadosDAL.listadoModelosDAL();

            return listadoModelos;
        }

        /// <summary>
        /// recibira listado filtrado de modelos de DAL y lo pasara a UI tras aplicarle reglas de negocio pertinentes
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listadoModelosFiltrados</returns>
        public static List<clsModelo> listadoModelosbL(int id)
        {
            List<clsModelo> listadoModelosFiltrados = clsListadosDAL.obtenerListaModelosPorIdDAL(id);
            //logica busque con LINQ
            return listadoModelosFiltrados;
        }

        /// <summary>
        /// recibira string de DAL y la pasara a UI trasaplicarle reglas de negocio pertinentes
        /// </summary>
        /// <param name="id"></param>
        /// <returns>nombre</returns>
        public static string getNombreMarcaPorIdModeloBL(int id)
        {
            string nombre = clsListadosDAL.getNombreMarcaPorIdModeloDAL(id);
            return nombre;
        }
    }
}
