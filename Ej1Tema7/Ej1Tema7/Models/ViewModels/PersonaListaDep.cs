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
        
        }
        public PersonaListaDep(clsPersona persona, List<clsDepartamento> listaDepartamentos) {
            this.persona = persona;
            this.listaDepartamentos = listaDepartamentos;
        }
        #endregion

        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }
        #endregion
       





    }
}
