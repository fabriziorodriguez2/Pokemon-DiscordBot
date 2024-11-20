using System;
using System.Collections.Generic;
using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Program.Tests.Combate;

[TestFixture]
// [TestSubject(typeof(Menu))]
public class UnitTest
{
    /// <summary>
    /// Prueba de la clase <see cref="Menu"/>.
    /// Estos test nos permiten verificar que las historias de usuarios están bien implementadas
    /// </summary>

    [Test]
    /// <summary>
    /// Este test verifica la cuarta historia de usuario ya que un ataque electrico a un tipo planta le hace la mitad del daño del ataque
    /// Además tambien cumple con la septima historia de usuario que dice puedo de pokemon cuando es mi turno pasando de Squirtle a Bulbasaur
    /// Además que el que comienza es squirtle y bulbasaur , para luego jugar pikachu repetando el orden del enfrentamiento
    /// </summary>
    public void JugadorTrataDeUsarPokemonQueNoTiene()
    {
        Menu Menu1 = new Menu();
        Menu1.UnirJugadores("Ash");
        Menu1.UnirJugadores("yo");
        Menu1.AgregarPokemonesA("Arbok");
        Menu1.AgregarPokemonesD("Squirtle");
        Menu1.IniciarEnfrentamiento();
        Menu1.UsarMovimientos(1);
        double vidaesperadasquirtle = 60;
        double vidadada = Menu1.GetHpDefensor();
        Assert.That(vidaesperadasquirtle, Is.EqualTo(vidadada));
    }

    [Test]
    public void JugadorTrataDeCambiarAPokemonQueEstaPeleando()
    {

        Menu juego3 = new Menu();
        juego3.UnirJugadores("Ash");
        juego3.UnirJugadores("Red");
        juego3.AgregarPokemonesA("Squirtle"); //Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        juego3.AgregarPokemonesD("Charmander");
        juego3.AgregarPokemonesA("Bulbasaur"); //Bulbasaur era el segundo pokemon del equipo
        juego3.IniciarEnfrentamiento();
        juego3.CambiarPokemon(0); //Trata de cambiar a Squirtle por Squirtle
        string pokemonesperado = "Squirtle";
        string pokemonobtenido = juego3.GetPokemonActual().GetName(); //Si hubiese salido bien, sería el turno del otro jugador porque hubiese avanzado un turno
        Assert.That(pokemonesperado, Is.EqualTo(pokemonobtenido));

    }

    [Test]
    public void JugadorTrataDeCambiarAPokemonDebilitado()
    {

        Menu juego1 = new Menu();
        juego1.UnirJugadores("Ash");
        juego1.UnirJugadores("Red");
        juego1.AgregarPokemonesA("Pikachu");
        juego1.AgregarPokemonesD("Pidgey");
        juego1.AgregarPokemonesD("Bulbasaur"); //Bulbasaur era el segundo pokemon del equipo
        juego1.IniciarEnfrentamiento();
        juego1.UsarMovimientos(1); //Jugador 1 usa Rayo y pidgey es debilitado
        juego1.CambiarPokemon(1); //Trata de cambiar a Pidgey
        string pokemonesperado = "Bulbasaur";
        string
            pokemonobtenido =
                juego1.GetPokemonActual()
                    .GetName(); //Si hubiese salido bien, el entrenador ahora tendría a Pidgey en combate, pero no se puede
        Assert.That(pokemonobtenido, Is.EqualTo(pokemonesperado));
    }

    [Test]
    public void PokemonParalizado()
    {
        Paralizar paralizado = new Paralizar();
        Menu juego1 = new Menu();
        juego1.UnirJugadores("Ash");
        juego1.UnirJugadores("Red");
        juego1.AgregarPokemonesA("Pikachu");
        juego1.AgregarPokemonesD("Bulbasaur"); //Bulbasaur era el segundo pokemon del equipo
        juego1.IniciarEnfrentamiento();
        juego1.UsarMovimientos(1); //Jugador 1 usa Rayo y bulbasaur es paralizado
        Pokemon pokemon = juego1.GetPokemonActual();
        Pokemon rival = juego1.GetPokemonRival();
        juego1.UsarMovimientos(4);
        rival.AgregarEfecto(paralizado);
        Efecto efectohecho = rival.GetEfecto();
        Efecto efectoesperado = pokemon.GetEfecto();
        Assert.That(efectohecho.GetType(), Is.EqualTo(efectoesperado.GetType()));
    }
    [Test]
    public void TrataDeUsarSuperPocionEnPokemonDebilitado()
    {
        Menu juego1 = new Menu();
        juego1.UnirJugadores("Ash");
        juego1.UnirJugadores("Red");
        juego1.AgregarPokemonesA("Pikachu");
        juego1.AgregarPokemonesD("Pidgey");
        juego1.AgregarPokemonesA("Bulbasaur");
        juego1.IniciarEnfrentamiento();
        juego1.UsarMovimientos(1); //Jugador 1 usa Rayo y pidgey es debilitado
        juego1.UsarItem("Superpocion", 1); //Trata de curar a Pidgey
        double vidaEsperada2 = 0;
        Pokemon pidgey = juego1.GetPokemonActual();
        double vidaObtenida2 = pidgey.GetVidaActual();
        // Usar Superpoción para restaurar 70 HP 
        Assert.That(vidaObtenida2, Is.EqualTo(vidaEsperada2));
    }
    

