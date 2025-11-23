using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAlertas
{

    public class SistemaAlertas
    {
        public void Evaluar(int temperatura, int humo)
        {
            if (temperatura > 70 && humo > 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALERTA CRÍTICA: RIESGO ALTO DE INCENDIO");
                AlarmaCritica();
            }
            else if (temperatura > 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ADVERTENCIA: Temperatura alta detectada.");
                AlarmaAdvertencia();
            }
            else if (humo > 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ADVERTENCIA: Nivel de humo elevado.");
                AlarmaAdvertencia();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Condiciones normales. Sistema estable.");
            }

            Console.ResetColor();
        }

        private void AlarmaCritica()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Beep(900, 300);
                Console.Beep(700, 300);
            }
        }

        private void AlarmaAdvertencia()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(500, 200);
            }
        }
    }


}

