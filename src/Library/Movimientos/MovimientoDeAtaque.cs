using Library.Tipos;

namespace Ucu.Poo.Pokemon;

//Clase MovimientoDeAtaque:
//Cumple con el SRP porque tiene una sola tarea: representar un ataque en el juego. 
//Es un experto en su información, ya que maneja todo lo necesario para un movimiento 
//de ataque (como el nombre, el daño, el tipo y la precision). 
//Usa polimorfismo al implementar la interfaz IMovimientoAtaque, lo que le permite 
//ser utilizada de manera flexible en otras partes del código. 
//Además, sigue el LSP, ya que se puede usar en lugar de cualquier otra clase que 
//implemente la misma interfaz sin causar problemas.


public class MovimientoDeAtaque: IMovimientoAtaque
{
    private string name { get; set; }
    private int ataque { get; set; }
    private Tipo tipo { get; set; }
    
    private int precision { get; set; }

    public MovimientoDeAtaque(string name, int ataque, Tipo tipo, int precision)
    {
        this.name = name;
        this.ataque = ataque;
        this.tipo = tipo;
        this.precision = precision;
    }
    public int GetAtaque()
    {
        return ataque;
    }

    public string GetName()
    {
        return name;
    }

    public Tipo GetTipo()
    {
        return tipo;
    }

    public int GetPrecision()
    {
        return precision;
    }
}