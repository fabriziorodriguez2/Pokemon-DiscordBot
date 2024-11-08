using DefaultNamespace;

namespace Library.Combate;
//Clase CuraTotal:
//Tiene alta cohesion, ya que su responsabilidad es clara: aplicar un efecto de curacion al Pokemon, 
//eilminando el efecto actual delpokemon si esta vivo.
//Cumple con polimorfismo debido a que sobreescribe el metodo Aplicar Efecto de la clase.
//Cumple con SRP debido a que tiene una sola responsabilidad: aplicar un efecto de curación a un Pokémon. 

public class CuraTotal : Item
{
    
    public CuraTotal(int cantidad) : base( cantidad) { }
    
    //La Cura total quita el efecto actual del Pokemon indicado, siempre y cuando el pokemon tenga un efecto y no este muerto

    public override void AplicarEfecto(Pokemon pokemon)
    {
        if (pokemon.GetIsAlive())
        {
            pokemon.EliminarEfectoActual();
            Console.WriteLine($"{pokemon.GetName()} ha sido curado de todos los efectos de estado.");
        }
        else
        {
            Console.WriteLine($"El pokemon {pokemon.GetName()} no se puede curar de ningun efecto debido a que esta muerto");
        }
        
    }
}