using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showopponentstatus' del bot.
/// Permite al jugador obtener el estado actual del equipo del oponente.
/// </summary>
// ReSharper disable once UnusedType.Global
public class OpponentStatusCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'opponentstatus'.
    /// </summary>
    [Command("OpponentStatus")]
    [Summary(
        """
        Muestra el estado actual del equipo Pokémon del oponente
        al jugador que envía el comando.
        """)]
    public async Task ExecuteAsync()
    {
        try
        {
            string userName = CommandHelper.GetDisplayName(Context);

            if (userName == Facade.Instance.JugadorA())
            {
                string opponentStatus = Facade.Instance.ShowOpponentStatus();

                await ReplyAsync(opponentStatus);
            }
            else
            {
                await ReplyAsync("No estás actualmente en una batalla o no es tu turno master");
            }
        }
        catch (Exception ex)
        {
            await ReplyAsync($"Ocurrió un error: {ex.Message}");
        }
    }
}