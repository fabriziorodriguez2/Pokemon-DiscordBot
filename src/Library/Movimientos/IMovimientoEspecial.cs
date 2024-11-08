using Library.Tipos;

namespace Ucu.Poo.Pokemon;
//IMovimientoEspecial:
//Define las propiedades relacionadas con movimientos especiales, lo que mantiene la cohesión de la interfaz.
//LSP: Puede ser sustituida por cualquier subclase que implemente esta interfaz. Tambien cumple con polimorfismo.
//Cumple con ISP: Debido a que esta separada de IMovimimentoAtaque e IMovimientoDefensa, cada una tiene sus metodos 
//correspondientes para cada tipo de movimiento, evitando que alguna tenga metodos irrelevantes.


public interface IMovimientoEspecial:IMovimientoAtaque
{
    bool GetUsadoAnteriormente();
    void UsadoAnteriormente(bool valor);
    Efecto GetEfecto();
}