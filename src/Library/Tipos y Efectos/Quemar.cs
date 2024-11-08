using DefaultNamespace;

namespace Library.Tipos;

//Quemar:
//SRP: La clase tiene una sola responsabilidad, que es aplicar el efecto de quemado a un Pokémon. 
//OCP: La clase Quemar es fácil de extender en caso de que se desee añadir nuevas lógicas de efectos, como 
//diferentes probabilidades de quemar, sin modificar el código actual. 
//LSP:  La clase Quemar hereda de Efecto y se puede usar en cualquier lugar donde se espere un objeto Efecto


public class Quemar:Efecto
{
    public Quemar()
    {
        
    }

    public override void HacerEfecto(Pokemon pokemon)
    {
        Console.WriteLine(pokemon.GetName()," ha sido Quemado");
        pokemon.RecibirDanioDeEfecto(10);
    }
}