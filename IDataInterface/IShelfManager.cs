using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IShelfManager
    {
        void AddShelf(int shelfNumber);
        Shelf GetShelfByShelfNumber(int shelfNumber);
        void MoveShelf(int shelfID, int aisleID);
    }
}
