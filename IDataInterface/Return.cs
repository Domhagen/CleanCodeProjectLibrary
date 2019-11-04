using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class Return
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
