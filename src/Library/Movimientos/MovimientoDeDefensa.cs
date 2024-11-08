using Library.Tipos;

namespace Ucu.Poo.Pokemon;
//MovimientoDeDefensa:
//Cumple con SRP: La clase MovimientoDeDefensa tiene una única responsabilidad: encapsular 
//la información relacionada con un movimiento de defensa, es decir, su nombre, su valor de 
//defensa y su tipo. No está sobrecargada con otras responsabilidades.
//Cumple con OCP: La clase está abierta para la extensión, ya que puedes crear nuevos tipos 
//de movimientos de defensa con diferentes valores para name, defensa y tipo. Está cerrada 
//para la modificación, ya que la lógica de la clase no requiere cambios para añadir nuevos 
//movimientos de defensa. Solo es necesario extender la clase si fuera necesario añadir 
//funcionalidades adicionales.
//Cumple con LSP: La clase MovimientoDeDefensa implementa correctamente la interfaz 
//IMovimientoDefensa. Puedes sustituir cualquier instancia de IMovimientoDefensa por una instancia 
//de MovimientoDeDefensa sin que se rompa el comportamiento del sistema, respetando el contrato de 
//la interfaz.
//Tiene alta cohesion, ya que todas sus propiedades y métodos están relacionados con un movimiento 
//defensivo.



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