using DefaultNamespace;

namespace Library.Tipos;
//Efecto:
//Cumple con SRP: La clase Efecto tiene la responsabilidad de representar efectos que se aplican sobre un 
//Pokemon.
//OCP: La clase Efecto está abierta a la extensión, pero cerrada a la modificación. Si se crean nuevas 
//subclases que representan tipos específicos de efectos, no es necesario modificar la clase Efecto para 
//agregarlos. Esto se logra al definir HacerEfecto como un método virtual que puede ser sobrecargado en 
//clases derivadas.
//LSP: Cualquier subclase de Efecto puede ser sustituida por una instancia de Efecto, y el comportamiento 
//general del sistema no se verá afectado.
//Polimorfismo: Gracias al uso de HacerEfecto como método virtual, las subclases pueden sobrescribirlo 
//para proporcionar su propia implementación. Esto permite aplicar el polimorfismo y gestionar diferentes 
//tipos de efectos de manera uniforme.


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