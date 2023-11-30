using Capa_Entidades;
using CapaBL;

namespace JuanPerezCaballeroExamenSGE.Models.ViewModels
{
    public class ListadosMarcasListadoModelosVM
    {

        #region atributos
        List<clsMarca> listadoMarcas;
        List<clsModelo> listadoModelos;
        #endregion

        #region constructores
        public ListadosMarcasListadoModelosVM()
        {
            listadoMarcas = clsListadosBL.listadoMarcasBL();
            listadoModelos= clsListadosBL.listadoModelosBL();
        }

        public ListadosMarcasListadoModelosVM(List<clsMarca> listadoMarcas, List<clsModelo> listadoModelos)
        {
            this.listadoMarcas = listadoMarcas;
            this.listadoModelos = listadoModelos;
        }
        #endregion

        #region propiedades
        public List<clsMarca> ListadoMarcas { get { return listadoMarcas;} set { listadoMarcas = value; } }
        public List<clsModelo> ListadoModelos { get { return listadoModelos; } set { listadoModelos = value; } }
        #endregion
    }
}
