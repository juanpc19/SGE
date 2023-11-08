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
        public PersonaListaDep() { 
        
            this.listaDepartamentos = clsListaDepartamentos.listadoCompletoDepartamentos();
        }
       
        #endregion

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



        //añadir funcion que devuelve objeto PersonaListaDep




    }
}
