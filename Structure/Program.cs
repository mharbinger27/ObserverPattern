using System;

namespace Structure
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void Run()
        {
            // Configure Observer pattern
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user
             Console.ReadKey();
        }
    }
}
