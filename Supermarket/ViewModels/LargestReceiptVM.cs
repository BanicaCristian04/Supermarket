using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class LargestReceiptVM:BasePropertyChanged
    {
        ReceiptBLL receiptBLL = new ReceiptBLL();
        private DateTime? selectedDate;

        private Receipt largestReceipt;
        public DateTime? SelectedDate
        {
            get => selectedDate;
            set
            {
                selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
                GetLargestReceiptCommand.Execute(selectedDate); 
            }
        }
        public Receipt LargestReceipt
        {
            get => largestReceipt;
            set
            {
                largestReceipt = value;
                NotifyPropertyChanged("LargestReceipt");
            }
        }
        private ObservableCollection<ProductReceipt> products;
        public ObservableCollection<ProductReceipt> Products
        {
            get => products;
            set
            {
                products = value;
                NotifyPropertyChanged("Products");
            }
        }


        private ICommand getLargestReceiptCommand;
        public ICommand GetLargestReceiptCommand
        {
            get
            {
                if (getLargestReceiptCommand == null)
                    getLargestReceiptCommand = new RelayCommand<DateTime?>(GetLargestReceipt, GetLargestReceiptCanExecute);
                return getLargestReceiptCommand;
            }
        }

        private bool GetLargestReceiptCanExecute(DateTime? date)
        {
            return date.HasValue;

        }

        private void GetLargestReceipt(DateTime? date)
        {
            LargestReceipt = receiptBLL.GetLargestReceipt(date);
            if (LargestReceipt != null)
            {
                Products = new ObservableCollection<ProductReceipt>(receiptBLL.GetProductsByReceiptID(LargestReceipt.ReceiptID));
            }
            
        }

        public LargestReceiptVM() { 

        }
    }
}
