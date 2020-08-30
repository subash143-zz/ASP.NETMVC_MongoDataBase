using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Parent
    {
        public virtual void MethodParent()
        {
            Console.WriteLine("Parent - Parent");
        }
    }

    public class Child: Parent
    {
        public void MethodParent()
        {
            Console.WriteLine("Child - Parent");
        }
        public void MethodChild()
        {
            Console.WriteLine("Child - Child");
        }
    }
}
