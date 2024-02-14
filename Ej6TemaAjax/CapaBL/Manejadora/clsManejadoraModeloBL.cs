using CapaDAL.Manejadora;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Manejadora
{
    public class clsManejadoraModeloBL
    {
        public static int editModeloBL(clsModelo modelo)
        {
            int numeroFilasAfectadas;

            numeroFilasAfectadas=clsManejadoraModeloDAL.editModeloDAL(modelo);

            return numeroFilasAfectadas;
        }
    }
}
