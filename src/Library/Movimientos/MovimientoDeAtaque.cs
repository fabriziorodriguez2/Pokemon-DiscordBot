using Library.Tipos;

namespace Ucu.Poo.Pokemon;

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