//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using DefaultNamespace;
using Library.Combate;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            double dañoPorAtaque = 65; // Daño de rayo
            double defensaCharmander = 60; // Defensa de Charmander
            double hpCharmander = 85; // Charmander arranca con 85 de vida
            double vidaCharmanderRestanteEsperada = hpCharmander - (dañoPorAtaque - defensaCharmander); // Calculos de supuesta vida charmander
            double vidaPidgeyEsperada = 60; // Pidgey debería iniciar con 60 de vida

            Menu menuPP = new Menu();
            menuPP.UnirJugadores("Ash");
            menuPP.UnirJugadores("Red");
            menuPP.AgregarPokemonesA("Pidgey"); 
            menuPP.AgregarPokemonesD("Pikachu");
            menuPP.AgregarPokemonesA("Charmander");
            menuPP.IniciarEnfrentamiento();
            menuPP.CambiarPokemon(1); // Cambia a Charmander
            menuPP.UsarMovimientos(2);//Pikachu usa rayo, danio de rayo: 65, defensa de Charmander: vida 85, defensa: 60
            Console.WriteLine(vidaCharmanderRestanteEsperada);
        }
    }
}