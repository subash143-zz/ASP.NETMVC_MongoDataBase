using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory_pattern
{
    public enum Calculations
    {
        Add,
        Subtract,
        Multiply
    }
    public class CalculateFactory
    {
        ICalculate calculate;
        public ICalculate GetCalculation(Calculations calculation)
        {
            switch (calculation)
            {
                case Calculations.Add:
                    calculate = new Add();
                    break;
                case Calculations.Subtract:
                    calculate = new Subtract();
                    break;
                case Calculations.Multiply:
                    calculate = new Product();
                    break;
                default:
                    break;
            }
            return calculate;
        }
    }

    public interface ICalculate
    {
        void Calculate(int a, int b);
    }

    public class Add : ICalculate
    {
        public void Calculate(int a, int b)
        {
            Console.WriteLine("Sum is: " + (a + b));
        }
    }

    public class Subtract : ICalculate
    {
        public void Calculate(int a, int b)
        {
            Console.WriteLine("Difference is: "+ (a - b));
        }
    }
    public class Product : ICalculate
    {
        public void Calculate(int a, int b)
        {
            Console.WriteLine("Product is: ", a * b);
        }
    }
}
