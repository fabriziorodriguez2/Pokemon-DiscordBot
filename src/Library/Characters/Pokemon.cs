using Library.Combate;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace DefaultNamespace;

public class Pokemon
{
    private string name;
    private List<IMovimiento> listaMovimientos;
    private List<Tipo> listaTipos;
    private double vidaActual;
    private double vidaTotal;
    private double defensa;
    private bool isAlive;
    private Efecto estado;
    private bool puedeAtacar;
    

    public Pokemon(string nombre, List<IMovimiento> movimientos, List<Tipo> tipos, double vida, double defensa)
    {
        name = nombre;
        listaMovimientos = movimientos;
        listaTipos = tipos;
        vidaActual = vida;
        vidaTotal = vida;
        isAlive = true;
        this.defensa = defensa;
        puedeAtacar = true;
    }

    public void HacerEfectoPokemon(Pokemon pokemon)
    {
        estado.HacerEfecto(pokemon);
    }

    public List<Tipo> GetTipos()
    {
        return listaTipos;
    }
    
    public bool GetIsAlive()
    {
        return isAlive;
    }

    public string GetName()
    {
        return name;
    }
    
    public List<IMovimiento> GetListaMovimientos()
    {
        return listaMovimientos;
    }

    public double GetVidaTotal()
    {
        return vidaTotal;
    }

    public double GetVidaActual()
    {
        return vidaActual;
    }

    // Método para usar un movimiento, incluyendo los de defensa
    public void UsarMovimiento(IMovimiento movimiento)
    {
        if (isAlive)
        {
            foreach (IMovimiento accion in listaMovimientos)
            {

                if (accion.GetName() == movimiento.GetName() && movimiento is IMovimientoAtaque ataque)
                {
                    if (ataque is MovimientoDeAtaque) //Verifica si el movimiento usado en este momento Es de Ataque y no especial
                    {
                        foreach (IMovimiento mov in listaMovimientos)//Recorre todoslos movimientos de lalista hasta dar con el especial
                        {
                            if (mov is IMovimientoEspecial movesp)
                            {
                                movesp.UsadoAnteriormente(false);//Pone su estado de Uado anteriormente en false, ya que en este ataque se uso un movimiento comun y no uno especial
                            }
                        }
                    }
                }
                if (movimiento is IMovimientoDefensa defensamovimiento)
                {
                    defensa += defensamovimiento.GetDefensa();
                    Console.WriteLine($"{GetName()} ha usado su {movimiento.GetName()} para subir su defensa {defensamovimiento.GetDefensa()} puntos");
                }
            }
        }
    }
    
    public void RecibirAtaque(IMovimientoAtaque movimiento)
    {
        double efectividadTipo = 1.0;
        Tipo tipoAtaque = movimiento.GetTipo();

        foreach (Tipo tipoDefensor in listaTipos)
        {
            efectividadTipo *= tipoAtaque.DarEfectividad(tipoDefensor);
        }

        double danio = (movimiento.GetAtaque() * efectividadTipo);
        int numero = new Random().Next(10);
        if (numero == 0)
        {
            danio *= 1.2;
            Console.WriteLine($"Ha sido un ataque crítico");
        }
        
        // Aplicar el daño a la defensa o vida o un poco y un poco
        if (defensa > danio)
        {
            defensa -= danio;
            Console.WriteLine($"{GetName()} ha perdido {danio} de defensa, quedandose a {defensa} de defensa y {vidaActual} de vida");
        }
        else
        {
            danio -= defensa; // Resta el daño restante a la vida
            defensa = 0;
            vidaActual -= danio;
            if (vidaActual <= 0)
            {
                isAlive = false;
                vidaActual = 0;
                Console.WriteLine($"El pokemon {name} se ha debilitado, por que no podrá combatir más");
                return;
            }
            Console.WriteLine($"{GetName()} ha perdido toda su defensa y se ha quedado con {vidaActual}");
        }
        if (movimiento is IMovimientoEspecial movimientoEspecial)
        {
            AgregarEfecto(movimientoEspecial.GetEfecto());
        }
    }

    public void RecibirDanioDeEfecto(double numero)
    {
        double porcentaje = (numero *this.vidaTotal) / 100;
        this.vidaActual -= porcentaje;
        Console.WriteLine($"{GetName()} ha recibido {porcentaje} de daño adicional");
    }

    public void SetPuedeAtacar(bool valor) //Funciona para cambiar el valor dentro de los efectos de paralisis y de dormir
    {
        puedeAtacar = valor; 
    }

    public void AgregarEfecto(Efecto efecto)
    {
        if (estado == null)
        {
            estado = Efecto.CrearCopia(efecto.GetType()); // Usa el tipo del efecto para crear una nueva instancia
            Console.WriteLine($"{GetName()} caído bajo el efecto {efecto.GetType().Name}");
        }
    }
    public void EliminarEfectoActual()
    {
        estado = null;
        // Acá iría el método para eliminar el cambio de estado del pokemon
    }

    public Efecto GetEfecto()
    {
        return estado;
    }
    public void Curar(int vidacurada)
    {
        this.vidaActual += vidacurada;
        if (vidaActual > vidaTotal)
        {
            vidaActual = vidaTotal;
        }
    }

    public void Revivir()
    {
        this.vidaActual = vidaTotal/2;
    }

    public bool GetPuedeAtacar()
    {
        return puedeAtacar;
    }

    public double GetDefensa()
    {
        return this.defensa;
    }
    
}