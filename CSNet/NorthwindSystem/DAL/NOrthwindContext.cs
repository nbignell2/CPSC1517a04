using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this class needs to have access to ADO.Net EntityFrameWork
//the Nuget package EntryFramework has already be added to this project
//this project also needs the assembly System.Data.Entity
//this project will need using clauses that point to
//   a) the System.Data.Entity namespace
//   b) your data project namespace

#region Additional Namespaces
using System.Data.Entity;
using NorthwindSystem.Data;
#endregion

namespace NorthwindSystem.DAL
{
    //the class acces internal restrict calls to this class
    //   to methods within this project
    //this context class needs to inherit DbContext from
    //   EntityFramework

    internal class NorthwindContext:DbContext
    {
        //setup your class defualt contructor to supply your 
        //   connection string name to the DbContext inherit
        //   class
        public NorthwindContext():base("NWDB")
        {

        }

        //create a Entityframework DbSet<T> for each mapped
        //   sql table 
        // <T> is your class in the .Data project
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
