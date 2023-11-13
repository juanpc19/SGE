using Ej1Tema7.Models.DAL;
using Ej1Tema7.Models.Entidades;

namespace Ej1Tema7.Models.ViewModels
{
   
    public class PersonaListaDep
    {
        #region atributos
        private clsPersona persona;
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        /// <summary>
        /// creo el constructor sin parametros con valor por defecto dado que es lo que necesito en este caso
        /// </summary>
        public PersonaListaDep() {

            //le doy valor de  clsListaDepartamentos.listadoCompletoDepartamentos();
            //si esta clase fuera de capa dal real tendria datos modificados diferentes?,
            //en este caso me devuelve la lista creada a mano
            this.listaDepartamentos = clsListaDepartamentos.listadoCompletoDepartamentos();
        }
       
        #endregion
        // propiedad get puede ser publica la set en principio debe ser privada
        //puedo usar esta propiedad para acceder a la propiedad Nombre de persona
        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }
           
        }
        
        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
           
        }
        #endregion

    }
}
