using System;
using System.Collections.Generic;
using System.Text;

namespace Library
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
