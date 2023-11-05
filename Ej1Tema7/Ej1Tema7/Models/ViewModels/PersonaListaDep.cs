using Ej1Tema7.Models.Entidades;

namespace Ej1Tema7.Models.ViewModels
{
    public static class PersonaListaDep
    {
        //cambiar lo de abajo por algo como objeto persona y lista departamentos, lo de abajo es placeholder para evita error
        public static List<clsPersona> listadoCompletoPersonas()
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
