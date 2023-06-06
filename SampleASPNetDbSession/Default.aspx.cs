using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleASPNetDbSession
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCounter_Click(object sender, EventArgs e)
        {
            // https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/Asp-Net-session-states-in-sql-server-mode-session-state-sto/
            int counter = Convert.ToInt32(Session["Counter"]);

            counter++;
            lblCounter.Text = counter.ToString();
            Session["Counter"] = counter;
        }
    }
}