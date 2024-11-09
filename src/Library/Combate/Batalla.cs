using System.ComponentModel.Design;
using DefaultNamespace;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace Library.Combate
{
    //Clase Batalla:
    //La clase Batalla cumple con el principio de Responsabilidad Única (SRP) porque se encarga 
    //exclusivamente de la lógica relacionada con el manejo de una batalla entre dos jugadores. 
    //Esto incluye iniciar y terminar la batalla, avanzar los turnos, y determinar el estado de 
    //la batalla (si ha terminado o no).
    //Esto hace que también cumpla con Expert al gestionar únicamente la lógica de la batalla y
    //ser experta en ello.
    public class Batalla
    {
        private bool turnos { get; set; }
        private List<Jugador> jugadoresEnEspera { get; set; }
        private Jugador jugadorAtacante { get; set; }
        private Jugador jugadorDefensor { get; set; }
        private bool batallaTerminada { get; set; }
        public bool batallaIniciada { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Batalla, estableciendo los valores iniciales.
        /// </summary>
        public Batalla()
        {
            this.turnos = true;
            this.batallaTerminada = false;
            this.batallaIniciada = false;
        }

        /// <summary>
        /// Recibe un ataque y lo aplica al Pokémon defensor.
        /// </summary>
        /// <param name="ataque">El movimiento de ataque que se aplica al defensor.</param>

        public void RecibirAtaqueB(IMovimientoAtaque ataque)
        {
            jugadorDefensor.PokemonAtacado(ataque);
        }
        

        /// <summary>
        /// Agrega un jugador a la batalla, asignándolo como atacante o defensor.
        /// </summary>
        /// <param name="jugador">El jugador que se va a agregar a la batalla.</param>
        public void AgregarJugador(Jugador jugador)
        {
            if (jugadorDefensor != null && jugadorAtacante != null)
            {
                Console.WriteLine("No podemos agregar más jugadores pero se te va agregar a una lista de espera, ya hay 2 jugadores para jugar");
                jugadoresEnEspera.Add(jugador);
            }
            else
            {
                if (jugadorDefensor == null && jugadorAtacante == null)
                {
                    // Asigna aleatoriamente al jugador como defensor o atacante si ambos están vacíos.
                    if (new Random().Next(1, 3) == 1)
                    {
                        jugadorDefensor = jugador;
                        Console.WriteLine($"{jugadorDefensor.GetName()} te va tocar esperar, empieza tu oponente");
                    }

                    else
                    {
                        jugadorAtacante = jugador;
                        Console.WriteLine($"{jugadorAtacante.GetName()} tu empezaras el combate");
                    }
                       
                }
                else if (jugadorDefensor == null)
                {
                    jugadorDefensor = jugador;
                    Console.WriteLine($"{jugadorDefensor.GetName()} te va tocar esperar, empieza tu oponente");
                }
                else
                {
                    jugadorAtacante = jugador;
                    Console.WriteLine($"{jugadorAtacante.GetName()} tu empezaras el combate");
                }
            }
        }

        /// <summary>
        /// Obtiene el jugador atacante actual.
        /// </summary>
        /// <returns>El jugador que está atacando en la batalla.</returns>
        public Jugador GetAtacante()
        {
            return jugadorAtacante;
        }

        /// <summary>
        /// Agrega un Pokémon al equipo del jugador atacante.
        /// </summary>
        /// <param name="pokemon">El nombre del Pokémon que se agrega al equipo.</param>
        public void AgregarPokemonBA(string pokemon)
        {
            jugadorAtacante.AgregarAlEquipo(pokemon);
        }
        
        /// <summary>
        /// Agrega un Pokémon al equipo del jugador defensor.
        /// </summary>
        /// <param name="pokemon">El nombre del Pokémon que se agrega al equipo.</param>
        public void AgregarPokemonBD(string pokemon)
        {
            jugadorDefensor.AgregarAlEquipo(pokemon);
        }

        /// <summary>
        /// Obtiene el Pokémon actual del jugador atacante.
        /// </summary>
        /// <returns>El Pokémon en turno del jugador atacante.</returns>
        public Pokemon GetPokemonActualB()
        {
            return jugadorAtacante.GetPokemonEnTurno();
        }
        
        /// <summary>
        /// Obtiene el valor de vida del Pokémon defensor en turno.
        /// </summary>
        /// <returns>El valor de vida del Pokémon defensor.</returns>
        public double GetHpDefensorB()
        {
            return jugadorDefensor.HpPokemonEnTurno();
        }

        /// <summary>
        /// Obtiene el valor de vida del Pokémon atacante en turno.
        /// </summary>
        /// <returns>El valor de vida del Pokémon atacante.</returns>
        public double GetHpAtacanteB()
        {
            return jugadorAtacante.HpPokemonEnTurno();
        }

        /// <summary>
        /// Obtiene el jugador defensor actual.
        /// </summary>
        /// <returns>El jugador que está defendiendo en la batalla.</returns>
        public Jugador GetDefensor()
        {
            return jugadorDefensor;
        }

        /// <summary>
        /// Obtiene el estado de la batalla, indicando si está terminada o no.
        /// </summary>
        /// <returns>El estado de la batalla (terminada o no).</returns>
        public bool GetBatallaTerminada()
        {
            return batallaTerminada;
        }
        /// <summary>
        /// Obtiene el estado de la batalla, indicando si ha sido iniciada.
        /// </summary>
        /// <returns>El estado de la batalla (iniciada o no).</returns>
        public bool GetBatallaIniciada()
        {
            return batallaIniciada;
        }
        /// <summary>
        /// Inicia la batalla si ambos jugadores tienen Pokémon en sus equipos y la batalla no ha comenzado.
        /// </summary>
        public void IniciarBatalla()
        {
            Console.WriteLine("..........");
            // Verifica si ambos jugadores tienen equipos y la batalla no ha comenzado
            if (!batallaIniciada && jugadorAtacante.GetCantpokemon() > 0 && jugadorDefensor.GetCantpokemon()> 0 && jugadorAtacante != null && jugadorDefensor != null)
            {
                batallaIniciada = true;
                Console.WriteLine($"La batalla ha iniciado, comienza el jugador {jugadorAtacante.GetName()}");
            }
            else
            {
                Console.WriteLine($"La batalla ya ha comenzado o uno de los jugadores no tiene Pokémon.");
            }
        }

        /// <summary>
        /// Finaliza la batalla si alguno de los jugadores ha perdido todos sus Pokémon.
        /// </summary>
        public void TerminarBatalla()
        {
            // Revisa si alguno de los equipos ha perdido, si ya ha perdido cambia el bool
            if (!jugadorAtacante.TeamIsAlive())
            {
                Console.WriteLine($"¡Ha ganado el jugador {jugadorDefensor.GetName()}!");
                this.batallaTerminada = true;
                Console.WriteLine("La batalla ha terminado");
            }
            else if (!jugadorDefensor.TeamIsAlive())
            {
                Console.WriteLine($"¡Ha ganado el jugador {jugadorAtacante.GetName()}!");
                this.batallaTerminada = true;
                Console.WriteLine("La batalla ha terminado");
            }
        }

        /// <summary>
        /// Verifica si el Pokémon defensor está debilitado y cambia al siguiente Pokémon si es necesario.
        /// </summary>
        private void VerificarPokemonDefensorDebilitado()
        {
            if (!jugadorDefensor.PokemonEnTurnoAlive())
            {
                foreach (var pokemon in jugadorDefensor.GetPokemons())
                {
                    if (pokemon.GetIsAlive())
                    {
                        Pokemon pokemonDebilitado = jugadorDefensor.GetPokemonEnTurno();
                        jugadorDefensor.CambiarPokemon(pokemon);
                        Console.WriteLine($"{pokemonDebilitado.GetName()} ha sido debilitado y cambiado por {jugadorDefensor.GetNamePokemonTurno()} automáticamente");
                        return;
                    }
                }
                Console.WriteLine($"A {jugadorDefensor.GetName()} no le quedan más Pokémon en condiciones de combatir.");
                TerminarBatalla();
            }
        }

        /// <summary>
        /// Avanza al siguiente turno de la batalla, alternando entre los jugadores y verificando si alguno de los equipos ha perdido.
        /// </summary>
        public void AvanzarTurno()
        {
            
            VerificarPokemonDefensorDebilitado();

            if (batallaTerminada)
            {
                Console.WriteLine("La batalla ha terminado.");
                return;
            }

            if (jugadorDefensor.GetEfectoPokemonTurno() != null)
            {
                Pokemon pokemon = jugadorDefensor.GetPokemonEnTurno();
                jugadorDefensor.HacerEfectoPokemonEnTurno(pokemon); 
            }

            CambiarTurno();

            if (!jugadorAtacante.GetPokemonEnTurnoAtaca())
            {
                Console.WriteLine($"{jugadorAtacante.GetName()} no puede atacar este turno.");
                AvanzarTurno();
            }
            else
            {
                jugadorDefensor.ActualizarEstadoEquipo();
                jugadorAtacante.ActualizarEstadoEquipo();
                Console.WriteLine("..........");
            }
            if (!jugadorAtacante.TeamIsAlive() || !jugadorDefensor.TeamIsAlive())
            {
                TerminarBatalla();
            }
            else
            {
                Console.WriteLine($"Es el turno de {jugadorAtacante.GetName()} con el Pokémon {jugadorAtacante.GetNamePokemonTurno()}.");
            }
            
        }

        /// <summary>
        /// Cambia el turno entre el jugador atacante y el defensor. El atacante es el defensor y viceversa
        /// </summary>
        private void CambiarTurno()
        {
            Jugador temporal = jugadorAtacante;
            jugadorAtacante = jugadorDefensor;
            jugadorDefensor = temporal;
            turnos = !turnos;
        }
    }
}
