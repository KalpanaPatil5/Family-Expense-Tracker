using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class FamilyExpense
    {
        public int ExpenseId { get; set; }
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
