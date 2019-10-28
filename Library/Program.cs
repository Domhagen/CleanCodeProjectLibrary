using DataAccess;
using IDataInterface;
using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerManager customerManager = new CustomerManager();



            Console.WriteLine("Hello World!");
        }
    }
}
