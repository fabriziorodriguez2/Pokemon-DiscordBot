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

    /// <summary>
    /// Constructor de la clase `Menu`.
    /// Inicializa un nuevo objeto `Menu` y una instancia de `Batalla`.
    /// </summary>
    public Menu()
    {
        batallaActual = new Batalla();
    }

    /// <summary>
    /// Une un jugador a la batalla.
    /// </summary>
    /// <param name="jugador">Nombre del jugador que se unirá.</param>
    public void UnirJugadores(string jugador)
    {
        batallaActual.AgregarJugador(new Jugador(jugador));
    }

    /// <summary>
    /// Verifica si la batalla ha terminado.
    /// </summary>
    public bool GetBatallaT()
    {
        return batallaActual.GetBatallaTerminada();
    }

    /// <summary>
    /// Verifica si la batalla ha iniciado.
    /// </summary>
    public bool GetBatallaI()
    {
        return batallaActual.GetBatallaIniciada();
    }

    /// <summary>
    /// Obtiene el Pokémon actual del jugador rival.
    /// </summary>
    public Pokemon GetPokemonRival()
    {
        Jugador defensor = batallaActual.GetDefensor();
        return defensor.GetPokemonEnTurno();
    }

    /// <summary>
    /// Obtiene la salud del defensor.
    /// </summary>
    public double GetHpDefensor()
    {
        return batallaActual.GetHpDefensorB(); 
    }

    /// <summary>
    /// Obtiene la salud del atacante.
    /// </summary>
    public double GetHpAtacante()
    {
        return batallaActual.GetHpAtacanteB(); 
    }

    /// <summary>
    /// Obtiene el equipo del atacante.
    /// </summary>
    public List<Pokemon> GetEquipoA()
    {
        Jugador jugadorA = batallaActual.GetAtacante();
        return jugadorA.GetPokemons();
    }

    /// <summary>
    /// Obtiene el Pokémon en turno del atacante.
    /// </summary>
    public Pokemon GetPokemonActual()
    {
        return batallaActual.GetPokemonActualB();
    }

    /// <summary>
    /// Agrega un Pokémon al equipo del atacante.
    /// </summary>
    public void AgregarPokemonesA(string pokemon)
    {
        batallaActual.AgregarPokemonBA(pokemon); 
    }

    /// <summary>
    /// Agrega un Pokémon al equipo del defensor.
    /// </summary>
    public void AgregarPokemonesD(string pokemon)
    {
        batallaActual.AgregarPokemonBD(pokemon);
    }

    /// <summary>
    /// Inicia el enfrentamiento de batalla.
    /// </summary>
    public void IniciarEnfrentamiento()
    {
        batallaActual.IniciarBatalla();
    }

    /// <summary>
    /// Muestra el estado del equipo del jugador rival.
    /// </summary>
    public void MostrarEstadoRival()
    {
        if (batallaActual.GetBatallaIniciada())
        {
            Jugador defensor = batallaActual.GetDefensor();
            defensor.MostarEstadoEquipo();
        }
    }

    /// <summary>
    /// Muestra el estado del equipo del jugador actual.
    /// </summary>
    public void MostrarEstadoEquipo()
    {
        if (batallaActual.GetBatallaIniciada())
        {
            Jugador atacante = batallaActual.GetAtacante();
            atacante.MostarEstadoEquipo();
        }
    }

    /// <summary>
    /// Cambia el Pokémon en turno del jugador atacante.
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
    /// Muestra los movimientos disponibles del Pokémon en turno.
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
                    Console.WriteLine(movimiento is IMovimientoEspecial ? $"{movimiento.GetName()} (especial)" : movimiento.GetName());
                }
            }
        }
    }

    /// <summary>
    /// Usa un movimiento del Pokémon en turno.
    /// </summary>
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
            IMovimiento movimiento = movimientos[numDeMovimiento - 1];

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
                    int numeroAleatorio = random.Next(1, 101);
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
    /// Muestra el número de Pokémon del equipo atacante.
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
    /// Muestra los ítems disponibles en el inventario del jugador atacante.
    /// </summary>
    public void MostrarItemsDisponibles()
    {
        if (batallaActual.GetBatallaIniciada())
        {
            Jugador jugador = batallaActual.GetAtacante();
            jugador.Mostrar_items();
        }
    }

    /// <summary>
    /// Usa un ítem específico en el Pokémon indicado.
    /// </summary>

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