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
    private SuperPocion superpocion;
    private Revivir revivir;
    private CuraTotal curatotal;
    

    public InventarioItems()
    {
        items = new Dictionary<String, Item> //Crea un diccionario en el que registra cada item y cuanta cantidad hay de cada uno
        {
            { "SuperPocion",  superpocion = new SuperPocion(4) },
            { "Revivir", revivir = new Revivir(1) },
            { "CuraTotal", curatotal = new CuraTotal(2) }
        };
    }

    public void MostrarItems() //Imprime en pantalla cuales items y cuantos de cada uno le queda al jugador 
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key}: {item.Value.Cantidad} disponibles");
        }
    }

    public void UsarItem(string item, Pokemon pokemon) //Busca el item que le pasaste, llama al AplicarEfecto para que haga su efecto y baja en 1 su cantidad
    {
        if (items.ContainsKey(item) && items[item].Cantidad > 0)
        {
            if (item == "Superpocion") //Si escribiste Superpocion, llamará al curar del revivir
            {
                superpocion.AplicarEfecto(pokemon);
                items[item].Cantidad--;
            }
            if (item == "Revivir") //Si escribiste Revivir, llamará al revivir del jugador
            {
                revivir.AplicarEfecto(pokemon);
                items[item].Cantidad--;
            }
            if (item == "Curatotal")//Si escribiste Curatotal, llamará al CurarEstado del jugador
            {
                curatotal.AplicarEfecto(pokemon);
                items[item].Cantidad--;
            }
            else
            {
                Console.WriteLine("Seleccione una opcion correcta por favor, 'SuperPocion' para usar una superposión, 'Revivir' para usar un revivir o 'CuraTotal' para usar un curatotal");
            }
        }
        Console.WriteLine("Ítem no disponible o cantidad insuficiente.");
    }
}