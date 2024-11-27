using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.Pokemon;
//Clase de AdapterTrainer cumple con SRP ya que tiene la única responsabilidad de actuar como "puente" entre Jugador y
//Trainer de bot para que éste se adapte a la interfaz que utilizamos.
//Cumple con Expert ya que es la que tiene toda esa información para actuar de esa manera
//Cumple con OCP ya que está abierto a extensiones pero cerrado a modificaciones,
//ya que por ejemplo puedes adaptar nuevas funcionalidades de Jugador que añadas sin que esto afecte a lo que ya está hecho
//También cumple con LSP ya que puede usarse donde se espere un objeto de tipo Trainer sin romper nada.
namespace AdapterNamespace;

public class AdapterTrainer: Trainer
{
    private readonly Jugador _jugador;
    
    public AdapterTrainer(string name) : base(name)
    {
        Jugador _jugador = new Jugador(name);
    }

    public bool GetpokemonEnTurnoAtaca()
    {
        return _jugador.GetPokemonEnTurnoAtaca();
    }

    public string HacerEfectoPokemonEnTurno(Pokemon pokemon)
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.HacerEfectoPokemon(pokemon);
    }

    public Efecto GetEfectoPokemonTurno()
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.GetEfecto();
    }

    public string PokemonAtacado(IMovimientoAtaque ataque)
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.RecibirAtaque(ataque);
    }

    public int GetCantpokemon()
    {
        List<Pokemon> listapokemones = _jugador.GetPokemons();
        return listapokemones.Count;
    }

    public bool PokemonEnTurnoAlive()
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.GetIsAlive();
    }

    public string GetName()
    {
        return _jugador.GetName();
    }

    public bool TeamIsalive()
    {
        return _jugador.TeamIsAlive();
    }

    public string AgregarAlEquipo(string name)
    {
        return _jugador.AgregarAlEquipo(name);
    }

    public void ActualizarEstadoEquipo()
    {
        _jugador.ActualizarEstadoEquipo();
    }

    public void CambiarPokemon(Pokemon pokemon)
    {
        _jugador.CambiarPokemon(pokemon);
    }

    public Pokemon GetPokemonEnTurno()
    {
        return _jugador.GetPokemonEnTurno();
    }

    public double HpPokemonEnTurno()
    {
        return _jugador.HpPokemonEnTurno();
    }

    public string MostarEstadoEquipo()
    {
        return _jugador.MostarEstadoEquipo();
    }

    public string UseItem(string item, Pokemon pokemon)
    {
        return _jugador.UsarItem(item, pokemon);
    }

    public string MostrarItems()
    {
        return _jugador.MostrarItems();
    }
}