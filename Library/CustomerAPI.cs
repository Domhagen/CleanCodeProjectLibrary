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
        public AddCustomerErrorCodes AddCustomer(int customerNumber, string customerIDNumber)
        {

            if (string.IsNullOrEmpty(customerIDNumber))
                return AddCustomerErrorCodes.ThereIsNoIDNumber;
            if (ValidateISBN(customerIDNumber) == false)
                return AddCustomerErrorCodes.IDNumberNotValid;

            customerManager.AddCustomer(customerNumber, customerIDNumber);
            return AddCustomerErrorCodes.Ok;
        }
        private static bool ValidateISBN(string customerIDNumber)
        {
            int sum = 0;
            for (int i = 0; i < customerIDNumber.Length; i++)
            {
                int n = (customerIDNumber[i] - '0')
                    << (1 - (i & 1));
                if (n > 9) n -= 9;
                sum += n;
            }
            {
                return (sum % 10) == 0;
            }
        }
        public RemoveCustomerErrorCodes RemoveCustomer(int customerNumber)
        {
            var customer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (customer == null)
                return RemoveCustomerErrorCodes.NoSuchCustomer;
            if (customer.Book.Count > 0)
                return RemoveCustomerErrorCodes.CustomerHasBooks;
            if (customer.Debt.Count > 0)
                return RemoveCustomerErrorCodes.CustomerHasDebts;

            customerManager.RemoveCustomer(customer.CustomerID);

            return RemoveCustomerErrorCodes.Ok;
        }
    }
}
