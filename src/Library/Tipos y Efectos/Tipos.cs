using System.Collections.Generic;

namespace Library.Tipos
{
    //Tipo:
//tiene una única responsabilidad, que es gestionar las efectividades entre tipos, por lo que cumple bien con el 
//principio de responsabilidad única.
//OCP: La clase está abierta a modificaciones, lo que es beneficioso si necesitas agregar nuevos tipos o efectos. 
//La capacidad de modificar las efectividades es flexible, pero puede llegar a necesitar ajustes si se expanden 
//las funcionalidades del sistema.
//LSP: Aunque la clase Tipo no tiene clases derivadas en tu diseño actual, si se decide extenderla en el futuro,
//por ejemplo, para tipos especiales o subtipos, los principios de la lógica de efectividad seguiran siendo consistentes.

    public class Tipo
    {
        private string name;
        
        private Dictionary<Tipo, double> efectividades = new Dictionary<Tipo, double>();
        public Tipo(string name)
        {
            this.name = name;
        }

        // Método para agregar la efectividad de un tipo respecto a otro
        public void CrearEfectividad(Tipo tipo, double efectividad)
        {
            if (!efectividades.ContainsKey(tipo))
            {
                efectividades.Add(tipo, efectividad);
            }
            else
            {
                efectividades[tipo] = efectividad;  // Actualiza si ya existe
            }
        }

        // Devuelve la efectividad de este tipo contra otro tipo
        public double DarEfectividad(Tipo tipo)
        {
            if (efectividades.ContainsKey(tipo))
            {
                return efectividades[tipo];
            }
            else
            {
                return 1.0;  // Si no está definido, lo consideramos como neutro
            }
        }
    }
}