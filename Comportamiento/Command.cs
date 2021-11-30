using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.Comportamiento
{
    public class Command
    {
        public void Main()
        {   
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Decir hola!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Enviar email", "Guardar reporte"));

            invoker.DoSomethingImportant();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this._payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: Puedo hacer cosas tan simples como imprimir ({this._payload})");
        }
    }

    class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }
        
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Las cosas complejas deben ser realizadas por un objeto receptor.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Trabajando en ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: También trabajando en ({b}.)");
        }
    }

    class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }
   
        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: ¿Alguien quiere que se haga algo antes de empezar?");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            Console.WriteLine("Invoker: ...haciendo algo muy importante...");

            Console.WriteLine("Invoker: ¿Alguien quiere que se haga algo antes de que termine?");
            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }
}
