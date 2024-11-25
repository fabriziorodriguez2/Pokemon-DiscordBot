namespace Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;

public class AtaqueRandom:IAtaqueDanioStrategy
{
    public int GetNumero()
    {
        Random random = new Random();
        return random.Next(10);
    }
}