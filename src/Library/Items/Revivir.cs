using DefaultNamespace;
namespace Library.Combate;

//Clase Revivir:
//La clase Revivir tiene una responsabilidad única: aplicar el efecto de revivir a un Pokémon. Está completamente enfocada 
//en esta tarea y no está haciendo nada más, por lo que es cohesiva y cumple con SRP.
//La clase Revivir hereda de Item y, por lo tanto, implementa el método AplicarEfecto de manera polimórfica. 
//Cumple con LSP: La clase Revivir puede ser sustituida por cualquier otra clase que herede de Item sin alterar el 
//esperado. Esto se debe a que Revivir implementa el método AplicarEfecto, que es un método polimórfico, y cualquier ítem que 
//herede de Item debería tener su propia implementación de este método.

public class Revivir : Item
{
    public Revivir(int cantidad) : base(cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        pokemon.Revivir();
        Console.WriteLine($"{pokemon.GetName()} ha revivido con la mitad de su HP.");
    }
}