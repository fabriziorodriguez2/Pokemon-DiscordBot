using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate
{
    //Clase Menu:
    //La clase Menu cumple con el Principio de Responsabilidad Única (SRP) al gestionar exclusivamente 
    //las interacciones del menú para la batalla de Pokémon, y en el Principio de Abierto/Cerrado (OCP), 
    //ya que permite la extensión sin modificar la funcionalidad existente. Además, sigue el Principio de 
    //Inversión de Dependencias (DIP) al depender de abstracciones como Jugador e IMovimiento, y el Principio 
    //de Sustitución de Liskov (LSP) al permitir el uso de diferentes implementaciones de IMovimiento.


    public class Menu
    {
        private Batalla batallaActual;

        public Menu()
        {
            batallaActual = new Batalla();
        }

        /// <summary>
        /// Une un jugador a la batalla actual.
        /// </summary>
        public void UnirJugadores(string jugador)
        {
            batallaActual.AgregarJugador(new Jugador(jugador));
        }

        /// <summary>
        /// Obtiene la vida actual del defensor.
        /// </summary>
        public double GetHpDefensor()
        {
            return batallaActual.GetHpDefensorB(); 
        }
        
        /// <summary>
        /// Obtiene la vida actual del atacante.
        /// </summary>
        public double GetHpAtacante()
        {
            return batallaActual.GetHpAtacanteB(); 
        }

        /// <summary>
        /// Obtiene el equipo de Pokémon del jugador atacante.
        /// </summary>
        public List<Pokemon> GetEquipoA()
        {
            Jugador jugadorA = batallaActual.GetAtacante();
            return jugadorA.GetPokemons();
        }
        
        /// <summary>
        /// Obtiene el Pokémon actual del jugador atacante.
        /// </summary>
        public Pokemon GetPokemonActual()
        {
            return batallaActual.GetPokemonActualB();
        }

        /// <summary>
        /// Agrega un Pokémon al equipo del jugador atacante.
        /// </summary>
        public void AgregarPokemonesA(string pokemon)
        {
            batallaActual.AgregarPokemonBA(pokemon); 
        }

        /// <summary>
        /// Agrega un Pokémon al equipo del jugador defensor.
        /// </summary>
        public void AgregarPokemonesD(string pokemon)
        {
            batallaActual.AgregarPokemonBD(pokemon);
        }

        /// <summary>
        /// Inicia la batalla entre los jugadores.
        /// </summary>
        public void IniciarEnfrentamiento()
        {
            batallaActual.IniciarBatalla();
        }

        /// <summary>
        /// Muestra el estado del equipo del defensor.
        /// </summary>
        public void MostrarEstadoRival()
        {
            if (batallaActual.GetBatallaIniciada())
            {
                // Muestra el estado del defensor, no del atacante
                Jugador defensor = batallaActual.GetDefensor();
                defensor.MostarEstadoEquipo();
            }
        }

        /// <summary>
        /// Muestra el estado del equipo del atacante.
        /// </summary>
        public void MostrarEstadoEquipo()
        {
            if (batallaActual.GetBatallaIniciada())
            {
                // Muestra el estado del atacante
                Jugador atacante = batallaActual.GetAtacante();
                atacante.MostarEstadoEquipo();
            }
        }

        /// <summary>
        /// Cambia el Pokémon actual del jugador atacante por otro Pokémon disponible.
        /// </summary>
        public void CambiarPokemon(int numeroDePokemon)
        {
            if (batallaActual.GetBatallaIniciada())
            {
                Jugador jugadorAtacante = batallaActual.GetAtacante();
                List<Pokemon> pokemons = jugadorAtacante.GetPokemons();
            
                if (numeroDePokemon >= 0 && numeroDePokemon < pokemons.Count )
                {
                    Pokemon pokemonElegido = pokemons[numeroDePokemon];
                
                    if (pokemonElegido.GetIsAlive())
                    {
                        Pokemon pokemon = jugadorAtacante.GetPokemonEnTurno();
                        jugadorAtacante.CambiarPokemon(pokemonElegido);
                        Console.WriteLine($"El Pokémon {pokemonElegido.GetName()} ha entrado en combate y {pokemon.GetName()} ha sido guardado en su pokebola");
                        batallaActual.AvanzarTurno();
                    }
                    else
                    {
                        Console.WriteLine($"El Pokémon {pokemonElegido.GetName()} está debilitado y no puede entrar en combate");
                    }
                }
                else
                {
                    Console.WriteLine("No tienes ese pokemon");
                }
            }
        }

        /// <summary>
        /// Muestra los ataques disponibles para el Pokémon actual del atacante.
        /// </summary>
        public void MostrarAtaquesDisponibles()
        {
            if (batallaActual.GetBatallaIniciada())
            {
                
                Jugador jugadorAtacante = batallaActual.GetAtacante();
                Pokemon pokemon = jugadorAtacante.GetPokemonEnTurno();
                Console.WriteLine($"El Pokémon {pokemon.GetName()} tiene los siguientes movimientos:");
                foreach (IMovimiento movimiento in pokemon.GetListaMovimientos())
                {
                    if (movimiento is IMovimientoEspecial especial && especial.GetUsadoAnteriormente())
                    {
                        Console.WriteLine($"{movimiento.GetName()}(especial) no puede ser usado en este turno");
                    }
                    else
                    {
                        if (movimiento is IMovimientoEspecial movimientoEspecial)
                        {
                            Console.WriteLine(movimientoEspecial.GetName(), "(especial)");
                        }
                        else
                        {
                            Console.WriteLine(movimiento.GetName());
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Permite al jugador seleccionar un movimiento para usar durante su turno en la batalla.
        /// </summary>
        /// <param name="numDeMovimiento">Número del movimiento a usar (1 a 4).</param>
        public void UsarMovimientos(int numDeMovimiento)
        {
            if (batallaActual.GetBatallaTerminada())
            {
                Console.WriteLine("La batalla ya ha terminado.");
                return;
            }

            if (!batallaActual.GetBatallaIniciada())
            {   
                Console.WriteLine("La batalla no ha iniciado");
                return;
            }
            Jugador jugador = batallaActual.GetAtacante();
            Pokemon pokemonActual = jugador.GetPokemonEnTurno();
            List<IMovimiento> movimientos = pokemonActual.GetListaMovimientos();
            if (numDeMovimiento > 0 && numDeMovimiento <= movimientos.Count)
            {
                IMovimiento movimiento = movimientos[numDeMovimiento - 1]; //acomodo por la lista

                if (movimiento is IMovimientoEspecial especial && especial.GetUsadoAnteriormente())
                {
                    Console.WriteLine($"El movimiento {movimiento.GetName()} es especial y ya fue usado anteriormente. Elija otro movimiento.");
                }
                else
                {
                    pokemonActual.UsarMovimiento(movimiento);
                    Console.WriteLine($"{pokemonActual.GetName()} ha usado {movimiento.GetName()}.");
                    if (movimiento is IMovimientoAtaque movimientoAtaque)
                    {
                        Random random = new Random();
                        int numeroAleatorio = random.Next(1, 101); //Numero aleatorio para saber si acierto 
                        if (numeroAleatorio <= movimientoAtaque.GetPrecision())
                        {
                            Console.WriteLine($"{pokemonActual.GetName()} ha acertado su ataque");
                            batallaActual.RecibirAtaqueB(movimientoAtaque);
                        }
                        else
                        {
                            Console.WriteLine($"El ataque {movimientoAtaque.GetName()} ha fallado");
                        }

                        if (movimientoAtaque is IMovimientoEspecial movimientoEspecial)
                        {
                            movimientoEspecial.UsadoAnteriormente(true);
                        }
                    }
                    batallaActual.AvanzarTurno();
                }
            }
            else
            {
                Console.WriteLine("Movimiento inválido. Por favor, seleccione un movimiento entre 1 y 4, o uno que pueda usarse en este turno.");
            }
        }
        
        /// <summary>
        /// Muestra los Pokémon disponibles para el jugador en la batalla con su índice.
        /// </summary>
        public void MostrarNumPokemon()
        {
            if (batallaActual.GetBatallaIniciada())
            {
                Jugador jugador = batallaActual.GetAtacante();
                List<Pokemon> listaPokemons = jugador.GetPokemons();
                for (int i = 0; i < listaPokemons.Count; i++)
                {
                    Pokemon pokemon = listaPokemons[i];
                    Console.WriteLine($"{i}. {pokemon.GetName()}");
                }
            }
        }
        
        /// <summary>
        /// Muestra los ítems disponibles para el jugador en la batalla.
        /// </summary>
        public void MostrarItemsDisponibles() //Llama al método de jugador para mostrar los items
        {
            if (batallaActual.GetBatallaIniciada())
            {
                Jugador jugador = batallaActual.GetAtacante();
                jugador.Mostrar_items();
            }
        }

        /// <summary>
        /// Permite al jugador usar un ítem en uno de sus Pokémon durante la batalla.
        /// </summary>
        /// <param name="item">Nombre del ítem a usar.</param>
        /// <param name="numeroDePokemon">Número del Pokémon que recibirá el ítem.</param>
        public void UsarItem(string item, int numeroDePokemon) //Este método utiliza el item que le pases por string
        {
            if (batallaActual.GetBatallaIniciada())
            {
                Jugador jugadorAtacante = batallaActual.GetAtacante();
                List<Pokemon> pokemons = jugadorAtacante.GetPokemons();

                if (numeroDePokemon >= 0 && numeroDePokemon < pokemons.Count)
                {
                    Pokemon pokemonElegido = pokemons[numeroDePokemon];
                    jugadorAtacante.UsarItem(item, pokemonElegido);
                    batallaActual.AvanzarTurno();
                }
                else
                {
                    Console.WriteLine("Seleccione el pokemon correctamente");
                }
            }
        }
    }
}