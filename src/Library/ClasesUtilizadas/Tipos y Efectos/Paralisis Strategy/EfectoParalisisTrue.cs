namespace Library.Tipos.Paralisis_Strategy;
//Cumple con SRP ya que solo tiene la responsabilidad de setear el valor para que el pokemon no ataque estando paralizado.
//Cumple con Expert ya que tiene la información necesario para devolver dicho valor

public class EfectoParalisisTrue:IEfectoParalisisStrategy
{
    public bool GetValor()
    {
        return true;
    }
}