using CapaDAL.Listado;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
    public class clsManejadoraPersonaBL
    {

      /// <summary>
      /// funcion que mantendra la asincronia mientras pasa la persona creada en UI a la DAL tras aplicar reglas de negocio oportunas
      /// </summary>
      /// <param name="persona"></param>
      /// <returns></returns>
      public async Task crearPersonaBL(clsPersona persona)
        {
            //VIVIMOS EN UN MUNDO IDEAL OLÉ
            clsManejadoraPersonaDAL oDal = new clsManejadoraPersonaDAL();
            await oDal.crearPersonaDAL(persona);
        }

    }
}
