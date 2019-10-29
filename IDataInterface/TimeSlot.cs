using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDataInterface
{
    public interface TimeSlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSlotID { get; set; }
        public int LendingID { get; set; }
        public DateTime Start { get; set; }
        public ICollection<Lending> Lending { get; set; }
    }
}
