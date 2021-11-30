using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.Estructurales
{
    public class Decorator
    {
        public void Main()
        {
            Cliente client = new Cliente();

            var simple = new ConcreteComponent();
            Console.WriteLine("Cliente: Obtengo un componente simple:");
            client.ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Cliente: Obtengo un componente decorado:");
            client.ClientCode(decorator2);
        }
    }

    public abstract class Componente
    {
        public abstract string Operation();
    }

    class ConcreteComponent : Componente
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    abstract class Decorador : Componente
    {
        protected Componente _component;

        public Decorador(Componente component)
        {
            this._component = component;
        }

        public void SetComponent(Componente component)
        {
            this._component = component;
        }
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }
  
    class ConcreteDecoratorA : Decorador
    {
        public ConcreteDecoratorA(Componente comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }
  
    class ConcreteDecoratorB : Decorador
    {
        public ConcreteDecoratorB(Componente comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }

    public class Cliente
    {        
        public void ClientCode(Componente component)
        {
            Console.WriteLine("Resultado: " + component.Operation());
        }
    }


}
