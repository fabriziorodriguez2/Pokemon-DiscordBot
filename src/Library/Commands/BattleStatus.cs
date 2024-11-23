using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class BattleStatus: ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Esta clase implementa el comando 'batllestatus' del bot.
    /// Este comando permite a los jugadores ver el estado de la batalla.
    /// </summary>
    [Command("battlestatus")]
    [Summary("Muestra el estado de la batalla")]
    public async Task ExecuteAsync()
    {
        var result = Facade.Instance.IsBattleOngoing();
        if (result)
        {
            string respuesta = "La batalla sigue en pie";
            await ReplyAsync(respuesta);
        }
        else
        {
            await ReplyAsync("La batalla ha terminado");
        }
    }
}