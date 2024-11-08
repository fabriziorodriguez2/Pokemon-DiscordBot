using System;
using System.Collections.Generic;
using DefaultNamespace;
using Library.Combate;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Program.Tests.Combate;

[TestFixture]
// [TestSubject(typeof(Menu))]
public class MenuTest
{
    [Test]
    public void PikachuDañaAPidgey()
    {
        // 95 de daño del ataque rayo * efectividad (2) 
        int vidaesperada = 0; // tiene 60 de vida y 40 de defensa así que aguantría un golpe de 99 de daño como mucho 
        Menu menuPP = new Menu();
        menuPP.UnirJugadores("Ash");
        menuPP.UnirJugadores("Red");
        menuPP.AgregarPokemonesA("Pikachu");
        menuPP.AgregarPokemonesD("Pidgey");
        menuPP.IniciarEnfrentamiento();
        menuPP.UsarMovimientos(1); //Pikachu usa royo
        Assert.That(vidaesperada,Is.EqualTo(menuPP.GetHpAtacante())); // Verificar que la vida de Pidgey es 0
        Assert.That(80,Is.EqualTo(menuPP.GetHpDefensor())); // Verificar que Pikachu mantiene su HP
    }
    [Test]
    public void PidgeyPorCharmanderParaAguantarAPikachu()
    {
        // Arrange
        double dañoPorAtaque = 65; // Daño de rayo
        double defensaCharmander = 60; // Defensa de Charmander
        double hpCharmander = 85; // Charmander arranca con 85 de vida
        double vidaCharmanderRestanteEsperada = hpCharmander - (dañoPorAtaque - defensaCharmander); // Calculos de supuesta vida charmander
        double vidaPidgeyEsperada = 60; // Pidgey debería iniciar con 60 de vida

        Menu menuPP = new Menu();
        menuPP.UnirJugadores("Ash");
        menuPP.UnirJugadores("Red");
        menuPP.AgregarPokemonesA("Pidgey"); 
        menuPP.AgregarPokemonesD("Pikachu");
        menuPP.AgregarPokemonesA("Charmander");
        menuPP.IniciarEnfrentamiento();
        menuPP.CambiarPokemon(1); // Cambia a Charmander
        menuPP.UsarMovimientos(2);//Pikachu usa rayo, danio de rayo: 65, defensa de Charmander: vida 85, defensa: 60
        
        Assert.That(vidaCharmanderRestanteEsperada,Is.EqualTo(menuPP.GetHpAtacante())); // Verificar que la vida de Charmander es la esperada
        menuPP.CambiarPokemon(1);//Cambio a Pidgey, pasa a ser defensor al usar su turno
        menuPP.UsarMovimientos(4);//Pikachu usa proteccion
        Assert.That( menuPP.GetHpAtacante(),Is.EqualTo(vidaPidgeyEsperada)); //Verifica que pidgey sigue intecto
    }
    [Test]
    //  REVISAR ESTOOOOOOO
    public void BulbasaurPorSquirtleParaAguantarAPikachu()
    {
        int dañoPorAtaque = 95 / 2 ;
        int defensaBulbasaur = 70; 
        int hpBulbasaurEsperado = 90;
        int vidabulbasaurRestanteEsperada = 90; // Sabemos que no alzcanza para romper su defensa
        int vidatortugaEsperada = 80; 

        Menu menuPP = new Menu();
        menuPP.UnirJugadores("Ash");
        menuPP.UnirJugadores("Red");
        menuPP.AgregarPokemonesA("Squirtle"); 
        menuPP.AgregarPokemonesD("Pikachu"); 
        menuPP.AgregarPokemonesA("Bulbasaur"); 
        menuPP.IniciarEnfrentamiento();
        menuPP.CambiarPokemon(1); // Cambia a bulbasaur
        menuPP.UsarMovimientos(2); // Pikachu usa rayo, daño de 65/2 = 32,5 
            
            
        Assert.That(vidabulbasaurRestanteEsperada,Is.EqualTo(menuPP.GetHpAtacante())); // Verificar que la vida de bulbasour es la esperada
        menuPP.CambiarPokemon(1); // Cambiar a Squirtle
        Assert.That(vidatortugaEsperada,Is.EqualTo(menuPP.GetHpDefensor())); //Verifica que bulbasaur sigue intecto
    }
    [Test]
    public void Especial() //En este test se puede ver que cuando eljugador 1 intenta usar el ataque especial de nuevo no puede hacerlo
    {
        Menu juego1 = new Menu();
        juego1.UnirJugadores("Ash");
        juego1.UnirJugadores("Red");
        juego1.AgregarPokemonesA("Pikachu");
        
        juego1.AgregarPokemonesD("Caterpie");
        
        juego1.IniciarEnfrentamiento();
        juego1.UsarMovimientos(1);//Jugador 1 usa Rayo(especial), vida del contrincante en 45
        juego1.UsarMovimientos(1);//Jugador2 usa picotazo cola
        juego1.UsarMovimientos(1);//Jugador 1 intenta usar el Rayo nuevamente pero no puede, vida del contrincante se mantiene
        int vidaesperadadefensor = 5;
        double vidaObtenidaDefensor = juego1.GetHpDefensor();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }
    
