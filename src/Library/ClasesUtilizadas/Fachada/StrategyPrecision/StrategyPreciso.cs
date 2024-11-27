namespace Library.Combate;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero necesario para que el ataque acierte
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

public class StrategyPreciso:IStrategyPresicion
{
    public int GetNumber()
    {
        return 1;
    }
}