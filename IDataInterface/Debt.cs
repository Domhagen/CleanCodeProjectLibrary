using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public class Debt
    {
        public int DebtID { get; set; }
        public int DebtNumber { get; set; }
        public int DebtAmount { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
