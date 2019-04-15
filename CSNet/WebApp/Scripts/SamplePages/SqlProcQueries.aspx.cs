using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;
#endregion


namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear old messages
            MessageLabel.Text = "";

            //the dropdownlist (ddl) control will be loaded
            //   with data from the database
            //consideration needs to be given to the data as to
            //   it change frequence
            //if your data does not change frequently then you
            //   can consider loading on page load
            if (!Page.IsPostBack)
            {
                //use user friendly error handling
                try
                {
                    //create and connect to the appropriate BLL class
                    CategoryController sysmgr = new CategoryController();
                    //issue the request to the appropriate BLL class method
                    //      and capture results
                    List<Category> datainfo = sysmgr.Category_List();
                    //optionally: sort the results
                    datainfo.Sort((x,y) => x.CategoryName.CompareTo(y.CategoryName));
                    //attach data source collection to ddl
                    CategoryList.DataSource = datainfo;
                    //set the ddl DataTextField and DataValueField properties
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = "CategoryID";
                    //physically bind the data to the ddl control
                    CategoryList.DataBind();
                    //optionally: add a prompt to the ddl control
                    CategoryList.Items.Insert(0, "select ...");
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                //  no selection: message to user
                MessageLabel.Text = "Select a product category to view products.";
            }
            else
            {
                //  yes selection: process lookup
                //          user friendly error handling
                try
                {
                    //          create and connect to BLL class
                    ProductController sysmgr = new ProductController();
                    //          issue request for lookup to appropriate BLL class method
                    //                and capture results
                  List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //          check results ( .Count() == 0)
                    if (datainfo.Count() == 0)
                    {
                        //            no records: message to user

                        //MessageLabel.Text = "No data found for select category.";
                        //optionally: you may wish to remove from display any old
                        //    data so it is NOT confused with this message
                        //CategoryProductList.DataSource = null;

                        //if you have an EmptyDataTemplate on the GridView
                        //   AND your data source is empty of record (data source
                        //   physically exists) then the message in the template
                        //   will be displayed
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //            yes records: display data
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }

        protected void CategoryProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //the developer must code this event method when they install paging
            //this method will do 2 things
            //a) set the control's PageIndex property to the data "page" of the
            //   data collection
            //   the new pageindex is located in the e parameter of this method
            CategoryProductList.PageIndex = e.NewPageIndex;

            //b) refresh the data collection for the control
            //   re issue the call to the database for data
            //   assign data results to control
            //   bind the results
            Submit_Click(sender, new EventArgs());
        }

        protected void CategoryProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //access the data on the gridview selected row
            //the rows of a gridview are in a collection referenced by .Rows
            //the row index of the selected gridview row can be referenced
            //     by .SelectedIndex
            //personal style: short form to GridViewRow pointer
            GridViewRow agvrow = CategoryProductList.Rows[CategoryProductList.SelectedIndex];

            //accessing the data on a gridview cell is dependent on how the
            //   cell was setup.
            //we are using a TemplateField with a web control inside the ItemTemplate
            //syntax:
            //   (agvrow.FindControl("controlid") as controltype).controltypeaccess
            // agvrow: points to the selected gridview row
            // .FindControl("controlid") looks for a control on the row by the ID name of
            //      controlid
            // as controltype: identifies that type of control
            // .controltypeaccess: how the type of control is accessed for data
            string productid = (agvrow.FindControl("ProductID") as Label).Text;
            string productname = (agvrow.FindControl("ProductName") as Label).Text;
            string discontinued = "";
            if((agvrow.FindControl("Discontinued") as CheckBox).Checked)
            {
                discontinued = "discontinued";
            }
            else
            {
                discontinued = "available";
            }
            MessageLabel.Text = productname + " (" + productid + ") is " + discontinued;

        }
    }
}