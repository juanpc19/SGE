using CapaDAL.Listados;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Listados
{
    public class clsListaMarcasBL
    {
        
        public static List<clsMarca> ListadoMarcasBl()
        {
            
            List<clsMarca>listado = clsListaMarcasDAL.ListadoMarcasDAL();

            return listado;
        }

    }
}
