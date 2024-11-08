namespace Ucu.Poo.Pokemon;
//IMovimientoAtaque:
//Tiene las mismas responsabilidades que IMovimiento, agrega la responsabilidad de definir el ataque y la precision, 
//tiene alta cohesion.
//LSP: Puede ser sustituida por cualquier subclase que implemente esta interfaz. Tambien cumple con polimorfismo.
//Cumple con ISP: Debido a que esta separada de IMovimimentoEspecial e IMovimientoDefensa, cada una tiene sus metodos 
//correspondientes para cada tipo de movimiento, evitando que alguna tenga metodos irrelevantes.

public interface IMovimientoAtaque: IMovimiento
{
    int GetAtaque();
    int GetPrecision();
}