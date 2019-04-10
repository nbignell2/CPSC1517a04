using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebApp.NorthwindPages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //empty out all old messages from the DataList
            Message.DataSource = null;
            Message.DataBind();

            //load the dropdown lists on the form
            if (!Page.IsPostBack)
            {
                BindProductList();
                BindSupplierList();
                BindCategoryList();
            }

        }

        protected void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();
                List<Product> datainfo = sysmgr.Product_List();
                datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = datainfo;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select ...");
            }
            catch(Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindSupplierList()
        {
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> datainfo = sysmgr.Supplier_List();
                datainfo.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = datainfo;
                SupplierList.DataTextField = nameof(Supplier.CompanyName);
                SupplierList.DataValueField = nameof(Supplier.SupplierID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindCategoryList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> datainfo = sysmgr.Category_List();
                datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = datainfo;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //execute your form validation
            //if (Page.IsValid)
            //{
                //any logic validation on covered by form validation
                //for this example, I will assume that the CategoryID
                //     and SupplierID are needed
                if (SupplierList.SelectedIndex == 0)
                {
                    errormsgs.Add("Select a supplier");
                }
                if (CategoryList.SelectedIndex == 0)
                {
                    errormsgs.Add("Select a category");
                }

                //did one pass all logic validation
                if (errormsgs.Count() > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        //create an instance of <T>
                        Product item = new Product();
                        //extract data from form and load <T>
                        item.ProductName = ProductName.Text;
                        item.SupplierID = int.Parse(SupplierList.SelectedValue);
                        item.CategoryID = int.Parse(CategoryList.SelectedValue);
                        item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ?
                            null : QuantityPerUnit.Text;
                        if (string.IsNullOrEmpty(UnitPrice.Text.Trim()))
                        {
                            item.UnitPrice = null;
                        }
                        else
                        {
                            item.UnitPrice = decimal.Parse(UnitPrice.Text.Trim());
                        }
                        if (string.IsNullOrEmpty(UnitsInStock.Text.Trim()))
                        {
                            item.UnitsInStock = null;
                        }
                        else
                        {
                            item.UnitsInStock = Int16.Parse(UnitsInStock.Text.Trim());
                        }
                        if (string.IsNullOrEmpty(UnitsOnOrder.Text.Trim()))
                        {
                            item.UnitsOnOrder = null;
                        }
                        else
                        {
                            item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text.Trim());
                        }
                        if (string.IsNullOrEmpty(ReorderLevel.Text.Trim()))
                        {
                            item.ReorderLevel = null;
                        }
                        else
                        {
                            item.ReorderLevel = Int16.Parse(ReorderLevel.Text.Trim());
                        }
                        //logically this is a new product, therefore discontinued can
                        //    be set for the user to false
                        item.Discontinued = false;
                        //connect to appropriate BLL class
                        ProductController sysgmr = new ProductController();
                        //issue a call to the appropriate BLL method passing
                        //   the instance of <T>
                        int newProductID = sysgmr.Product_Add(item);
                        //handle the results
                        errormsgs.Add(ProductName.Text + " has been added to the database with an id of " + newProductID.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-success");

                        //refresh of the web page/web controls
                        //display the new productid in its field
                        ProductID.Text = newProductID.ToString();
                        BindProductList();
                        ProductList.SelectedValue = ProductID.Text;
                        
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }


                }
            //}
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            //execute your form validation
            //if (Page.IsValid)
            //{
            //any logic validation on covered by form validation
            //for this example, I will assume that the CategoryID
            //     and SupplierID are needed
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a supplier");
            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a category");
            }

            //on the update you MUST ensure that the record's pkey value is present
            if (string.IsNullOrEmpty(ProductID.Text.Trim()))
            {
                errormsgs.Add("Search for the product to be maintained.");
            }

            //did one pass all logic validation
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    //create an instance of <T>
                    Product item = new Product();
                    //extract data from form and load <T>

                    //on the update you MUST ensure that the record's pkey value
                    //    is loaded to the instance
                    item.ProductID = int.Parse(ProductID.Text.Trim());

                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    item.QuantityPerUnit = string.IsNullOrEmpty(QuantityPerUnit.Text.Trim()) ?
                        null : QuantityPerUnit.Text;
                    if (string.IsNullOrEmpty(UnitPrice.Text.Trim()))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(UnitsInStock.Text.Trim()))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(UnitsOnOrder.Text.Trim()))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(ReorderLevel.Text.Trim()))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text.Trim());
                    }

                    //on an update, you take the value from the control
                    item.Discontinued = Discontinued.Checked;


                    //connect to appropriate BLL class
                    ProductController sysgmr = new ProductController();
                    //issue a call to the appropriate BLL method passing
                    //   the instance of <T>
                    int rowsaffected = sysgmr.Product_Update(item);
                    //handle the results
                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been updated. Search the product again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        //consider refreshing the necessary controls on your form
                        BindProductList();
                        ProductID.Text = "";
                    }
                    else
                    {
                         errormsgs.Add(ProductName.Text + " has been updated");
                         LoadMessageDisplay(errormsgs, "alert alert-success");
                        //consider refreshing the necessary controls on your form
                        BindProductList();
                        ProductList.SelectedValue = ProductID.Text;
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }


            }
            //}
        }

        protected void RemoveProduct_Click(object sender, EventArgs e)
        {
            //on the update you MUST ensure that the record's pkey value is present
            if (string.IsNullOrEmpty(ProductID.Text.Trim()))
            {
                errormsgs.Add("Search for the product to be maintained.");
            }

            //did one pass all logic validation
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {

                    //connect to appropriate BLL class
                    ProductController sysgmr = new ProductController();
                    //issue a call to the appropriate BLL method passing
                    //   the instance of <T>
                    int rowsaffected = sysgmr.Product_Delete(int.Parse(ProductID.Text.Trim()));
                    //handle the results
                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been discontinued. Search the product again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        //consider refreshing the necessary controls on your form
                        BindProductList();
                        ProductID.Text = "";
                    }
                    else
                    {
                        errormsgs.Add(ProductName.Text + " has been discontinued");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        //consider refreshing the necessary controls on your form

                        ////physical delete
                        //BindProductList();
                        //ProductID.Text = "";
                        ////optionally, clear the form, client decision
                        //Clear_Click(sender, new EventArgs());


                        //logical delete
                        BindProductList();
                        //refresh form controls to indicate removal
                        Discontinued.Checked = true;
                        ProductList.SelectedValue = ProductID.Text;
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }


            }
        }

       
    }
}