using Ucu.Poo.DiscordBot.Domain;
using Library.Combate;
//Clase de AdapterBattle cumple con SRP ya que tiene la única responsabilidad de actuar como "puente" entre Batalla y
//Battle de bot para que éste se adapte a la interfaz que utilizamos.
//Cumple con Expert ya que es la que tiene toda esa información para actuar de esa manera
//Cumple con OCP ya que está abierto a extensiones pero cerrado a modificaciones,
//ya que por ejemplo puedes adaptar nuevas funcionalidades de Batalla que añadas sin que esto afecte a lo que ya está hecho
//También cumple con LSP ya que puede usarse donde se espere un objeto de tipo Battle sin romper nada.
namespace AdapterNamespace
{
    /// <summary>
    /// Adaptador para conectar la clase `Batalla` con la clase `Battle` del bot.
    /// </summary>
    public class BattleAdapter : Battle
    {
        private readonly Batalla _batalla;

        /// <summary>
        /// Crea una instancia del adaptador para usar `Batalla` como `Battle`.
        /// </summary>
        /// <param name="player1">El nombre del primer jugador.</param>
        /// <param name="player2">El nombre del segundo jugador.</param>
        public BattleAdapter(string player1, string player2) : base(player1, player2)
        {
            _batalla = new Batalla();
            _batalla.AgregarJugador(new Jugador(player1));
            _batalla.AgregarJugador(new Jugador(player2));
            
        }

        /// <summary>
        /// Inicia la batalla utilizando la lógica de la clase `Batalla`.
        /// </summary>
        public override string ToString()
        {
            if (!_batalla.BatallaIniciada)
            {
                return _batalla.IniciarBatalla();
            }
            return "La batalla ya está en curso.";
        }

        /// <summary>
        /// Simula un turno de batalla utilizando la lógica de la clase `Batalla`.
        /// </summary>
        public string AvanzarTurno()
        {
            return _batalla.AvanzarTurno();
        }

        /// <summary>
        /// Finaliza la batalla si las condiciones lo permiten.
        /// </summary>
        public string Terminar()
        {
            return _batalla.TerminarBatalla();
        }

        /// <summary>
        /// Obtiene el nombre del jugador atacante actual.
        /// </summary>
        public string GetAtacante()
        {
            return _batalla.GetAtacante().GetName();
        }

        /// <summary>
        /// Obtiene el nombre del jugador defensor actual.
        /// </summary>
        public string GetDefensor()
        {
            return _batalla.GetDefensor().GetName();
        }

        /// <summary>
        /// Agrega un Pokémon al equipo del jugador atacante.
        /// </summary>
        public string AgregarPokemonAtacante(string pokemon)
        {
            return _batalla.AgregarPokemonBA(pokemon);
        }

        /// <summary>
        /// Agrega un Pokémon al equipo del jugador defensor.
        /// </summary>
        public string AgregarPokemonDefensor(string pokemon)
        {
            return _batalla.AgregarPokemonBD(pokemon);
        }
    }
}
