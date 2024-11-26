using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;

public class AtaqueNoCritico : IAtaqueDanioStrategy
{
    public int GetNumero()
    {
        return 1; // Siempre devuelve no crítico.
    }
}