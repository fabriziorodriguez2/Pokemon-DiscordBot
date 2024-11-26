using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'changepokemon' del bot.
/// Permite al jugador cambiar el Pokémon en combate si es su turno
/// y está en una batalla.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ChangePokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'changepokemon'.
    /// </summary>
    [Command("changepokemon")]
    [Summary(
        """
        Cambia el Pokémon activo del jugador que envía el mensaje.
        Proporciona el índice del Pokémon en el equipo como parámetro.
        """)]
    public async Task ExecuteAsync([Summary("Índice del Pokémon a cambiar (0 basado)")] 
        int? pokemonIndex = null)
    {
        try
        {
            if (pokemonIndex == null)
            {
                await ReplyAsync("Debes especificar el índice del Pokémon que deseas usar. Ejemplo: `!changepokemon 1`.");
                return;
            }

            string userName = CommandHelper.GetDisplayName(Context);;

            if (userName == Facade.Instance.JugadorA())
            {
                string result = Facade.Instance.ChangePokemon(pokemonIndex.Value);

                await ReplyAsync(result);
            }
            else
            {
                await ReplyAsync("No estas en la batalla o no es tu turno master.");
            }
        }
        catch (Exception ex)
        {
            await ReplyAsync($"Ocurrió un error: {ex.Message}");
        }
    }
}
