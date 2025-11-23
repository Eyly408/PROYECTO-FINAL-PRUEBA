using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BbliotecaMonitoreo
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


    }
}
