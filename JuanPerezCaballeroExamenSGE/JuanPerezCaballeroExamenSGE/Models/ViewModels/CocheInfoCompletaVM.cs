using Capa_Entidades;

namespace JuanPerezCaballeroExamenSGE.Models.ViewModels
{
    public class CocheInfoCompletaVM
    {
        #region atributos
        clsMarca marca;
        clsModelo modelo;
        #endregion

        #region constructores
        public CocheInfoCompletaVM (){
            marca = new clsMarca();
            modelo = new clsModelo();
        }

        public CocheInfoCompletaVM(clsMarca marca, clsModelo modelo)
        {
            this.marca = marca;
            this.modelo = modelo;
        }
        #endregion

        #region propiedades
        public clsMarca Marca { get { return marca; }  set { marca = value; } }

        public clsModelo Modelo { get { return modelo; } set { modelo = value; } }

        #endregion

    }
}
