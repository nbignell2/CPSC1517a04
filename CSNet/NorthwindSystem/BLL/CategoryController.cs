using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
#endregion

namespace NorthwindSystem.BLL
{
    public class CategoryController
    {
        public Category Category_Get(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }

        public List<Category> Category_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
