using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public class Book
    {
        public int BookID { get; set; }
        public int BookNumber { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int PurchaseYear { get; set; }
        public int PurchaseCost { get; set; }
        public int BookCondition { get; set; }
        public int ISBNNumber { get; set; }
        public int ShelfID { get; set; }
        public Shelf shelf { get; set; }
    }
}
