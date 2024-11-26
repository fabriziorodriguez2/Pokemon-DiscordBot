StrategyParalisis
﻿using System.Security.Cryptography;
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
        Console.WriteLine(Facade.Instance.StartBattle("qcy", "manu¿"));
        Console.WriteLine(Facade.Instance.AddPokemosA("Charmander"));
        Console.WriteLine(Facade.Instance.AddPokemosD("Squirtle"));
        Facade.Instance.InitializeBattle();
        Pokemon squirtle = Facade.Instance.Menu.GetPokemonRival();
        squirtle.SetStrategy(new AtaqueCritico());
        Console.WriteLine(Facade.Instance.UsePokemonMove(2)); //usa un ataque especial que hace 70/2 de daño
        
        //DemoFacade();
        //DemoBot();
 StrategyParalisis
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        Pokemon charmander = menu.GetPokemonRival();
        charmander.SetStrategy(new AtaqueNoCritico());
        Pokemon pikachu = menu.GetPokemonActual();
        IMovimiento rayo = pikachu.GetListaMovimientos()[0];
        if (rayo is IMovimientoEspecial especial)
        {
            especial.SetStrategyParalisis(new EfectoParalisisTrue());
            string mensaje= menu.UsarMovimientos(1);
            Console.WriteLine(mensaje);
        }

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