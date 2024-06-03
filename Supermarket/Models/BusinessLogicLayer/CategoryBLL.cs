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
    public class CategoryBLL
    {
        public ObservableCollection<Category> CategoryList { get; set; }

        private CategoryDAL categoryDAL;

        public CategoryBLL()
        {
            categoryDAL = new CategoryDAL();
        }
        public ObservableCollection<Category> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }
        public void AddCategory(Category category)
        {
            categoryDAL.AddCategory(category);
            CategoryList.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            categoryDAL.UpdateCategory(category);

        }
        public void DeleteCategory(Category category)
        {
            categoryDAL.DeleteUser(category);
            CategoryList.Remove(category);
        }

        
    }
}
