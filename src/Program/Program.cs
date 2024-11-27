using Console = System.Console;
using System.Security.Cryptography;
using DefaultNamespace;
using Library.Combate;
using Library.Tipos.Paralisis_Strategy;
using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;
using Ucu.Poo.Pokemon;

namespace Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        
        //DemoFacade();
       // DemoBot();
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Stufful");
        menu.SetStrategyPresicion(new StrategyPreciso());
        Pokemon pikachu = menu.GetPokemonActual();
        pikachu.SetStrategy(new AtaqueNoCritico());
        Pokemon stufful = menu.GetPokemonRival();
        stufful.SetStrategy(new AtaqueNoCritico());
        menu.IniciarEnfrentamiento();
        Console.WriteLine(menu.UsarMovimientos(2));
        Console.WriteLine(menu.UsarMovimientos(2));
        string mensaje = menu.MostrarEstadoRival();

        Console.WriteLine(mensaje);
    }

    private static void DemoFacade()
    {
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
        Console.WriteLine(Facade.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
}