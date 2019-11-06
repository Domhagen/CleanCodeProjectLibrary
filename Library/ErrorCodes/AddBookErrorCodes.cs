using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public enum AddBookErrorCodes
    {
        ThereIsNoISBNumber,
        ISBNNumberNotValid,
        BookNotGivenAnAuthor,
        BookNotGivenATitle,
        NoSuchBook,
        Ok
    }
}
