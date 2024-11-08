using DefaultNamespace;

namespace Library.Combate;
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