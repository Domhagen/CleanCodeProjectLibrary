using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public class Book
    {
        public int BookID { get; set; }
        public int BookNumber { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PurchaseYear { get; set; }
        public int PurchaseCost { get; set; }
        public int Condition { get; set; }
        public string ISBN { get; set; }
        public int ShelfID { get; set; }
        public Shelf Shelf { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Return> Return { get; set; }
    }
}
