using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface ICustomerManager
    {
        void AddCustomer(int customerNumber);
        Customer GetCustomerByCustomerNumber(int customerNumber);
    }
}
