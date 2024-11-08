using DefaultNamespace;

//Dormir:
//La clase Envenenar tiene una responsabilidad clara: gestionar el efecto de "envenenar" de un Pokémon, lo cual 
//está alineado con el SRP.
//OCP: La clase Envenenar puede extenderse con nuevos comportamientos derivados de Efecto sin necesidad de 
//modificar la clase base. 
//LSP: La clase Envenenar es una subclase de Efecto, y puede ser utilizada donde se espera un objeto Efecto.

namespace Library.Tipos;

public class Envenenar:Efecto
{
    public Envenenar()
    {
        
    }

    public override void HacerEfecto(Pokemon pokemon)
    {
        Console.WriteLine(pokemon.GetName()," ha sido envenenado");
        pokemon.RecibirDanioDeEfecto(5);
    }
}