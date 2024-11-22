using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'isbattleongoing' del bot.
/// Permite a un jugador consultar si la batalla está activa.
/// </summary>
// ReSharper disable once UnusedType.Global
public class BattleOngoingCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'isbattleongoing'.
    /// </summary>
    [Command("isbattleongoing")]
    [Summary(
        """
        Verifica si actualmente hay una batalla activa.
        Devuelve 'true' si hay una batalla en curso y 'false' si no.
        """)]
    public async Task ExecuteAsync()
    {
        try
        {
            bool isOngoing = Facade.Instance.IsBattleOngoing();

            if (isOngoing)
            {
                await ReplyAsync("Sí, actualmente hay una batalla activa.");
            }
            else
            {
                await ReplyAsync("No, no hay ninguna batalla activa en este momento.");
            }

        }
        catch (Exception ex)
        {
            await ReplyAsync($"Ocurrió un error al verificar el estado de la batalla: {ex.Message}");
        }
    }
}