using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this method is execute on EACH and
            //   EVERY pass of the page
            //this method is execute BEFORE ANY
            //   of your event methods
        }

        protected void PressMe_Click(object sender, EventArgs e)
        {
            output.Text = "hello there " + yourname.Text;
        }
    }
}