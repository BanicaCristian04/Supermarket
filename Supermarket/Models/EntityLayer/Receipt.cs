using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class Receipt:BasePropertyChanged
    {
        private int? receiptID;
        public int? ReceiptID
        {
            get { return receiptID; }
            set
            {
                receiptID= value;
                NotifyPropertyChanged("ReceiptID");
            }
        }
        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value;
                NotifyPropertyChanged("UserID");
            }
        }
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
            set { totalAmount = value;
                NotifyPropertyChanged("TotalAmount");
            }

        }
        

    }
}
