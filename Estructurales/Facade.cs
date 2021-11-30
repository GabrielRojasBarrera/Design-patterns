using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.Estructurales
{
    internal class Facade
    {
        public void Main()
        {      
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            FacadeClass facade = new FacadeClass(subsystem1, subsystem2);
            FacadeClient.ClientCode(facade);
        }
    }

    public class FacadeClass
    {
        protected Subsystem1 _subsystem1;

        protected Subsystem2 _subsystem2;

        public FacadeClass(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

        public string Operation()
        {
            string result = "Facade inicializa los subsistemas:\n";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += "Facade ordena a los subsistemas realizar la acción:\n";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            return result;
        }
    }

    public class Subsystem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string operationN()
        {
            return "Subsystem1: Go!\n";
        }
    }

    public class Subsystem2
    {
        public string operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string operationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }


    class FacadeClient
    {
        public static void ClientCode(FacadeClass facade)
        {
            Console.Write(facade.Operation());
        }
    }
}