    [Test]
    public void Inmune() //En este test se puede ver que cuando un Pokemon que es inmune a otro es atacado, su vida no se ve afectada
    {
        Menu juego1 = new Menu();
        juego1.UnirJugadores("Ash");
        juego1.UnirJugadores("Red");
        juego1.AgregarPokemonesA("Pikachu");
        //Usamos a pikachu porque electrico es inmune a electrico y el ataque Rayo es de tipo electrico
        juego1.AgregarPokemonesD("Pikachu");
        
        juego1.IniciarEnfrentamiento();
        juego1.UsarMovimientos(1);//Jugador 1 usa Rayo(electrico)
        juego1.UsarMovimientos(1);//Jugador2 usa Rayo(electrico)
        int vidaesperadadefensor = 80;
        double vidaObtenidaDefensor = juego1.GetHpDefensor();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }

    [Test]
    public void Defensa()//Demuestra que defensa nohace daño
    {
        Menu juego2 = new Menu();
        juego2.UnirJugadores("Ash");
        juego2.UnirJugadores("Red");
        juego2.AgregarPokemonesA("Pikachu");
        juego2.AgregarPokemonesD("Charmander");
        juego2.IniciarEnfrentamiento();
        juego2.UsarMovimientos(4);//El movimiento 4 siempre es de defensa, por lo que no provoca daño al contrincante
        double vidaesperadadefensor = 80;
        double vidaObtenidaDefensor = juego2.GetHpDefensor();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }

    [Test]
    public void CambioPokemon()//Verificacion Cambio de Pokemon de Turno
    {
        Menu juego3 = new Menu();
        juego3.UnirJugadores("Ash");
        juego3.UnirJugadores("Red");
        juego3.AgregarPokemonesA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        juego3.AgregarPokemonesD("Charmander");
        juego3.AgregarPokemonesA("Bulbasaur");//Bulbasaur era el segundo pokemon del equipo
        juego3.IniciarEnfrentamiento();
        juego3.CambiarPokemon(1);//Bulbasaur para a ser el Pokemon en Turno
        juego3.UsarMovimientos(1);
        string pokemonesperado = "Bulbasaur";
        string pokemonobtenido = juego3.GetPokemonActual().GetName();
        Assert.That(pokemonesperado,Is.EqualTo(pokemonobtenido));
    }

    [Test]
    public void Agrego6Pokemons()
    {
        Menu juego4 = new Menu();
        juego4.UnirJugadores("Don Dimadon");
        juego4.UnirJugadores("Timmy Turner");
        juego4.AgregarPokemonesA("Charmander");
        juego4.AgregarPokemonesA("Squirtle");
        juego4.AgregarPokemonesA("Bulbasaur");
        juego4.AgregarPokemonesA("Dratini");
        juego4.AgregarPokemonesA("Arbok");
        juego4.AgregarPokemonesA("Charmander");
        //List<Pokemon> listadada = juego4.(); falta getear el equipo del atacantes
        List<string> listadadaAstring = new List<string>();
        foreach (Pokemon pokemon in juego4.GetEquipoA())
        {
            listadadaAstring.Add(pokemon.GetName());
        }
        List<string> listaesperada = new List<string>
        {
            "Charmander",
            "Squirtle",
            "Bulbasaur",
            "Dratini",
            "Arbok",
            "Charmander"
        };

        foreach (string nombre in listaesperada)
        {
            Assert.That(listadadaAstring, Does.Contain(nombre));
        }
        
        // CollectionAssert.AreEqual(listaesperada,listadadaAstring);
    }

    [Test]
    public void VeoHPDeMisPokemonsYPokemonsOponentes()
    {
        Menu juego4 = new Menu();
        juego4.UnirJugadores("Don Dimadon");
        juego4.UnirJugadores("Bellota");
        juego4.AgregarPokemonesA("Charmander");//85
        juego4.AgregarPokemonesD("Squirtle");//80
        string vidasdadas= $"{juego4.GetHpAtacante()}/{juego4.GetHpDefensor()}";
        string vidasesperadas = "85/80";
        Assert.That(vidasdadas, Is.EqualTo(vidasesperadas));
        // Assert.AreEqual(vidasesperadas,vidasdadas);
    }

    [Test]
    public void VeoAtaquesDisponiblesDeMisPokemones()
    {
        Menu juego5 = new Menu();
        juego5.UnirJugadores("Bombon");
        juego5.UnirJugadores("Burbuja");
        juego5.AgregarPokemonesA("Bulbasaur");
        string textoEsperado =
            $"El Pokémon Bulbasaur tiene los siguientes movimientos:\nLluevehojas\nBombaLodo\nGolpe Cuerpo\nProtección";
        //Assert.That(juego5.MostrarAtaquesDisponibles(),Is.EqualTo(textoEsperado)); HAY QUE CAMBIAR EL METODO MOSTRAR ATAQUES A STRING PARA SER COMPARABLE
    }

    [Test]
    public void GanoBatalla()
    {
        Menu juego6 = new Menu();
        juego6.UnirJugadores("Ash");
        juego6.UnirJugadores("Red");
        juego6.AgregarPokemonesA("Pikachu");
        juego6.AgregarPokemonesD("Pidgey");
        juego6.UsarMovimientos(1); //Pikachu usa royo
        juego6.MostrarEstadoRival();
        juego6.UsarMovimientos(3);
    }

    public void UsoItemEnBatalla()
    {
        Menu juego6 = new Menu();
        juego6.UnirJugadores("Ash");
        juego6.UnirJugadores("Red");
        juego6.AgregarPokemonesA("Pikachu");
        juego6.AgregarPokemonesD("Pidgey");
        //juego6.UsarItem();
    }
}
