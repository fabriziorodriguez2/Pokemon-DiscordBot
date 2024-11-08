using Library.Tipos;

namespace Ucu.Poo.Pokemon;
//Establece las firmas que necesita cumplir cada libro para funcionar correctamente
public interface IMovimiento
{ 
    string GetName();
    Tipo GetTipo();
    
}