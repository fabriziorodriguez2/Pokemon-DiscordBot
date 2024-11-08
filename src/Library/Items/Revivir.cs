using DefaultNamespace;
namespace Library.Combate;

public class Revivir : Item
{
    public Revivir(int cantidad) : base(cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        pokemon.Revivir();
        Console.WriteLine($"{pokemon.GetName()} ha revivido con la mitad de su HP.");
    }
}