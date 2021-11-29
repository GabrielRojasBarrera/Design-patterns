using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.Comportamiento
{
    internal class Interpreter
    {
    }

    class Contexto
    {
        private string expresion;
        private int valor;

        public string Expresion { get => expresion; set => expresion = value; }
        public int Valor { get => valor; set => valor = value; }

        public Contexto(string pExpresion)
        {
            expresion = pExpresion;

            Console.WriteLine("Se evaluará {0} ", expresion);
        }
    }

    abstract class Expresion
    {
        public void Interpretar(Contexto pContexto)
        {

            // Si no hay elementos que interpretar salimos
            if (pContexto.Expresion.Length == 0)
                return;

            // Verificamos si empieza con 9
            if (pContexto.Expresion.StartsWith(Nueve()))
            {
                // Agregamos el nuevo por la posición desde 1,10,100
                pContexto.Valor += (9 * Factor());

                // Eliminamos dos caracteres IX,XC,CM
                pContexto.Expresion = pContexto.Expresion.Substring(2);
            }

            // Verificamos si empieza con 5
            else if (pContexto.Expresion.StartsWith(Cuatro()))
            {
                pContexto.Valor += (4 * Factor());
                pContexto.Expresion = pContexto.Expresion.Substring(2);
            }

            // Verificamos si empieza con 4
            else if (pContexto.Expresion.StartsWith(Cinco()))
            {
                pContexto.Valor += (5 * Factor());
                pContexto.Expresion = pContexto.Expresion.Substring(1);
            }

            // Recorremos las unidades encontradas I,X,C
            while (pContexto.Expresion.StartsWith(Unidad()))
            {
                pContexto.Valor += (1 * Factor());
                pContexto.Expresion = pContexto.Expresion.Substring(1);
            }
        }

        // Métodos abstractos para encontrar el caracter y factor según la posición
        public abstract string Unidad();
        public abstract string Cuatro();
        public abstract string Cinco();
        public abstract string Nueve();
        public abstract int Factor();
    }

    class ExpresionUnidad : Expresion
    {
        public override string Unidad()
        {
            // Regresamos el caracter para que sea utilizado por el intérprete para
            // reconocer y evaluar el valor
            return "I";
        }

        public override string Cuatro()
        {
            return "IV";
        }

        public override string Cinco()
        {
            return "V";
        }

        public override string Nueve()
        {
            return "IX";
        }

        public override int Factor()
        {
            // El valor encontrado sera multiplicado por 1 en el intérprete
            return 1;
        }
    }

    class ExpresionDecenas : Expresion
    {
        public override string Unidad()
        {
            // Regresamos el caracter para que sea utilizado por el intérprete para
            // reconocer y evaluar el valor
            return "X";
        }

        public override string Cuatro()
        {
            return "XL";
        }

        public override string Cinco()
        {
            return "L";
        }

        public override string Nueve()
        {
            return "XC";
        }

        public override int Factor()
        {
            // El valor encontrado sera multiplicado por 1 en el intérprete
            return 10;
        }
    }

    class ExpresionCientos : Expresion
    {
        public override string Unidad()
        {
            // Regresamos el caracter para que sea utilizado por el intérprete para
            // reconocer y evaluar el valor
            return "C";
        }

        public override string Cuatro()
        {
            return "CD";
        }

        public override string Cinco()
        {
            return "D";
        }

        public override string Nueve()
        {
            return "CM";
        }

        public override int Factor()
        {
            // El valor encontrado sera multiplicado por 1 en el intérprete
            return 100;
        }
    }

    class ExpresionMiles : Expresion
    {
        public override string Unidad()
        {
            // Regresamos el caracter para que sea utilizado por el intérprete para
            // reconocer y evaluar el valor
            return "M";
        }

        public override string Cuatro()
        {
            return " ";
        }

        public override string Cinco()
        {
            return " ";
        }

        public override string Nueve()
        {
            return " ";
        }

        public override int Factor()
        {
            // El valor encontrado sera multiplicado por 1 en el intérprete
            return 1000;
        }
    }


}
