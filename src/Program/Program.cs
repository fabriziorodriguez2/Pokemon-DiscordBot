using Library.Combate;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;

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
        Console.WriteLine(Facade.Instance.InitializeBattle());
        Console.WriteLine(Facade.Instance.UsePokemonMove(2)); //usa un ataque especial que hace 70/2 de daño
        Console.WriteLine(Facade.Instance.UsePokemonMove(4));
        Console.WriteLine(Facade.Instance.UsePokemonMove(2));
        //DemoFacade();
        //DemoBot();
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