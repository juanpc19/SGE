using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL.Conexion;
using CapaEntidades;
using Newtonsoft.Json;

namespace CapaDAL.Listado
{
    public class clsListaPersonasDAL
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas extraido de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task <List<clsPersona>> listadoPersonasDAL()
        {
            clsMyUrlDAL urlDAL = new clsMyUrlDAL();//instancio clase url
            string miUrl = urlDAL.Url;//cojo valor url con get de objeto url
            Uri miUri = new Uri($"{miUrl}Personas");//creo uri igual a url+end point
            List<clsPersona> listadoPersonas = new List<clsPersona>();//creo lista a devolver
            HttpClient miClienteHttp= new HttpClient();//creo cliente que realizara mis peticiones a la API
            HttpResponseMessage miCodigoRespuesta;//guardara respuesta del servidor
            string jsonRecibido;//guardara json recibido en forma de cadena

            try
            {
                //recibo respuesta del servidor al intentar conectar a la uri
                miCodigoRespuesta = await miClienteHttp.GetAsync(miUri);
                //si el codigo respuesta es correcto
                if(miCodigoRespuesta.IsSuccessStatusCode)
                {
                    //guardo el json de la uri en forma de string
                    jsonRecibido = await miClienteHttp.GetStringAsync(miUri);
                    //me deshago del cliente para ahorra recursos
                    miClienteHttp.Dispose();
                    //doy a listaoPersonas valor igual a el json deserializado
                    //lo cual pasara la string previamente recibida (en formato diccionario o json)
                    //a una lista de personas
                    listadoPersonas=JsonConvert.DeserializeObject<List<clsPersona>>(jsonRecibido);  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoPersonas;
        }

 
      
    }
}
