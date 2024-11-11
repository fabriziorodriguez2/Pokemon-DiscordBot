using Library.Combate;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class MovimientosEspecialesTest
{
 [Test]
 public void UsoDeEnvenenamiento()
 {
  Menu Menu1 = new Menu();
  Menu1.UnirJugadores("Ansu");
  Menu1.UnirJugadores("Cima");
  Menu1.AgregarPokemonesA("Arbok");
  Menu1.AgregarPokemonesD("Squirtle");
  Menu1.IniciarEnfrentamiento();
  Menu1.UsarMovimientos(1);
  double vidaesperadasquirtle = 60;
  double vidadada = Menu1.GetHpDefensor();
  Assert.That(vidaesperadasquirtle,Is.EqualTo(vidadada));
 }
    
}