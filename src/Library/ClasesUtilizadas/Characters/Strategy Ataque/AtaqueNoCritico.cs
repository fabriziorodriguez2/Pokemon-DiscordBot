namespace Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;

public class AtaqueNoCritico:IAtaqueDanioStrategy
{
    public int GetNumero()
    {
        Random random = new Random();
        return random.Next(1,10);
    }
}