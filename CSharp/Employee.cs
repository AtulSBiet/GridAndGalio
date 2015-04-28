using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    interface IEmployee
    {
    }
    interface IEmployeeTwo
    {

    }
    public abstract class Employee
    {
        protected Employee()
        {
            System.Console.WriteLine("In Abstract Class");
        }
    }
    class A
    { 
        static A()
        { }
        internal A()
        { }
        internal virtual int Add(int first , int second)
        {
            return first + second;
        }

        internal A(int price)
        {
            
        }
    }
    class DerivedEmployee:A//,IEmployee,IEmployeeTwo
    {
        internal DerivedEmployee()
            : base(10)
        { }
        internal override int Add(int first, int second)
        {
            return first * second;
        }
        //IEmployee empObj = new DerivedEmployee();
    }
    public class B
    {
        //static void Main()
        //{
        //    DerivedEmployee oDer = new DerivedEmployee();
        //    DerivedEmployee oTest = new A() as DerivedEmployee;
        //    oTest.Add(2, 3);

        //    //oDer.Add(2, 3);
        //    //Console.WriteLine(objA.Add(2, 3));
        //    string first = "f";
        //    string second = "s";
        //    first = first + second;
        //    Console.WriteLine("{0}, {1}", first, second);
        //    // Keep the console window open in debug mode.
        //    Console.WriteLine("Press any key to exit");
        //    Console.ReadLine();
        //}
    }

    interface E
    {
        int FirstMethod();
        void SecondMethod(int price);
    }
    class ImplementInterface:E
    {

        public virtual int FirstMethod()
        {
            return 1;
        }

        public void SecondMethod(int price)
        {
            
        }
    }
    class ImplementBaseClassWchichImplementI:ImplementInterface
    {
        public override int FirstMethod()
        {
            return 1;
        }

        public void SecondMethod(int price)
        {

        }
    }
}

