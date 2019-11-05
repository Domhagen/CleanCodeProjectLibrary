using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface ICustomerManager
    {
        void AddCustomer(int customerNumber, string customerIDNumber);
        Customer GetCustomerByCustomerNumber(int customerNumber);
        List<Customer> GetAllCustomers();
        void RemoveCustomer(int customerID);
    }
}
