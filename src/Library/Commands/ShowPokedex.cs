using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{
    /// <summary>
    /// Esta clase implementa el comando 'showpokedex' del bot.
    /// Este comando permite a los jugadores ver el catálogo de Pokémon en la Pokédex
    /// mientras están en batalla.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class ShowPokedexCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'showpokedex'. Este comando muestra
        /// el catálogo de Pokémon de la Pokédex si el usuario está en batalla.
        /// </summary>
        [Command("showpokedex")]
        [Summary("Muestra el catálogo de Pokémon en la Pokédex mientras estás en batalla.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            string userName = CommandHelper.GetDisplayName(Context);
            string result = "";

            if (userName == Facade.Instance.JugadorA() || userName == Facade.Instance.JugadorD())
            {
                result = Facade.Instance.ShowCatolog();
            }
            else
            {
                result = "No estás en una batalla, no puedes ver el catálogo de Pokémon en este momento.";
            }

            // Envía el resultado al usuario
            await ReplyAsync(result);
        }
    }
}