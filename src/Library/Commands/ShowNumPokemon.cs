using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'name' del bot. Este comando retorna el
/// nombre de un Pokémon dado su identificador.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ShowNumCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'Playerstatus'.
    /// </summary>
    [Command("ShowPokemonNum")]
    [Summary(
        """Muestra el equipo del ususario que realizó el usuario y qué número tiene cada pokemon""")]
    public async Task ExecuteAsync()
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