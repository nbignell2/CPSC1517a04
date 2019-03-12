using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        public static List<ContestData> EntryCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if(!Page.IsPostBack)
            {
                EntryCollection = new List<ContestData>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                //this test will fire the validation controls on the server side

                //if additional validation is require, do that first
                if (Terms.Checked)
                {
                    //user has agreed to the contest terms
                    //collect the data
                    //create/load a contest entry to the collection
                    //display the collection.
                    Message.Text = "Thank you.";

                }
                else
                {
                    Message.Text = "Entry denied.";
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Province.ClearSelection();
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }
    }
}