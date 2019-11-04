using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using System.Linq;

namespace Library
{
    public class LendingAPI
    {
        private ILendingManager lendingManager;
        private IBookManager bookManager;
        private ICustomerManager customerManager;

        public LendingAPI(ILendingManager lendingManager, IBookManager bookManager, ICustomerManager customerManager)
        {
            this.lendingManager = lendingManager;
            this.bookManager = bookManager;
            this.customerManager = customerManager;
        }
        public LendOutBookErrorCodes LendOutBook(int bookNumber, int customerNumber)
        {
            var book = bookManager.GetBookByBookNumber(bookNumber);
            var customer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (book == null)
                return LendOutBookErrorCodes.BookNotAvaible;

            if (customer.Book.Count < 6)
                return LendOutBookErrorCodes.CustomerHasFiveBooks;

            if (customer.Debt.Count > 0)
                return LendOutBookErrorCodes.CustomerHasDebt;

            return LendOutBookErrorCodes.Ok;
        }
        public DateTime ExtendLendingForCustomer(DateTime start, int customerNumber, List<Debt> debts)
        {
            var timeSlots = lendingManager.GetTimeSlotsFrom(start);
            var customer1 = customerManager.GetCustomerByCustomerNumber(customerNumber);

            return CheckForDebt(customerNumber, timeSlots, debts);
        }

        private static DateTime CheckForDebt(int customerNumber, List<TimeSlot> timeSlots, List<Debt> debts)
        {
            for (int i = 0; i < timeSlots.Count; i++)
            {
                var lendingDoable = FindDebts(customerNumber, timeSlots[i], debts);
                if (lendingDoable.Count() == 0)
                    return timeSlots[i].Start;
            }
            return DateTime.MaxValue;
        }
        private static IEnumerable<Debt> FindDebts(int customerNumber, TimeSlot timeSlot, List<Debt> debts)
        {
            return debts.Where(d => d.Customer.CustomerNumber == customerNumber);
        }
    }
}
