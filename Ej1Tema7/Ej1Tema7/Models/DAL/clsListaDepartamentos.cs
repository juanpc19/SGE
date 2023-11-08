using Ej1Tema7.Models.Entidades;

namespace Ej1Tema7.Models.DAL
{
    public class clsListaDepartamentos
    {
        //igual a listaPersonas pero con departamentos 
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {
            List<clsDepartamento> listaDep = new List<clsDepartamento>() {
                new clsDepartamento(1,"a"),
                new clsDepartamento(2,"b"),
                new clsDepartamento(3,"c"),
                new clsDepartamento(4,"d"),
                new clsDepartamento(4,"e")
            };

                return listaDep;
        }
       
    }
}
