namespace Library.Tipos.Paralisis_Strategy;

public class EfectoParalisisFalse:IEfectoParalisisStrategy
{
    public bool GetValor()
    {
        return false;
    }
}