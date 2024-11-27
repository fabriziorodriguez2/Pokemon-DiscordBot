namespace Library.Tipos.Paralisis_Strategy;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un valor en donde no importa si el pokemon ataca o no estando paralizado.
//Cumple con Expert ya que tiene la información necesario para devolver dicho valor
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