using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CustomerManager : ICustomerManager
    {
        public void AddCustomer(int customerNumber)
        {
            using var context = new LibraryContext();
            var customer = new Customer();
            customer.CustomerNumber = customerNumber;
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        public Customer GetCustomerByCustomerNumber(int customerNumber)
        {
            using var context = new LibraryContext();
            return (from c in context.Customers
                    where c.CustomerNumber == customerNumber
                    select c)
                    .FirstOrDefault();
        }
        public void RemoveCustomer(int customerID)
        {
            using var context = new LibraryContext();
            var customer = (from c in context.Customers
                         where c.CustomerID == customerID
                         select c).FirstOrDefault();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
