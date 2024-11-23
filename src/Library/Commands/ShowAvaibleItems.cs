using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class ShowAvaibleItems:ModuleBase<SocketCommandContext>
{
    ///<summary>
    /// Esta clase implementa el comando "showitems" del bot.
    /// Este comando retorna una lista de Items.
    /// </summary>
    [Command("showitems")]
    [Summary("Muestra la lista de item disponibles")]

    public async Task ExecuteAsync()
    {
        var result = Facade.Instance.ShowAviableItems();
        await ReplyAsync(result);
    }
}