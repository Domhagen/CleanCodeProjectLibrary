using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class Debt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DebtID { get; set; }
        public int DebtNumber { get; set; }
        public int DebtAmount { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
