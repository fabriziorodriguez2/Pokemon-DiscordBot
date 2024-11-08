using DefaultNamespace;

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