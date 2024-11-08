using Library.Tipos;

namespace Ucu.Poo.Pokemon;

public interface IMovimientoEspecial:IMovimientoAtaque
{
    bool GetUsadoAnteriormente();
    void UsadoAnteriormente(bool valor);
    Efecto GetEfecto();
}