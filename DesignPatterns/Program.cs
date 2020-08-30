using DesignPatterns.Factory_pattern;
using DesignPatterns.Singleton_pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton Design Pattern
            Logger log1 = Logger.Instance;
            Logger log2 = Logger.Instance;

            Console.WriteLine(log1.GetHashCode());
            Console.WriteLine(log2.GetHashCode());

            //Ineritance and virtual class example
            Parent parent = new Parent();
            parent.MethodParent();

            //Accessing Parent as well as child method from child class
            Child child = new Child();
            child.MethodParent();
            child.MethodChild();
            (child as Parent).MethodParent();

            //Accessing Child method from Parent class
            Parent parent2 = new Child();
            parent2.MethodParent();
            ((Child)parent2).MethodParent();
            (parent2 as Child).MethodParent();

            //Factory Pattern
            Console.WriteLine("----------Factory Pattern-----------");
            CalculateFactory factory = new CalculateFactory();
            ICalculate calc = factory.GetCalculation(Calculations.Add);
            calc.Calculate(2, 3);
            calc = factory.GetCalculation(Calculations.Subtract);
            calc.Calculate(2, 3);
        }
    }
}
