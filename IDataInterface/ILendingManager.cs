using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface ILendingManager
    {
        void LendOutBook(int bookID, int customerID);
        Book GetBookBybookNumber(int bookNumber);
        List<TimeSlot> GetTimeSlotsFrom(DateTime start);
    }
}
