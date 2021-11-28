using Design_patterns.Creacionales;
using RefactoringGuru.DesignPatterns.Flyweight.Conceptual;
using RefactoringGuru.DesignPatterns.Iterator.Conceptual;
using RefactoringGuru.DesignPatterns.Mediator.Conceptual;
using RefactoringGuru.DesignPatterns.Proxy.Conceptual;
using RefactoringGuru.DesignPatterns.Strategy.Conceptual;

namespace Design_patterns // Note: actual namespace depends on the project name.
{
    public class Program
    {
        // Flyweight
        public static void addCarToPoliceDatabase(FlyweightFactory factory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);
        }


        public static void Main(string[] args)
        {
            int opcion;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione el patrón que desea ejecutar:\r\n");
                Console.WriteLine("Patrones de Creación:");
                Console.WriteLine("------------------------");
                Console.WriteLine("[1] Abstract factory");
                Console.WriteLine("[2] Factory method");
                Console.WriteLine("[3] Singleton");
                Console.WriteLine("[5] Builder\n");
                Console.WriteLine("Patrones de Estructura:");
                Console.WriteLine("------------------------");
                Console.WriteLine("[6] Adapter");
                Console.WriteLine("[7] Bridge");
                Console.WriteLine("[8] Composite");
                Console.WriteLine("[9] Decorator");
                Console.WriteLine("[10] Façade");               
                Console.WriteLine("[11] Flyweight");
                Console.WriteLine("[12] Proxy\n");
                Console.WriteLine("Patrones de Comportamiento:");
                Console.WriteLine("------------------------");
                Console.WriteLine("[13] Chain of responsibility");
                Console.WriteLine("[14] Command");
                Console.WriteLine("[15] Interpreter");
                Console.WriteLine("[16] Iterator");
                Console.WriteLine("[17] Mediator");
                Console.WriteLine("[18] Memento");
                Console.WriteLine("[19] Observer");
                Console.WriteLine("[20] State");
                Console.WriteLine("[21] Strategy");
                Console.WriteLine("[22] Template method");
                Console.WriteLine("[23] Visitor");
                Console.Write("Press '0' to exit\n");

                opcion = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(opcion);

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Saliendo");
                        break;
                    case 1:

                        new Client1().Main();

                        break;
                    case 2:

                        new Client2().Main();
                        break;

                    case 3:
                        // The client code.

                        Console.WriteLine("Singleton");
                        Singleton s1 = Singleton.GetInstance();
                        Singleton s2 = Singleton.GetInstance();

                        if (s1 == s2)
                        {
                            Console.WriteLine("Singleton works, both variables contain the same instance.");
                        }
                        else
                        {
                            Console.WriteLine("Singleton failed, variables contain different instances.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Builder");

                        // The client code creates a builder object, passes it to the
                        // director and then initiates the construction process. The end
                        // result is retrieved from the builder object.
                        var director = new Director();
                        var builder = new ConcreteBuilder();
                        director.Builder = builder;

                        Console.WriteLine("Standard basic product:");
                        director.BuildMinimalViableProduct();
                        Console.WriteLine(builder.GetProduct().ListParts());

                        Console.WriteLine("Standard full featured product:");
                        director.BuildFullFeaturedProduct();
                        Console.WriteLine(builder.GetProduct().ListParts());

                        // Remember, the Builder pattern can be used without a Director
                        // class.
                        Console.WriteLine("Custom product:");
                        builder.BuildPartA();
                        builder.BuildPartC();
                        Console.Write(builder.GetProduct().ListParts());
                        break;

                    case 11:
                        Console.WriteLine("Flyweight");
                        // The client code usually creates a bunch of pre-populated
                        // flyweights in the initialization stage of the application.
                        var factory = new FlyweightFactory(
                            new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                            new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                            new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                            new Car { Company = "BMW", Model = "M5", Color = "red" },
                            new Car { Company = "BMW", Model = "X6", Color = "white" }
                        );
                        factory.listFlyweights();

                        addCarToPoliceDatabase(factory, new Car
                        {
                            Number = "CL234IR",
                            Owner = "James Doe",
                            Company = "BMW",
                            Model = "M5",
                            Color = "red"
                        });

                        addCarToPoliceDatabase(factory, new Car
                        {
                            Number = "CL234IR",
                            Owner = "James Doe",
                            Company = "BMW",
                            Model = "X1",
                            Color = "red"
                        });

                        factory.listFlyweights();

                        break;

                    case 12:
                        Console.WriteLine("Proxy");

                        Client client = new Client();

                        Console.WriteLine("Client: Executing the client code with a real subject:");
                        RealSubject realSubject = new RealSubject();
                        client.ClientCode(realSubject);

                        Console.WriteLine();

                        Console.WriteLine("Client: Executing the same client code with a proxy:");
                        Proxy proxy = new Proxy(realSubject);
                        client.ClientCode(proxy);
                        break;

                    case 16:
                        Console.WriteLine("Iterator");

                        // The client code may or may not know about the Concrete Iterator
                        // or Collection classes, depending on the level of indirection you
                        // want to keep in your program.
                        var collection = new WordsCollection();
                        collection.AddItem("First");
                        collection.AddItem("Second");
                        collection.AddItem("Third");

                        Console.WriteLine("Straight traversal:");

                        foreach (var element in collection)
                        {
                            Console.WriteLine(element);
                        }

                        Console.WriteLine("\nReverse traversal:");

                        collection.ReverseDirection();

                        foreach (var element in collection)
                        {
                            Console.WriteLine(element);
                        }

                        break;

                    case 17:
                        Console.WriteLine("Mediator");
                        // The client code.
                        Component1 component1 = new Component1();
                        Component2 component2 = new Component2();
                        new ConcreteMediator(component1, component2);

                        Console.WriteLine("Client triggets operation A.");
                        component1.DoA();

                        Console.WriteLine();

                        Console.WriteLine("Client triggers operation D.");
                        component2.DoD();

                        break;

                    case 21:
                        Console.WriteLine("Strategy");
                        
                        // The client code picks a concrete strategy and passes it to the
                        // context. The client should be aware of the differences between
                        // strategies in order to make the right choice.
                        var context = new Context();

                        Console.WriteLine("Client: Strategy is set to normal sorting.");
                        context.SetStrategy(new ConcreteStrategyA());
                        context.DoSomeBusinessLogic();

                        Console.WriteLine();

                        Console.WriteLine("Client: Strategy is set to reverse sorting.");
                        context.SetStrategy(new ConcreteStrategyB());
                        context.DoSomeBusinessLogic();
                        
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
                Console.ReadLine();
            } while (opcion != 0);
        }
    }
}