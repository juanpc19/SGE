using Ej1Tema7.Models.Entidades;

namespace Ej1Tema7.Models.DAL
{
    /// <summary>
    /// clase estatica
    /// </summary>
    public class clsListaDepartamentos
    {
        /// <summary>
        /// funcion que devuelve listado de objetocs clsPersonas
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>listadoPersonas</returns>
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {
            List<clsDepartamento> listaDep = new List<clsDepartamento>() {
                new clsDepartamento(1,"Departamento 1"),
                new clsDepartamento(2,"Departamento 2"),
                new clsDepartamento(3,"Departamento 3"),
                new clsDepartamento(4,"Departamento 4"),
                new clsDepartamento(5,"Departamento 5")
            };

            //opcional modifica post requisito
            // throw new Exception();
            return listaDep;
        }
       
    }
}
