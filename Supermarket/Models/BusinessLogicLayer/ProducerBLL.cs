using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProducerBLL
    {
        public ObservableCollection<Producer> ProducerList { get; set; }

        private ProducerDAL producerDAL;

        public ProducerBLL()
        {
            producerDAL = new ProducerDAL();
        }
        public ObservableCollection<Producer> GetAllProducers()
        {
            return producerDAL.GetAllProducers();
        }
        public void AddProducer(Producer producer)
        {
            producerDAL.AddProducer(producer);
            ProducerList.Add(producer);
        }
        public void UpdateProducer(Producer producer)
        {
            producerDAL.UpdateProducer(producer);
        }
        public void DeleteProducer(Producer producer)
        {
            producerDAL.DeleteProducer(producer);
            ProducerList.Remove(producer);
        }
    }
}
