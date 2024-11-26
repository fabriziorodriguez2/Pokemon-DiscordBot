using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;

public class AtaqueRandom : IAtaqueDanioStrategy
{
    private static readonly Random random = new Random(); // Instancia compartida

    public int GetNumero()
    {
        return random.Next(10); // Genera un número entre 0 y 9.
    }
}