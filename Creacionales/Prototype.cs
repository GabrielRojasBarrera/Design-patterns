using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.Creacionales
{
    public class Prototype
    {
        public void Main()
        {
            Persona p1 = new Persona();
            p1.Nombre = "Jack";
            p1.Edad = 42;
            p1.FechaNacimiento = Convert.ToDateTime("1977-01-01");
            p1.IdInfo = new IDInfo(444);

            Persona p2 = p1.DeepCopy();

            Console.WriteLine("Valores del objeto original y el clonado");
            Console.WriteLine("  Objeto persona original");
            DisplayValues(p1);
            Console.WriteLine("  Objeto persona clonado");
            DisplayValues(p2);

            p1.Nombre = "Frank";
            p1.IdInfo.IdNumber = 555;

            Console.WriteLine("\nValores en los objetos despues de actualizar en el original");
            Console.WriteLine("  Objeto persona original");
            DisplayValues(p1);
            Console.WriteLine("  Objeto persona clonado");
            DisplayValues(p2);
        }

        public void DisplayValues(Persona p)
        {
            Console.WriteLine($"   Nombre:{p.Nombre}, Edad: {p.Edad}, Fecha de Nacimiento: {p.FechaNacimiento} ");
            Console.WriteLine($"   ID: {p.IdInfo.IdNumber}");
        }
        
    }

    public class Persona
    {
        public int Edad;
        public DateTime FechaNacimiento;
        public string? Nombre;
        public IDInfo? IdInfo;

        public Persona DeepCopy()
        {
            Persona clone = (Persona)this.MemberwiseClone();
            clone.IdInfo = new IDInfo(IdInfo.IdNumber);
            return clone;
        }
    }

    public class IDInfo
    {
        public int IdNumber;
        
        public IDInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
}
