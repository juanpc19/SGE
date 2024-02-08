using CapaDAL.Listados;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listados
{
    public class clsListaModelosBL
    {
        public static List<clsModelo> ListadoModelosBL()
        {
            List<clsModelo> listado = clsListaModelosDAL.ListadoModelosDAL();

            return listado;

        }
    }
}
