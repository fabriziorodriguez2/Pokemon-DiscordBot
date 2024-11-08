using Library.Tipos;

namespace Ucu.Poo.Pokemon;
//MovimientoEspecial:
//SRP:  La clase MovimientoEspecial tiene una sola responsabilidad: encapsular la información sobre 
//un movimiento especial, que incluye el nombre, ataque, tipo, precisión, efecto y si ha sido usado 
//previamente. No tiene otras responsabilidades.
//Cumple con OCP: La clase está abierta a la extensión. Se pueden agregar más movimientos especiales 
//creando nuevas instancias de MovimientoEspecial con diferentes parámetros (nombre, ataque, tipo, 
//precisión, efecto). Está cerrada a la modificación, lo que significa que no es necesario cambiar 
//la clase para agregar nuevos tipos de movimientos especiales.
//LSP: La clase MovimientoEspecial implementa correctamente la interfaz IMovimientoEspecial.Cualquier 
//instancia de IMovimientoEspecial se puede sustituir por una instancia de MovimientoEspecial sin 
//romper el comportamiento del sistema.
// La clase tiene alta cohesión, ya que todos sus atributos y métodos están estrechamente relacionados 
//con el concepto de un movimiento especial.
//Al implementar la interfaz IMovimientoEspecial, la clase puede ser tratada de manera polimórfica. 
//Esto significa que se pueden gestionar diferentes tipos de movimientos especiales sin saber qué tipo 
//específico se está utilizando.



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