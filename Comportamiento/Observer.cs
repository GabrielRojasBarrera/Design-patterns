using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.Comportamiento
{
    public class Observer
    {
        public void Main()
        {        
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }
    }

    public interface IObserver
    {  
        void Update(ISubject subject);
    }

    public interface ISubject
    {   
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; } = -0;
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Observador agregado.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Observador removido.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notificando a los observaodres...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
      
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: Estoy haciendo algo importante.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: Mi estado ha cambiado a: " + this.State);
            this.Notify();
        }
    }

    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reaccionó al evento.");
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reaccionó al evento.");
            }
        }
    }
}
