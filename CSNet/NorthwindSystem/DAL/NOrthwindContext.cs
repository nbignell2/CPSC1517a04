using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity; //for the EntityFramework ADO.Net stuff
using NorthwindSystem.Data;  // for the <T> definitions
#endregion

//this class needs to have access to ADO.Net in EntityFramework
//the NuGet package Manager will have the EntityFramework, install
//this project needs the assembly System.Data.Entry
//this project needs a reference to your .Data project
//this project needs to use the following namespaces
//  a) System.Data.Entity
//  b) .Data project namespace

namespace NorthwindSystem.DAL
{
    //the class access is restricted to requests from within the
    //   library the class exists in: internal
    //the class inherits (ties into EntityFramework) the class DbContext

    internal class NorthwindContext:DbContext
    {
        //setup your class default constructor to supply
        //   your connection string name to the DbContext
        //   inherited (base) class
        public NorthwindContext():base("NWDB")
        {

        }
        //create an EntityFramework DbSet<T> for each
        //   mapped sql table
        // <T> is your class in the .Data project
        //this is a property
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
