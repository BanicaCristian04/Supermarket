using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class CategoryTotalAmount:BasePropertyChanged
    {
        private Category category;
        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
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
        public CategoryTotalAmount(Category category, decimal  totalAmount)
        {
            this.category = category;
                this.totalAmount = totalAmount;
        }
    }
}
