using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'waitinglist' del bot. Este comando muestra
/// la lista de jugadores esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ShowMovAvailable : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'waitinglist'. Este comando muestra la lista de
    /// jugadores esperando para jugar.
    /// </summary>
    [Command("ShowMov")]
    [Summary("Muestra los movimientos que podría utilizar el jugador en su turno")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        try
        {
                string userName = CommandHelper.GetDisplayName(Context);
                if (userName == Facade.Instance.JugadorA())
                {
                    var result = Facade.Instance.ShowAvailableMoves();
                    await ReplyAsync(result);
                    return;
                }
                if (userName == Facade.Instance.JugadorD())
                {
                    await ReplyAsync("Espera que sea tu turno para ver tus ataques");
                    return;
                }
                await ReplyAsync("No se ha encontrado al jugador.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en el comando showmov: {ex.Message}");
            await ReplyAsync("Ocurrió un error al intentar mostrar los movimientos. Inténtalo de nuevo más tarde.");
        }
    }
}