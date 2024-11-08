using DefaultNamespace;

namespace Library.Tipos;

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