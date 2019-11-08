using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DebtManager : IDebtManager
    {
        public void AddDebt(int debtNumber)
        {
            using var context = new LibraryContext();
            var debt = new Debt();
            debt.DebtNumber = debtNumber;
            context.Debts.Add(debt);
            context.SaveChanges();
        }
    }
}
