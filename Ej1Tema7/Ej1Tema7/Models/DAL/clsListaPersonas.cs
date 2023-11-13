using Ej1Tema7.Models.Entidades;

namespace Ej1Tema7.Models.DAL
{
    /// <summary>
    /// clase estatica
    /// </summary>
    public static class clsListaPersonas
    {
        /// <summary>
        /// funcion que devuelve listado de objetocs clsPersonas
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>listadoPersonas</returns>
        public static List<clsPersona> listadoCompletoPersonas ()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>() {
                new clsPersona("Juan", "Gallego Lopez"),
                new clsPersona("Jaime", "Garcia Lorca"),
                new clsPersona("Antonio", "Perez Garcia"),
                new clsPersona("Pepe", "Garcia Gallego"),
                new clsPersona("Felipe", "Lorca Diaz")
            };
            //opcional modifica post requisito
           // throw new Exception();
            return listadoPersonas;
        }


    }
}
