namespace Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero necesario para que el ataque haga crítico
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor


public class AtaqueCritico:IAtaqueDanioStrategy
{
    public int GetNumero()
    {
        return 0;
    }
}