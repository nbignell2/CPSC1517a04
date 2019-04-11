using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Data;     //access to data definitions
using NorthwindSystem.DAL;      //access to context class
using System.Data.SqlClient;    //access to SqlParameter()
using System.ComponentModel;
#endregion

namespace NorthwindSystem.BLL
{
    //this class will be called from an external source
    //in our example, this source will be the web page
    //naming standard is <T>Controller which represents
    //    a particular data class (sql table)
    [DataObject]
    public class ProductController
    {
        #region Queries
        //code methods which will be called for processing
        //methods will be public
        //these methods are referred to as the system interface

        //a method to lookup a record on the database table
        //    by primary key
        //input: primary key value
        //output: instance of data class
        public Product Product_Get(int productid)
        {
            //the processing of the request will be done
            //  in a transaction using the Context class
            //a) instance of Context class
            //b) issue the request for lookup via the appropriate
            //      DbSet<T>
            //c) return results
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }

        //a method to retreive all records on the DbSet<T>
        //input: none
        //ouput: List<T>
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
    

        //at times you will need to do a NON-PRIMARY KEY lookup
        //you will NOT be able to use .Find(pkey)
        //you can call sql procedures via your context class
        //    within your bll class method
        //use will use .Database.SqlQuery<T>()  NOT the DbSet<T>
        //the argument(s) for SqlQuery are
        // a) the sql procedure execute statement (as a string)
        // b) IF REQUIRED, any arguments for the procedure
        //passing the data arguments to the procedure will make use of
        //      new SqlParameter() object
        //the SqlParameter object needs a using clause: System.Data.SqlClient
        //SqlParameter takes two arguments
        // a) procedure parameter name
        // b) value to be passed
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Product> Product_GetByCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //normally you will find that data from EntityFramework
                //     returns as an IEnumerable<T> datatype
                //one can convert the IEnumerable<T> to a List<T> using .ToList()
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>(
                        "Products_GetByCategories @CategoryID",
                        new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }
        public List<Product> Products_GetByPartialProductName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }

      

        public List<Product> Products_GetBySupplierPartialProductName(int supplierid, string partialproductname)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes there may be a sql error that does not like the new SqlParameter()
                //       coded directly in the SqlQuery call
                //if this happens to you then code your parameters as shown below then
                //       use the parm1 and parm2 in the SqlQuery call instead of the new....
                //don't know why but its weird
                //var parm1 = new SqlParameter("SupplierID", supplierid);
                //var parm2 = new SqlParameter("PartialProductName", partialproductname);
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetBySupplierPartialProductName @SupplierID, @PartialProductName",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("PartialProductName", partialproductname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetForSupplierCategory(int supplierid, int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetForSupplierCategory @SupplierID, @CategoryID",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategoryAndName(int category, string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategoryAndName @CategoryID, @PartialName",
                                    new SqlParameter("CategoryID", category),
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
        #endregion

        #region Add, Update and Delete of CRUD

        //The Add method will be used to insert a product instance into the database
        //This method will recieve an instance of Product
        //This method can optionally return the new identity primary key
        public int Product_Add(Product item)
        {
            //the addition of the data will be done in a transaction block
            using (var context = new NorthwindContext())
            {

                //Step 1: Staging
                //one adds the new instance to the appropriate DbSet<T>
                //the data needs to be in an instance of <T> 
                //staging does NOT place the record on the database
                //if the primary key of the <T> is an identity type
                //    the pkey value is NOT yet set
                context.Products.Add(item);

                //step 2: Committing transaction
                //if the command to save your DbSet changes is NOT executed
                //   the transaction fails and a RollBack is performed
                //if the command to save your DbSet changes is executed and fails
                //   the transaction is RollBacked and the appropriate error message
                //   is issued
                //at this point ANY entity validation is executed
                //if the command to save your DbSet changes is successful then the
                //   data is in the database (unless the database finds an exception)
                //at this point your new identity pkey value is present in your
                //   <T> instance and can be retrieved
                context.SaveChanges();

                //optionally you can return the new pKey value
                return item.ProductID;
            }
        }

        //Update
        //this logic will maintain the entire database record when updating
        //the result of the commit will return the number of rows affected
        //input: an instance of your <T>, with the pkey value included
        //output: rows affected
        public int Product_Update(Product item)
        {
            //transaction
            using (var context = new NorthwindContext())
            {
                //staging
                //the entire record will be staged
                //optionally
                //   there may be additional attributes on your
                //   record that track when updates are done and/or
                //   track who did the updates
                //   these attributes are filled by the logic in 
                //   this control and SHOULD NOT be expected from
                //   the user
                //item.LastModified = DateTime.Now;
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                //commit
                //this will return the number of rows affected
                return context.SaveChanges();

            }
        }

        //Delete
        //physical delete: physical removal of the record from the database
        //logical delete: usually some record attribute is set to indicate
        //                that this record should be ignored
        //input: the pkey value of the record
        //output: rows affected
        public int Product_Delete(int productid)
        {
            //transaction
            using (var context = new NorthwindContext())
            {
                //physical
                //  removal of record from the database

                ////find and retain the record to remove
                //var existing = context.Products.Find(productid);
                ////stage record for removal
                //context.Products.Remove(existing);
                ////commit
                //return context.SaveChanges();

                //logical
                //  this action will actually be an Update
                //  any attributes that are required for tracking
                //      need to be handled
                //  the attribute that indicates the record is logically
                //      removed needs to be handled

                //find record to be "deleted"
                var existing = context.Products.Find(productid);
                //adjust logical/tracking attributes
                //existing.LastModified = DateTime.Now;
                existing.Discontinued = true;
                //stage for update
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                //commit
                return context.SaveChanges();
            }
        }
        #endregion
    }//eoc
}//eon
