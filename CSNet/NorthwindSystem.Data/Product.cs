using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the annotations used within the .Data project will require the 
// System.ComponenetModel.DataAnnotation assembly
// this assembly is added via your references


namespace NorthwindSystem.Data
{
    //use an annotation to link this class to the appropriate
    // SQL table
    [Table("Products")]
    public class Product
    {
    }
}
