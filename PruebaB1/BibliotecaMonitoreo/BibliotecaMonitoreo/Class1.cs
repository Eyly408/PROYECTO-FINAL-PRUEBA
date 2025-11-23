using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotecaMonitoreo
{

    public class SistemaMonitoreo
    {
        private Random rnd = new Random();

        public int ObtenerTemperatura()
        {
            return rnd.Next(15, 81);
        }

        public double ObtenerHumo(int temperatura)
        {
            double num = (double)temperatura * 1.2 + (double)rnd.Next(-10, 11);
            if (num < 0.0)
            {
                num = 0.0;
            }

            if (num > 100.0)
            {
                num = 100.0;
            }

            return Math.Round(num, 1);
        }

        public string Diagnosticar(int temperatura, double humo)
        {
            if (temperatura < 40 && humo < 30.0)
            {
                return "Condiciones normales.";
            }

            if ((temperatura >= 40 && temperatura < 60) || (humo >= 30.0 && humo < 60.0))
            {
                return "Advertencia: temperatura o humo elevados.";
            }

            return "PELIGRO: Riesgo de incendio detectado.";
        }


        public void MostrarDatos(string zona)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MONITOREANDO " + zona + "...");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------");
            int num = ObtenerTemperatura();
            double num2 = ObtenerHumo(num);
            string text = Diagnosticar(num, num2);
            Console.Write("Temperatura: ");
            if (num >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (num >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine(num + " °C");
            Console.ResetColor();
            Console.Write("Nivel de humo: ");
            if (num2 >= 60.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (num2 >= 30.0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine(num2 + "%");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------");
            if (text.Contains("PELIGRO"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                Console.ResetColor();
                AlertaSonoraCritica();
            }
            else if (text.Contains("Advertencia"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text);
                Console.ResetColor();
                AlertaSonoraAdvertencia();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
        }

        public void AlertaSonoraAdvertencia()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Beep(700, 250);
                Thread.Sleep(120);
            }
        }

        public void AlertaSonoraCritica()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(1000, 300);
                Thread.Sleep(150);
                Console.Beep(800, 300);
                Thread.Sleep(150);
            }
        }
    }


}

