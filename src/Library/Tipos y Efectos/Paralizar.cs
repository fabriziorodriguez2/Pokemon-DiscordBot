using DefaultNamespace;

namespace Library.Tipos;

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