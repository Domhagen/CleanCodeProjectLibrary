using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public enum RemoveCustomerErrorCodes
    {
        NoSuchCustomer,
        CustomerHasBooks,
        CustomerHasDebts,
        Ok
    }
}
