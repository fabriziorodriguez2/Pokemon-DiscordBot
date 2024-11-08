using Library.Tipos;

namespace Ucu.Poo.Pokemon;

public class MovimientoEspecial : IMovimientoEspecial
{
    private string name { get; set; }
    private int ataque { get; set; }
    private Efecto efecto { get; set; }
    private Tipo tipo { get; set; }
    private int precision { get; set; }
    private bool usadoAnteriormente { get; set; }
    public MovimientoEspecial(string name, int ataque, Tipo tipo, int precision, Efecto efecto)
    {
        this.name = name;
        this.ataque = ataque;
        this.tipo = tipo;
        this.precision = precision;
        this.efecto = efecto;
    }
    public void UsadoAnteriormente(bool valor) //Setea el valor de los ataques especiales para saber si se pueden usar
    { 
        usadoAnteriormente = valor; 
    }
    public int GetAtaque()
    {
        return ataque;
    }
    
    public bool GetUsadoAnteriormente()
    {
        return usadoAnteriormente;
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
    public Efecto GetEfecto()
    {
        return efecto;
    }
    
}