namespace Library.Combate;

public class StrategyPrecisoRandom : IStrategyPresicion
{
    public int GetNumber()
    {
        Random random = new Random();
        return random.Next(1, 101);
    }
}