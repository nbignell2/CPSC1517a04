using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class ContestData
    {
        private string _StreetAddress2;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 {
            get
            {
                return _StreetAddress2;
            }
            set
            {
                _StreetAddress2 = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }

        public ContestData()
        {

        }

        public ContestData(string firstname, string lastname, string streetaddress1,
            string streetaddress2, string city, string province, string postalcode,
            string email)
        {
            FirstName = firstname;
            LastName = lastname;
            StreetAddress1 = streetaddress1;
            StreetAddress2 = streetaddress2;
            City = city;
            Province = province;
            PostalCode = postalcode;
            Email = email;
        }
    }
}