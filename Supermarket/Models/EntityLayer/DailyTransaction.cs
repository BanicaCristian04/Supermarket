using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class DailyTransaction:BasePropertyChanged
    {
        private DateTime issueDate;
        public DateTime IssueDate
        {
            get { return issueDate; }
            set
            {
                issueDate = value;
                NotifyPropertyChanged("IssueDate");
            }
        }
        private decimal totalAmount;
        public decimal TotalAmount
        {
            get { return totalAmount; }

            set
            {
                totalAmount = value;
                NotifyPropertyChanged("TotalAmount");
            }
        }
    }
}
