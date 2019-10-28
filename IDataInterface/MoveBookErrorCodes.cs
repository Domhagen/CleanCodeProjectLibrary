using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public enum MoveBookErrorCodes
    {
        Ok,
        NoSuchBook,
        BookAlreadyAtThatShelf,
        NoSuchShelf
    }
}
