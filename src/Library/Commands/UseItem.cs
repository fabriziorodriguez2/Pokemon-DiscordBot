using AdapterNamespace;
using static DefaultNamespace.Pokemon;
using Discord.Commands;
using Library.Combate;
using Ucu.Poo.DiscordBot.Domain;
using Library.Tipos;
using Ucu.Poo.Pokemon;
namespace Ucu.Poo.DiscordBot.Commands;

public class UseItem: ModuleBase<SocketCommandContext>
{
    [Command("useitem")]
    [Summary("Usa un item disponible del jugador en el pokemon elegido segun su numero")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Summary("Nombre del Item")] string item, 
        [Remainder][Summary("Nombre del Item")] int pokemon)
    {
        try
        {
            string nameplayer =  CommandHelper.GetDisplayName(Context);
            if (nameplayer == Facade.Instance.JugadorA())
            {
                await ReplyAsync(Facade.Instance.UseItem(item.ToLower(), pokemon));
            }
            else
            {
                await ReplyAsync("No es tu turno capo, no te toca");
            }
        }
        catch (FormatException ex)
        {
            await ReplyAsync("El formato de la cadena no es válido.");
        }
    }
}