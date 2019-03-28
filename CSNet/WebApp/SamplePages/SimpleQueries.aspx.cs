using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;  //points to the controller class
using NorthwindSystem.Data; //points to the record descriptions
#endregion

namespace WebApp.SamplePages
{
    public partial class SimpleQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //any validation
            //this could be via Validatin Controls
            //  or/and
            //this could be via logic code
            int searcharg = 0;
            if (string.IsNullOrEmpty(SearchArg.Text))
            {
                // message to user missing product id for search
                MessageLabel.Text = "Product ID search value required.";
            }
            else if (int.TryParse(SearchArg.Text, out searcharg))
            {
                //create an instance of the controller class we
                //    wish to use
                ProductController sysmgr = new ProductController();
                //issue the request to this controller instance
                //   and capture the returning Product record (instance)
                Product results = sysmgr.Product_Get(int.Parse(SearchArg.Text));
                //test the returned value for null (not found)
                if (results == null)
                {
                    //   not found: not found message
                    MessageLabel.Text = "No Product from for supplied ID";
                }
                else
                {
                    //   found: product data is displayed
                    ProductID.Text = results.ProductID.ToString();
                    ProductName.Text = results.ProductName;
                }
            }
            else
            {
                MessageLabel.Text = "Product ID must be a positive numeric value.";
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            SearchArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
        }
    }
}