    [Test]
    public void PokemonQuemado()
    {

        Menu Menu1 = new Menu();
        Menu1.UnirJugadores("Ansu");
        Menu1.UnirJugadores("Cima");
        Menu1.AgregarPokemonesA("Charmander");
        Menu1.AgregarPokemonesD("Squirtle");
        Menu1.IniciarEnfrentamiento();
        Menu1.UsarMovimientos(2); //El charmander hace lanzallamas al squirtle, no le hace daño pero lo quema
        Menu1.UsarMovimientos(4); // El squirtle hace protección
        double vidaesperadasquirtle = 72;
        double vidadada = Menu1.GetHpDefensor();
        Assert.That(vidaesperadasquirtle, Is.EqualTo(vidadada));
    }

    [Test]

    public void PokemonDormido()
    {

        Menu Menu1 = new Menu();
        Menu1.UnirJugadores("Ansu");
        Menu1.UnirJugadores("Cima");
        Menu1.AgregarPokemonesA("Pidgey");
        Menu1.AgregarPokemonesD("Squirtle");
        Menu1.IniciarEnfrentamiento();
        Menu1.UsarMovimientos(1); //El Pidgey hace vendaval y lo duerme
        Menu1.UsarMovimientos(1); // El squirtle trata de usar hidropulso pero no lo consigue, la vida del pidgey se mantiene intacta
        double vidaesperadasquirtle = 80;
        double vidadada = Menu1.GetHpDefensor();
        Assert.That(vidaesperadasquirtle, Is.EqualTo(vidadada));

    }

    [Test]
    public void TratoDeAtacarSinIniciarBatalla() //Verificacion Cambio de Pokemon de Turno
    {
        Menu juego3 = new Menu();
        juego3.UnirJugadores("Ash");
        juego3.UnirJugadores("Red");
        juego3.AgregarPokemonesA("Squirtle"); //Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        juego3.AgregarPokemonesD("Charmander");
        juego3.UsarMovimientos(1);
        Assert.That(juego3.GetHpDefensor(),Is.EqualTo(85));
    }

    [Test]
    /// <summary>
    /// Este test verifica la primer historia de usuario y verifica la historia de usuario que no suma a una lista a los usuarios que no pueden combatir
    /// </summary>
    public void NoAgregoPokemons()
    {
        Menu juego4 = new Menu();
        juego4.UnirJugadores("Don Dimadon");
        juego4.UnirJugadores("Timmy Turner");
        juego4.AgregarPokemonesD("Squirtle");
        juego4.IniciarEnfrentamiento();
        juego4.UsarMovimientos(1);
        double vidaDefensor = juego4.GetHpDefensor();
        Assert.That(vidaDefensor,Is.EqualTo(80));
    }

    [Test]
    

    public void JugadorUsaPocionParaPokemonConVidaCompleta()
    {
        Menu juego4 = new Menu();
        juego4.UnirJugadores("Don Dimadon");
        juego4.UnirJugadores("Bellota");
        juego4.AgregarPokemonesA("Charmander"); //85
        juego4.UsarItem("Superpocion", 1);
        int vidatotalCharmander = 85;
        Assert.That(vidatotalCharmander, Is.EqualTo(juego4.GetHpAtacante()));
    }

    [Test]
    /// <summary>
    /// Este test verifica la sexta historia de usuario ya que la batalla inicia y termina
    /// El mensaje impreso en programa pasará a ser un string pasado al bot de discord
    /// </summary>
    public void PierdoBatalla()
    {
        Menu juego6 = new Menu();
        juego6.UnirJugadores("Ash");
        juego6.UnirJugadores("Red");
        juego6.AgregarPokemonesA("Pikachu");
        juego6.AgregarPokemonesD("Pidgey");
        juego6.IniciarEnfrentamiento();
        juego6.UsarMovimientos(1); //Pikachu usa royo
        juego6.MostrarEstadoEquipo();
        bool batallaperdida = juego6.GetBatallaI() && juego6.GetBatallaT();
        bool batallaperdidasupuesta = true;
        Assert.That(batallaperdida, Is.EqualTo(batallaperdidasupuesta));
    }

    [Test]
    /// <summary>
    /// Este test verifica la  historia de usuario que nos permite usar varios items
    /// </summary>
    public void JugadorAgrega7Pokemons()
    {
        StringWriter consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        Menu juego1 = new Menu();
        juego1.UnirJugadores("Ash");
        juego1.UnirJugadores("Red");

        juego1.AgregarPokemonesA("Squirtle");
        juego1.AgregarPokemonesA("Pidgey");
        juego1.AgregarPokemonesA("Larvitar");
        juego1.AgregarPokemonesA("Caterpie");
        juego1.AgregarPokemonesA("Charmander");
        juego1.AgregarPokemonesA("Dratini");
        juego1.AgregarPokemonesA("Gengar");

        List<Pokemon> listapokemonsatacante = juego1.GetEquipoA();
        int numero = listapokemonsatacante.Count;

        Assert.That(6, Is.EqualTo(numero));

    }

}

