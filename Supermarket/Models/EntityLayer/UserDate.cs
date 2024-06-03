using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class UserDate
    {
        public User Cashier { get; set; }
        public DateTime? Date { get; set; }

    }
}
