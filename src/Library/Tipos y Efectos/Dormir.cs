using DefaultNamespace;

namespace Library.Tipos;

public class Dormir:Efecto
{
    private int Turnos;
    private Random random = new Random();
    
    public Dormir()
    {
        this.Turnos = random.Next(1, 5);
    }
    public override void HacerEfecto(Pokemon pokemon)
    {
       
        if (this.Turnos == 0)
        {
            pokemon.SetPuedeAtacar(true);
            pokemon.EliminarEfectoActual();
        }
        else
        {
            Console.WriteLine($"{pokemon.GetName()} dormira durante {Turnos} turnos");
            pokemon.SetPuedeAtacar(false);
        }
        this.Turnos -= 1;
    }
}