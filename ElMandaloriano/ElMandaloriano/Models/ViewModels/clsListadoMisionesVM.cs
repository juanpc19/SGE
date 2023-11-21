using ElMandaloriano.Models.DAL;
using ElMandaloriano.Models.Entities;

namespace ElMandaloriano.Models.ViewModels
{
    public class clsListadoMisionesVM
    {
        
        #region atributos
        private List<clsMision> listado;
        private clsMision mision;
        #endregion

        /// <summary>
        /// constructor sin param entrada que tendra listado con valor igual a listado devuelto 
        /// por metodo GetListadoMisiones de clase estatica clsListadoMisiones
        /// </summary>
        #region constructores
        public clsListadoMisionesVM() { 

            listado=clsListadoMisiones.GetListadoMisiones();
        }

		/// <summary>
		/// constructor con param entrada que tendra listado con valor igual a listado devuelto 
		/// por metodo GetListadoMisiones de clase estatica clsListadoMisiones y mision con valor igual a la mision pasada como param entrada
		/// </summary>
		public clsListadoMisionesVM(clsMision mision)
		{
            this.mision = mision;
			listado = clsListadoMisiones.GetListadoMisiones();
		}
		#endregion

		#region propiedades
		public List<clsMision> Listado
        {
            get { return listado; } 
        }

		public clsMision Mision
		{
			get { return mision; }
            set { mision = value; }
		}
		#endregion

        
		#region metodos
        /// <summary>
        /// metodo que devolvera el primer elemento de la lista cuyo id conincida con el dado como param entrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public clsMision GetMisionSeleccionada(int id)
		{
			return listado.FirstOrDefault(m => m.Id == id);
		}
		#endregion
	}
}
