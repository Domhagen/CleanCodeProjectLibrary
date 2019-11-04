using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerIDNumber { get; set; }
        public string CustomerAdress { get; set; }
        public ICollection<Book> Book { get; set; }
        public ICollection<Debt> Debt { get; set; }
        public ICollection<Lending> Lending { get; set; }
    }
}
