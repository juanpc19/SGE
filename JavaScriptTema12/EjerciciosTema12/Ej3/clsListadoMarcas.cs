using System;

class Coche
{
    public int Id { get; set; }
    public string Marca { get; set; }
}

class Program
{
    static void Main()
    {
        // Crear una lista de marcas de coches
        List<Coche> listaDeCoches = new List<Coche>();

        // Agregar algunas marcas de coches a la lista
        listaDeCoches.Add(new Coche { Id = 1, Marca = "Toyota" });
        listaDeCoches.Add(new Coche { Id = 2, Marca = "Honda" });
        listaDeCoches.Add(new Coche { Id = 3, Marca = "Ford" });
        listaDeCoches.Add(new Coche { Id = 4, Marca = "Chevrolet" });

      
    }
}
