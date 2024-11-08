using DefaultNamespace;

namespace Library.Tipos;

public class Efecto
{
    protected Efecto()
    {
        
    }

    public virtual void HacerEfecto(Pokemon pokemon)
    {
        
    }

    public static Efecto CrearCopia(Type tipoEfecto)
    {
        return (Efecto)Activator.CreateInstance(tipoEfecto);
    }
}