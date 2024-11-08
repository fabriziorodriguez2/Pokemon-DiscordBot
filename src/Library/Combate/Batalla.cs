using System.ComponentModel.Design;
using DefaultNamespace;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace Library.Combate
{
    // El principio SRP se aplica ya que esta clase tiene la responsabilidad de manejar la batalla:
    // iniciar, terminar y avanzar el turno de manera clara y precisa.
    public class Batalla
    {
        private bool turnos { get; set; }
        private Jugador jugadorAtacante { get; set; }
        private Jugador jugadorDefensor { get; set; }
        private bool batallaTerminada { get; set; }
        public bool batallaIniciada { get; set; }

        public Batalla()
        {
            this.turnos = true;
            this.batallaTerminada = false;
            this.batallaIniciada = false;
        }

        public void RecibirAtaqueB(IMovimientoAtaque ataque)
        {
            jugadorDefensor.PokemonAtacado(ataque);
        }

        public void AgregarJugador(Jugador jugador)
        {
            if (jugadorDefensor != null && jugadorAtacante != null)
            {
                Console.WriteLine("No podemos agregar más jugadores, ya hay 2 jugadores para jugar");
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

        public Jugador GetAtacante()
        {
            return jugadorAtacante;
        }

        public void AgregarPokemonBA(string pokemon)
        {
            jugadorAtacante.AgregarAlEquipo(pokemon);
        }
        
        public void AgregarPokemonBD(string pokemon)
        {
            jugadorDefensor.AgregarAlEquipo(pokemon);
        }

        public Pokemon GetPokemonActualB()
        {
            return jugadorAtacante.GetPokemonEnTurno();
        }
        

        public double GetHpDefensorB()
        {
            return jugadorDefensor.HpPokemonEnTurno();
        }

        public double GetHpAtacanteB()
        {
            return jugadorAtacante.HpPokemonEnTurno();
        }

        public Jugador GetDefensor()
        {
            return jugadorDefensor;
        }

        public bool GetBatallaTerminada()
        {
            return batallaTerminada;
        }
        public bool GetBatallaIniciada()
        {
            return batallaIniciada;
        }
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

        private void CambiarTurno()
        {
            Jugador temporal = jugadorAtacante;
            jugadorAtacante = jugadorDefensor;
            jugadorDefensor = temporal;
            turnos = !turnos;
        }

    }
}
