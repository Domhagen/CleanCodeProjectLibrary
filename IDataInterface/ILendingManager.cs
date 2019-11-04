using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface ILendingManager
    {
        void LendOutBook(int bookID, int customerID);
        List<TimeSlot> GetTimeSlotsFrom(DateTime start);
    }
}
