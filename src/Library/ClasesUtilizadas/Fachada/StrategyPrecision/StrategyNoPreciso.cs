namespace Library.Combate;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero necesario para que el ataque no acierte
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

public class StrategyNoPreciso:IStrategyPresicion
{
    public int GetNumber()
    {
        return 100;
    }
}