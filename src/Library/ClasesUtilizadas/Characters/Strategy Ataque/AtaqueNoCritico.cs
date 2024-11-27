using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
//Cumple con SRP ya que solo tiene la responsabilidad de setear el numero necesario para que el ataque no haga crítico
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

public class AtaqueNoCritico : IAtaqueDanioStrategy
{
    public int GetNumero()
    {
        return 1; // Siempre devuelve no crítico.
    }
}