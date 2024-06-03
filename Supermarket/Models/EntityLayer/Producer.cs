using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.EntityLayer
{
    public class Producer:BasePropertyChanged
    {

        private int? producerID;
        public int? ProducerID
        {
            get { return producerID; }
            set
            {
                producerID = value;
                NotifyPropertyChanged("ProducerID");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string originCountry;
        public string OriginCountry
        {
            get { return originCountry; }
            set
            {
                originCountry = value;
                NotifyPropertyChanged("OriginCountry");
            }
        }

    }
}
