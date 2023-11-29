using CapaDAL.Listado;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listado
{
    public static class clsListaDepBL
    {

        public static List<clsDepartamento> listadoDepartamentosBL()
        {
            List<clsDepartamento> listado = clsListaDepDAL.listadoDepartamentosDAL();

            return listado;
        }
    }
}
