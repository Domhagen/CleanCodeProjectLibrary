using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class CustomerAPI
    {
        private ICustomerManager customerManager;

        public CustomerAPI(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }
        public bool AddCustomer(int customerNumber)
        {
            var avaibleCustomer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (avaibleCustomer != null)
                return false;
            customerManager.AddCustomer(customerNumber);
            return true;
        }
    }
}
