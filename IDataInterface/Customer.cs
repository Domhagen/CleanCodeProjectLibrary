using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public int CustomerNumber { get; set; }
        public string IDNumber { get; set; }
        public string Adress { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Book> Book { get; set; }
        public ICollection<Debt> Debt { get; set; }
        public ICollection<Lending> Lending { get; set; }
        public ICollection<Return> Return { get; set; }
    }
}
