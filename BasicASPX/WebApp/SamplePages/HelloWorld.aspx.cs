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
            //this method will execute EACH and EVERY time
            //     this page is processed
            //this method will execute BEFORE ANY event method
        }

        protected void PressMe_Click(object sender, EventArgs e)
        {
            OutputMessage.Text = "Hello " + yourname.Text;
        }
    }
}