using Library.Tipos;

namespace Ucu.Poo.Pokemon;

public class MovimientoDeDefensa : IMovimientoDefensa
{
    private string name { get; set; }
    private int defensa { get; set; }
    private Tipo tipo { get; set; }
    
    public MovimientoDeDefensa(string name, int defensa, Tipo tipo, bool es_especial)
    {
        this.name = name;
        this.defensa = defensa;
        this.tipo = tipo;
    }

    public int GetDefensa()
    {
        return this.defensa;
    }
    public string GetName()
    {
        return this.name;
    }

    public Tipo GetTipo()
    {
        return this.tipo;
    }
   
}