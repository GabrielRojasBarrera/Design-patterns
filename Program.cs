using Design_patterns.Comportamiento;
using Design_patterns.Creacionales;
using Design_patterns.Estructurales;
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
                Console.WriteLine("[4] Prototype");
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

                    //PATRONES CREACIONALES
                    case 1:
                        Console.WriteLine("ABSTRACT FACTORY");
                        new Client1().Main();

                        break;
                    case 2:
                        Console.WriteLine("FACTORY METHOD");
                        new Client2().Main();
                        break;

                    case 3:
                        // The client code.

                        Console.WriteLine("SINGLETON");
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

                    case 4:
                        Console.WriteLine("PROTOTYPE");
                        var prototype = new Prototype();
                        prototype.Main();
                        break;

                    case 5:
                        Console.WriteLine("BUILDER");

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

                    //PATRONES ESTRUCTURALES
                    case 6:
                        Console.WriteLine("ADAPTER");
                        Adaptee adaptee = new Adaptee();
                        ITarget target = new Adapter(adaptee);

                        Console.WriteLine("Adaptee interface is incompatible with the client.");
                        Console.WriteLine("But with adapter client can call it's method.");

                        Console.WriteLine(target.GetRequest());
                        break;

                    case 7:
                        Console.WriteLine("BRIDGE");
                        Bridge bridge = new Bridge();
                        bridge.Main();
                        break;

                    case 8:
                        Console.WriteLine("COMPOSITE");
                        Client3 client3 = new Client3();

                        // This way the client code can support the simple leaf
                        // components...
                        Leaf leaf = new Leaf();
                        Console.WriteLine("Client: I get a simple component:");
                        client3.ClientCode(leaf);

                        // ...as well as the complex composites.
                        Composite tree = new Composite();
                        Composite branch1 = new Composite();
                        branch1.Add(new Leaf());
                        branch1.Add(new Leaf());
                        Composite branch2 = new Composite();
                        branch2.Add(new Leaf());
                        tree.Add(branch1);
                        tree.Add(branch2);
                        Console.WriteLine("Client: Now I've got a composite tree:");
                        client3.ClientCode(tree);

                        Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
                        client3.ClientCode2(tree, leaf);
                        break;

                    case 9:
                        Console.WriteLine("DECORATOR");
                        Decorator decorator = new Decorator();
                        decorator.Main();
                        break;

                    case 10:
                        Console.WriteLine("FACADE");
                        Facade facade = new Facade();
                        facade.Main();
                        break;

                    case 11:
                        Console.WriteLine("FLYWEIGHT");
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
                        Console.WriteLine("PROXY");

                        RefactoringGuru.DesignPatterns.Proxy.Conceptual.Client client = new RefactoringGuru.DesignPatterns.Proxy.Conceptual.Client();

                        Console.WriteLine("Client: Executing the client code with a real subject:");
                        RealSubject realSubject = new RealSubject();
                        client.ClientCode(realSubject);

                        Console.WriteLine();

                        Console.WriteLine("Client: Executing the same client code with a proxy:");
                        Proxy proxy = new Proxy(realSubject);
                        client.ClientCode(proxy);
                        break;

                    case 13:
                        Console.WriteLine("CHAIN OF RESPONSIBILITY");
                        ChainOfResponsibility chainOfResponsibility = new ChainOfResponsibility();
                        chainOfResponsibility.Main();
                        break;

                    case 14:
                        Console.WriteLine("COMMAND");
                        Command command = new Command();
                        command.Main();
                        break;

                    case 15:
                        Console.WriteLine("INTERPRETER");
                        string expresionEvaluar = "MCMXCIX";

                        Contexto contexto = new Contexto(expresionEvaluar);

                        List<Expresion> Arbol = new List<Expresion>();
                        Arbol.Add(new ExpresionMiles());
                        Arbol.Add(new ExpresionCientos());
                        Arbol.Add(new ExpresionDecenas());
                        Arbol.Add(new ExpresionUnidad());

                        //Interpretamos siguiendo las reglas gramaticales que están en el árbol
                        foreach (Expresion exp in Arbol)
                        {
                            exp.Interpretar(contexto);
                        }

                        Console.WriteLine("El número romano {0} es {1} en decimal", expresionEvaluar, contexto.Valor);
                        break;

                    case 16:
                        Console.WriteLine("ITERATOR");

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
                        Console.WriteLine("MEDIATOR");
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
                    case 18:
                        Console.WriteLine("MEMENTO");
                        new Program5().Main();
                        break;

                    case 19:
                        Console.WriteLine("OBSERVER");
                        Observer observer = new Observer();
                        observer.Main();
                        break;

                    case 20:
                        Console.WriteLine("STATE");
                        new Programa().Main();
                        break;

                    case 21:
                        Console.WriteLine("STRATEGY");
                        
                        // The client code picks a concrete strategy and passes it to the
                        // context. The client should be aware of the differences between
                        // strategies in order to make the right choice.
                        var context = new RefactoringGuru.DesignPatterns.Strategy.Conceptual.Context();

                        Console.WriteLine("Client: Strategy is set to normal sorting.");
                        context.SetStrategy(new ConcreteStrategyA());
                        context.DoSomeBusinessLogic();

                        Console.WriteLine();

                        Console.WriteLine("Client: Strategy is set to reverse sorting.");
                        context.SetStrategy(new ConcreteStrategyB());
                        context.DoSomeBusinessLogic();
                        
                        break;
                    case 22:
                        Console.WriteLine("TEMPLATE METHOD");
                        new Program2().Main();
                        break;
                    case 23:
                        Console.WriteLine("VISITOR");
                        new Program4().Main();
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