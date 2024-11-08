using DefaultNamespace;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace Library.Combate;

public class Jugador
{
    private string name;
    private List<Pokemon> listaPokemons;
    private Pokemon pokemonEnTurno;
    private bool teamIsAlive;
    private InventarioItems inventarioJugador;

    public Jugador(string name)
    {
        this.name = name;
        this.listaPokemons = new List<Pokemon>();
        this.teamIsAlive = true;
        this.inventarioJugador = new InventarioItems();
    }

    public bool GetPokemonEnTurnoAtaca()
    {
        return pokemonEnTurno.GetPuedeAtacar();
    }

    public void HacerEfectoPokemonEnTurno(Pokemon pokemon)
    {
        pokemonEnTurno.HacerEfectoPokemon(pokemon);
    }
    public Efecto GetEfectoPokemonTurno()
    {
        return pokemonEnTurno.GetEfecto();
    }
    public void PokemonAtacado(IMovimientoAtaque ataque)
    {
        pokemonEnTurno.RecibirAtaque(ataque);
    }

    public int GetCantpokemon()
    {
        return listaPokemons.Count;
    }

    public string GetNamePokemonTurno()
    {
        return pokemonEnTurno.GetName();
    }

    public bool PokemonEnTurnoAlive()
    {
        return pokemonEnTurno.GetIsAlive();
    }
    public string GetName()
    {
        return this.name;
    }

    public bool TeamIsAlive()
    {
        return this.teamIsAlive;
    }
   
    public List<Pokemon> GetPokemons()
    {
        return listaPokemons;
    }
    

    public void AgregarAlEquipo(string nombre)
    {
        
        if (listaPokemons.Count < 6)
        {
            Pokemon pokemonencontrado = Pokedex.EntregarPokemon(nombre);
            if (pokemonencontrado != null)
            {
                
                listaPokemons.Add(pokemonencontrado);
                if (listaPokemons.Count == 1)
                {
                    pokemonEnTurno = pokemonencontrado;
                }
                Console.WriteLine($"Se añadió el pokemon {pokemonencontrado.GetName()} a tu equipo, ¿vas a seguir añadiendo más?");
            }
        }
        else
        {
            Console.WriteLine("Ya tienes 6 Pokemons!");
        }
    }
    public void ActualizarEstadoEquipo()
    {
        bool equipoestado = listaPokemons.Any(pokemon => pokemon.GetIsAlive());
        this.teamIsAlive = equipoestado;
    }

    public void CambiarPokemon(Pokemon pokemon)
    {
        if (listaPokemons.Contains(pokemon))
        {
            int indicepokemonAremplazar = listaPokemons.IndexOf(pokemon);
            Pokemon pokemonAnterior = listaPokemons[0];
            listaPokemons[0] = pokemon;
            listaPokemons[indicepokemonAremplazar] = pokemonAnterior;
            pokemonEnTurno = pokemon;
        }
    }

    public Pokemon GetPokemonEnTurno()
    {
        return pokemonEnTurno;
    }

    public double HpPokemonEnTurno()
    {
        return pokemonEnTurno.GetVidaActual();
    }

    public void MostarEstadoEquipo()
    {
        Console.WriteLine($"El estado del equipo de {name} es:");
        foreach (Pokemon pokemon in listaPokemons)
        {
            if (pokemon.GetIsAlive())
            {
                Console.WriteLine($"{pokemon.GetName()} {pokemon.GetVidaActual()}/{pokemon.GetVidaTotal()}");
            }
            else
            {
                Console.WriteLine($"{pokemon.GetName()} ha muerto");
            }
        }
    }

    public void UsarItem(string item, Pokemon pokemon)
    {
        if (listaPokemons.Contains(pokemon))
        {
            int IndicePokemonAEfectuar = listaPokemons.IndexOf(pokemon);
            Pokemon PokemonAEfectuar = listaPokemons[IndicePokemonAEfectuar];
            inventarioJugador.UsarItem(item, PokemonAEfectuar);
        }
    }

    public void Mostrar_items() //Este método llama al mostrar items de InventarioItems para mostrar los items disponibles que tiene el jugador
    {
        inventarioJugador.MostrarItems();
    }
}