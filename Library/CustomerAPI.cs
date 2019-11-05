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
        public bool AddCustomer(int customerNumber, string customerIDNumber)
        {
            var avaibleCustomer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (avaibleCustomer != null)
                return false;
            customerManager.AddCustomer(customerNumber, customerIDNumber);
            return true;
        }
        public RemoveCustomerErrorCodes RemoveCustomer(int customerNumber)
        {
            var newCustomer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (newCustomer == null)
                return RemoveCustomerErrorCodes.NoSuchCustomer;

            if (newCustomer.Book.Count > 0)
                return RemoveCustomerErrorCodes.CustomerHasBooks;

            customerManager.RemoveCustomer(newCustomer.CustomerID);

            return RemoveCustomerErrorCodes.Ok;
        }
    }
}
