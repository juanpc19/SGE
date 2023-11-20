using ElMandaloriano.Models.Entities;

namespace ElMandaloriano.Models.DAL
{
    //static?
    public class clsListadoMisiones
    {
        /// <summary>
        /// devolvera una listado falso de misiones simulando datos de base de datos
        /// </summary>
        /// <returns></returns>
        public static List<clsMision> GetListadoMisiones()
        {
            List<clsMision> listado = new List<clsMision>()
            {
            new clsMision("Rescate de Baby Yoda",
                          "Debes hacerte con Grogu y llevárselo a Luke Skywalker para su entrenamiento.",
                          "5000"),
            new clsMision("Recuperar armadura Beskar",
                          "Tu armadura de Beskar ha sido robada. Debes encontrarla.",
                          "2000"),
            new clsMision("Planeta Sorgon",
                          "Debes llevar a un niño de vuelta a su planeta natal 'Sorgon'.",
                          "500"),
            new clsMision("Renacuajos",
                          "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.",
                          "500")
            };

            return listado;
        }
    }
}
