using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SkillsCrafter.SCProxy;
using SkillsCrafter.SCShared.Utilities;

public partial class Login : System.Web.UI.Page
{
    private const string _seed = "s33d";
    ActionContext _actionContext = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmitLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (String.IsNullOrEmpty(this.txtUsername.Text) && String.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.lblMessage.Text = Resources.Controls.UserNamePasswordMandatory;
            }
            else if (String.IsNullOrEmpty(this.txtUsername.Text))
            {
                this.lblMessage.Text = Resources.Controls.EnterUserName;
                this.txtUsername.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.lblMessage.Text = Resources.Controls.EnterPassword;
                this.txtPassword.Focus();
                return;
            }
            else if (this.ValidateUser())
            {
                FormsAuthentication.SetAuthCookie(this.txtUsername.Text, true);
                SCHttpSeesion.UserName = this.txtUsername.Text;
                Response.Redirect("~/Customers.aspx");
            }
        }
        catch
        {
            
        }
    }

    private bool ValidateUser()
    {
        Boolean result = false;
        try
        {
            _actionContext = new ActionContext();
            string username = this.txtUsername.Text.ToString();
            byte[] password = Encryption.Encrypt(this.txtPassword.Text.Trim(), _seed);

            int returntype = Service.LoginService.Login(ref _actionContext, username, password);
            if (returntype == 0)
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                Session.Abandon();
                this.lblMessage.Text = String.Format("Authentication failure: {0}", _actionContext.Error);
            }
            else if (returntype == 1)
            {
                Session["UserID"] = txtUsername.Text;
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessage", "alert('Lo   gged in as Employee Successfully');window.location='EmployeeHome.aspx';", true);
            }
            else if (returntype == 2)
            {
                Session["UserID"] = txtUsername.Text;
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessage", "alert('Logged in as Unit Head Successfully');window.location='UnitheadHome.aspx';", true);
            }
            else if (returntype == 3)
            {
                Session["UserID"] = txtUsername.Text;
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessage", "alert('Logged in as HR Successfully');window.location='HRHome.aspx';", true);
            }
            if (returntype > 0)
                result = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return result;
    }
}