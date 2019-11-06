using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IScraplistManager
    {
        List<Book> GetScraplist();
    }
}
