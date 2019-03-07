using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DDL
    {
        public int ValueField { get; set; }
        public string DisplayField { get; set; }
        public DDL()
        {
            //default
        }
        public DDL(int valuefield, string displayfield)
        {
            ValueField = valuefield;
            DisplayField = displayfield;
        }
    }
}