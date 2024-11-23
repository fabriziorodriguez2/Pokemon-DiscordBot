using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showplayerstatus' del bot.
/// Permite al jugador obtener el estado actual de su equipo Pokémon.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ShowPokemonAvailable : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'Playerstatus'.
    /// </summary>
    [Command("ShowPokemonDisponibles")]
    [Summary(
        """Muestra el equipo del ususario que realizó el usuario y qué número tiene cada pokemon""")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        {
            try
            {
                string userName = CommandHelper.GetDisplayName(Context);;

                if (userName == Facade.Instance.JugadorA())
                {
                    string team = Facade.Instance.ShowPokemonNum();

                    await ReplyAsync(team);
                }
                else
                {
                    // El jugador no está en la batalla o no es su turno
                    await ReplyAsync("No estás actualmente en una batalla o no es tu turno master");
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}