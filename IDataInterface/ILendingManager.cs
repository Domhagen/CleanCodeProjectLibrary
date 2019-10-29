using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface ILendingManager
    {
        Book LendOutBookByBookTitle(string bookTitle);
    }
}
