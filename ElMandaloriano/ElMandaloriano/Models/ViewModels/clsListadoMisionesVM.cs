using ElMandaloriano.Models.DAL;
using ElMandaloriano.Models.Entities;

namespace ElMandaloriano.Models.ViewModels
{
    public class clsListadoMisionesVM : clsMision
    {
        //como hereda de clsMision ya contendra un objeto de su tipo con sus propiedades
        #region atributos
        private List<clsMision> listado;
        
        #endregion

        /// <summary>
        /// constructor sin param entrada que tendra valor default igual a listado devuelto 
        /// por metodo GetListadoMisiones de clase estatica clsListadoMisiones
        /// </summary>
        #region constructores
        public clsListadoMisionesVM() { 

            listado=clsListadoMisiones.GetListadoMisiones();
        }
        #endregion

        #region propiedades
        public List<clsMision> Listado
        {
            get { return listado; } 
        }

		 
		#endregion

	}
}
