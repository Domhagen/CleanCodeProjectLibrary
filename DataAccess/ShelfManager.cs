using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ShelfManager : IShelfManager
    {
        public void AddShelf(int shelfNumber)
        {
            using var context = new LibraryContext();
            var shelf = new Shelf();
            shelf.ShelfNumber = shelfNumber;
            context.Shelves.Add(shelf);
            context.SaveChanges();
        }
        public Shelf GetShelfByShelfNumber(int shelfNumber)
        {
            using var context = new LibraryContext();
            return (from s in context.Shelves
                    where s.ShelfNumber == shelfNumber
                    select s)
                    .Include(s => s.Aisle)
                    .FirstOrDefault();
        }
        public void MoveShelf(int shelfID, int aisleID)
        {
            using var context = new LibraryContext();
            var shelf = (from s in context.Shelves
                         where s.ShelfID == shelfID
                         select s)
                         .First();
            shelf.AisleID = aisleID;
            context.SaveChanges();
        }
        public void RemoveShelf(int shelfID)
        {
            using var context = new LibraryContext();
            var shelf = (from s in context.Shelves
                         where s.ShelfID == shelfID
                         select s).FirstOrDefault();
            context.Shelves.Remove(shelf);
            context.SaveChanges();
        }
    }
}
