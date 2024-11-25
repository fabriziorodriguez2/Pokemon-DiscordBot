using DefaultNamespace;

namespace Library.Combate;
//Clase InventarioItems:
//Cumple con alta chesion, ya que tiene una responsabilidad única, que es gestionar los ítems del jugador (registrar, 
//mostrar y usar ítems). La clase es coherente, ya que solo maneja los aspectos relacionados con el inventario de ítems, 
//sin involucrarse en otras responsabilidades. Tambien cumple con SRP por la misma razon.
//El método UsarItem utiliza polimorfismo al llamar a AplicarEfecto de la clase Item, que es un método polimórfico. Esto 
//permite que, dependiendo del tipo de ítem, se ejecute el comportamiento específico sin tener que modificar la lógica en 
//la clase InventarioItems.
//Cumple con OCP, ya que la clase está abierta a la extensión (por ejemplo, se pueden agregar nuevos tipos de ítems como 
//nuevas clases que heredan de Item), pero está cerrada a la modificación, ya que no es necesario modificar InventarioItems 
//para agregar nuevos ítems.
//Cumple con LSP: Cualquier clase que herede de Item puede ser usada en lugar de un Item sin afectar el comportamiento del 
//sistema. Si se agrega un nuevo tipo de ítem, se puede manejar dentro de InventarioItems sin problemas.


public class InventarioItems
{
    private Dictionary<String, Item> items;
    private Superpocion superpocion;
    private Revivir revivir;
    private Curatotal curatotal;
    
    /// <summary>
    /// Constructor que inicializa el inventario con una lista de ítems predefinidos.
    /// </summary>
    public InventarioItems()
    {
        items = new Dictionary<String, Item> //Crea un diccionario en el que registra cada item y cuanta cantidad hay de cada uno
        {
            { "superpocion",  superpocion = new Superpocion(4) },
            { "revivir", revivir = new Revivir(1) },
            { "curatotal", curatotal = new Curatotal(2) }
        };
    }

    public Dictionary<String, Item> GetItemInInventory()
    {
        return this.items;
    }
    /// <summary>
    /// Muestra en consola los ítems disponibles en el inventario y su cantidad.
    /// </summary>
    public string MostrarItems() //Imprime en pantalla cuales items y cuantos de cada uno le queda al jugador 
    {
        string texto = "";
        foreach (var item in items)
        {
            texto += $"{item.Key}: {item.Value.GetCantidad()} disponibles\n";
        }

        if (texto == "")
        {
            return "No tienes más items disponibles";
        }

        return texto;
    }

    /// <summary>
    /// Utiliza un ítem del inventario para aplicar su efecto sobre el Pokémon.
    /// </summary>
    /// <param name="item">El nombre del ítem a usar.</param>
    /// <param name="pokemon">El Pokémon al que se le aplicará el efecto del ítem.</param>
    public string UsarItem(string item, Pokemon pokemon) //Busca el item que le pasaste, llama al AplicarEfecto para que haga su efecto y baja en 1 su cantidad
    {
        
        Item it = items[item]; // Obtiene el ítem
        switch (item.ToLower())
        {
            case "superpocion":
                if (!pokemon.GetIsAlive())
                    throw new CureException("El Pokémon está debilitado y no puede ser curado.");
                if (pokemon.GetVidaActual() == pokemon.GetVidaTotal())
                    throw new OverflowException("El pokemon ya tiene su vida máxima");
                it.SetCantidad();
                return superpocion.AplicarEfecto(pokemon);
            case "revivir":
                if (pokemon.GetIsAlive())
                    throw new ReviveException("El Pokémon está vivo y no puede ser revivido.");
                it.SetCantidad();
                return revivir.AplicarEfecto(pokemon);
            case "curatotal":
                if (!pokemon.GetIsAlive())
                    throw new CureException("El Pokémon está debilitado y no puede ser curado.");
                if (pokemon.GetEfecto() == null)
                    throw new NullReferenceException("El pokemon no está bajo ningún efecto");
                it.SetCantidad();
                return curatotal.AplicarEfecto(pokemon);
            default:
                return "Seleccione una opción correcta: 'Superpocion', 'Revivir' o 'Curatotal'";
        }
    }
}