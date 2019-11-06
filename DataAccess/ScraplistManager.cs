using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ScraplistManager : IScraplistManager
    {
        public List<Book> GetScraplist()
        {
            using var context = new LibraryContext();
            return (from b in context.Books
                    where b.Condition == 1
                    select b)
                    .ToList();
        }
    }
}
