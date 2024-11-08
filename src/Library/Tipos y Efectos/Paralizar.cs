using DefaultNamespace;

namespace Library.Tipos;

//Paralizar:
// SRP: La clase Paralizar tiene una responsabilidad clara: gestionar el efecto de la paralización en un Pokémon. 
//OCP: La clase Paralizar es fácil de extender en caso de que se desee añadir nuevas lógicas de efectos, como 
//diferentes probabilidades de paralización, sin modificar el código actual. 
//LSP:  La clase Paralizar hereda de Efecto y se puede usar en cualquier lugar donde se espere un objeto Efecto


public class Paralizar:Efecto
{
    private Random random = new Random();
    public Paralizar()
    {
    }
    private bool Jugar(Pokemon pokemon)
    {
        int numero= random.Next(1, 4);
        if (numero == 1)
        {
            Console.WriteLine($"El pokemon {pokemon.GetName()} puede atacar en este turno a pesar de estar paralizado");
            return true;
        }
        Console.WriteLine($"El pokemon {pokemon.GetName()} no puede atacar, ha sido paralizado");
        return false;
    }

    public override void HacerEfecto(Pokemon pokemon)
    {
        pokemon.SetPuedeAtacar(Jugar(pokemon));
    }
}