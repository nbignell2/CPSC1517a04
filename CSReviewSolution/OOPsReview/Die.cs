using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        //Create a class level variable which will be an instance of
        // of the System namespace math class Random
        //create a static instance which will be used for ALL die 
        // instances created by the programmer/developer
        // this instance of Random will be generated once on the first
        // Die instance that is created
        private static Random _rnd = new Random();

        

        // Data members
        // Usually private
        private int _Sides;
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
        public int Sides // Properties dont need parameters. Just return datatype. ? after datatype means nullable
        {
            get
            {
                //Returns data of a specific datatype
                return _Sides;
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
                    _Sides = value;
                    Roll();
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
        //  if you wish your auto implemented properties to have validation is to
        // use the private set and have the validation done somewhere/somehow elsewhere in the class.
        public int FaceValue { get; private set; }

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) //empty
                {
                    throw new Exception("Must provide a color string for the die."); // No console so you can use in other applications
                }
                else
                {
                    _Color = value;
                }
            }
        }

        // Constructors

        //Are optional
        //Purpose of a constructor is to ensure that when an instance of this class is created
        // it will be created within a stable state; ALWAYS
        // You do not call the constructor directly, it is called for you when you create
        // an instance of the class.
        //if you do not code a constructor, then the compiler will create a default contructor -- 0 or null
        //Since this is not valid in our system, we need to code a constructor
        // If you do code a constructor, you are responsible for ALL constructors for the class.
        //Syntax - public classname([list of parameters]) { coding block } -- NO RETURN DATATYPE
        // [] == optional

        //Default Constructor

        //Is similar to the default system constructor.
        public Die()
        {
            // if you leave this empty, it is the same as system default constructor
            // Optionally, you can set your own default values.
            _Sides = 6;     //Via datamember 
            Color = "White";    //Via property -Usually
            Roll();
        }


        //Greedy Constructor 

        //This constructor will allow the user of the class to pass in a set of values
        // That will be used at the time of instance creation to set the values of the 
        // internal datamember's auto properties.
        public Die(int sides, string color, int facevalue)
        {
            Sides = sides; //Do not set it to datamember because users can't be trusted!
            Color = color;
            Roll(); // an internal method of this Die class
        }

        //Behaviours (methods)
        
        // Are methods that can be used by the outside user to 
        // a) affect values within the instance
        // b) use instance data to generate and return information
        public void Roll()
        {
            // Random can take a set of values and produce a integer value
            // between the two values, where the minimum value is inclusive
            // and the maximum value is exclusive
            FaceValue = _rnd.Next(1, Sides + 1);
        }

    }

}
