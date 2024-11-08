using System.Collections.Generic;

namespace Library.Tipos
{
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