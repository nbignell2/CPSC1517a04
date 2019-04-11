using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.Data.Views;
using NorthwindSystem.DAL;
using System.ComponentModel;
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject]
    public class SupplierController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Supplier> Supplier_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Suppliers.ToList();
            }
        }

        public List<SupplierCategories> Suppliers_GetCategories(int suppilerid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<SupplierCategories> results =
                    context.Database.SqlQuery<SupplierCategories>("Suppliers_GetCategories @SupplierID",
                                    new SqlParameter("SupplierID", suppilerid));
                return results.ToList();
            }
        }
    }
}
