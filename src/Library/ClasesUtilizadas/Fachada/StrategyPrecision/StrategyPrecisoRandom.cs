namespace Library.Combate;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero en donde no importa si el ataque acierta  o no
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

public class StrategyPrecisoRandom : IStrategyPresicion
{
    public int GetNumber()
    {
        Random random = new Random();
        return random.Next(1, 101);
    }
}