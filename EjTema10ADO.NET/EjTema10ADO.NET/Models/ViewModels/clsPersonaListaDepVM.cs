using CapaBL.Listado;
using CapaDAL.Listado;
using CapaEntidades;

namespace EjTema10ADO.NET.Models.ViewModels
{
    public class clsPersonaListaDepVM
    {

        #region atributos
        private clsPersona persona;
        private List<clsDepartamento> listaDep;
        private List<clsPersona> listaPersonas;
        #endregion

        #region construtores
        public clsPersonaListaDepVM()
        {
            persona = new clsPersona();
            listaDep = clsListaDepBL.listadoDepartamentosBL();
            listaPersonas= clsListaPersonasBL.listadoPersonasBL();
        }

        public clsPersonaListaDepVM(clsPersona persona, List<clsDepartamento> listaDep)
        {
            this.persona = persona;
            this.listaDep = listaDep;
        }

        public clsPersonaListaDepVM(List<clsDepartamento> listaDep, List<clsPersona> listaPersonas)
        {
            this.listaDep = listaDep;
            this.listaPersonas = listaPersonas;
        }

        #endregion

        #region propiedades

        public clsPersona Persona { get { return persona; } set {  persona = value; } } 
        public List<clsDepartamento> ListaDep { get { return listaDep; } set { listaDep = value; } }
        public List<clsPersona> ListaPersonas { get { return listaPersonas; } set { listaPersonas = value; } }
        #endregion
    }
}
