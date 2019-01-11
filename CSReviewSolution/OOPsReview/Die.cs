using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        // Data members
        // Usually private
        private int _Side;
        private string _Color;
        //private int _FaceValue; -- Do not need because it is has auto properties 
       // private List<int> listofvalues;
       // private AnotherDefinedClass myInstance;
       // private List<AnotherDefinedClass> myInstancesOf;  -- Can use any class.
       // Treat as regular data type

        //Properties
        // Are responsible for assigning and retrieving data to/from their associated
        // data member (get/set)
        // properties need to be exposed to outside users

        // Fully implemented property
        // has a defined Data Member that the developer can directly access.
        public int Side // Properties dont need parameters. Just return datatype. ? after datatype means nullable
        {
            get
            {
                //Returns data of a specific datatype
                return _Side;
            }
            set
            {
                //assigns a supplied value to the data member
                //the supplied value is located in the keyword: value.
                // optionally include data value validation to ensure
                // an appropriate value has been supplied.
                if (value >= 6 && value <= 20)
                {
                    // this is an acceptable value to keep
                    _Side = value;
                }
                else
                {
                    // this is an unacceptable value
                    // issue a user friendly error message
                    throw new Exception("Die cannot be " + value.ToString() + "sides item. Die must be between 6-20 sides.");
                }
                
            }
        }
        // Auto implemented property
        // NO Data Member definition
        // The data member is internally created for you
        // The data member datatype is take from your return datatype
        // specified on the property header
        // auto implemented properties are usually used when there
        // is no need for internal validation.
        // Access to a value managed by an auto implemented property
        // must be done via the property
        public int FaceValue { get; set; }

    }
}
