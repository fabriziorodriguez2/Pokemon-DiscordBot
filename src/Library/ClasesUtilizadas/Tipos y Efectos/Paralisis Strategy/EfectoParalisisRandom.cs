namespace Library.Tipos.Paralisis_Strategy;

public class EfectoParalisisRandom:IEfectoParalisisStrategy
{
    public bool GetValor()
    { 
        Random random = new Random();
        int numero= random.Next(1, 4);
        if(numero == 1)
        {
            return true;
        }
        return false;
    }
}