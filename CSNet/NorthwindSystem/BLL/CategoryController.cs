using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
using System.ComponentModel;    //need to expose classes and methods for ODS dialogs
#endregion

namespace NorthwindSystem.BLL
{
    //expose the BLL class for use by the ODS dialogs in your developer
    [DataObject]
    public class CategoryController
    {
        public Category Category_Get(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
        //expose only those methods that you would consider using
        //   in the ODS dialogs
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Category> Category_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
