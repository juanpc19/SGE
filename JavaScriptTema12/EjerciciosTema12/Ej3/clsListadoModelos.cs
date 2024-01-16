using System;

public class clsListadoModelos
{
    public static List<string> GetListado()
    {
        List<string> marcasDeCoches = new List<string>
            {
                "Toyota",
                "Honda",
                "Ford",
                "Chevrolet"
            };

        return marcasDeCoches;
    }
}
