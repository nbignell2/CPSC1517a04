using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class GridViewData
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullorPartTime { get; set; }
        public string Jobs { get; set; }

        public GridViewData()
        {

        }
        public GridViewData(string fullname, string emailaddress,
            string phonenumber, string fullorparttime, string jobs)
        {
            FullName = fullname;
            EmailAddress = emailaddress;
            PhoneNumber = phonenumber;
            FullorPartTime = fullorparttime;
            Jobs = jobs;
        }
    }
}