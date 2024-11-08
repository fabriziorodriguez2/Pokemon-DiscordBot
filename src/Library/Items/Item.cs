using DefaultNamespace;

namespace Library.Combate;

public abstract class Item
{

    public int Cantidad { get; set; }

    protected Item(int cantidad)
    {
        this.Cantidad = cantidad;
    }

    public abstract void AplicarEfecto(Pokemon pokemon);
}