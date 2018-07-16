using System;
using System.Text;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customers_Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DisplayAgencyDetails();
            //getAgencyLogo();
        }
        catch (Exception ex)
        {
            
        }
    }

    private void DisplayAgencyDetails()
    {
        StringBuilder greetUser = new StringBuilder();
        if (Convert.ToDateTime("00:00").TimeOfDay <= DateTime.Now.TimeOfDay && Convert.ToDateTime("11:59").TimeOfDay >= DateTime.Now.TimeOfDay)
            greetUser.Append("<i>Good Morning,</i> ");
        else if (Convert.ToDateTime("12:00").TimeOfDay <= DateTime.Now.TimeOfDay && Convert.ToDateTime("16:59").TimeOfDay >= DateTime.Now.TimeOfDay)
            greetUser.Append("<i>Good Afternoon,</i> ");
        else if (Convert.ToDateTime("17:00").TimeOfDay <= DateTime.Now.TimeOfDay && Convert.ToDateTime("23:59").TimeOfDay >= DateTime.Now.TimeOfDay)
            greetUser.Append("<i>Good Evening,</i> ");

        greetUser.Append(SCHttpSeesion.UserName.ToString());
        lblWelcomeMessage.Text = greetUser.ToString();

        //lblDate.Text = DateTime.Now.ToString();
        //lblTime.Text = DateTime.Now.ToShortTimeString();

    }
}