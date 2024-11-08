using DefaultNamespace;

namespace Library.Tipos;
//Dormir:
//La clase Dormir tiene una responsabilidad clara: gestionar el efecto de "dormir" de un Pokémon, lo cual 
//está alineado con el SRP.
//OCP: La clase Dormir puede extenderse con nuevos comportamientos derivados de Efecto sin necesidad de 
//modificar la clase base. 
//LSP: La clase Dormir es una subclase de Efecto, y puede ser utilizada donde se espera un objeto Efecto.


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