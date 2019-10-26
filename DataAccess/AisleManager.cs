using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AisleManager : IAisleManager
    {
        public void AddAisle(int aisleNumber)
        {
            using var context = new LibraryContext();
            var aisle = new Aisle();
            aisle.AisleNumber = aisleNumber;
            context.Ailes.Add(aisle);
            context.SaveChanges();
        }
        public Aisle GetAisleByAisleNumber(int aisleNumber)
        {
            using var context = new LibraryContext();
            return (from a in context.Ailes
                    where a.AisleNumber == aisleNumber
                    select a)
                    .Include(s => s.Shelf)
                    .FirstOrDefault();
        }

        public void RemoveAisle(int aisleID)
        {
            using var context = new LibraryContext();
            var aisle = (from a in context.Ailes
                         where a.AisleID == aisleID
                         select a).FirstOrDefault();
            context.Ailes.Remove(aisle);
            context.SaveChanges();
        }
    }
}
