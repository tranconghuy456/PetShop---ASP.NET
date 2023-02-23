using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop.Views.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ToastMessage(object[] options)
        {
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            string strUsername = username.Value;
            string strPassword = password.Value;

            if (users.Connect())
            {
                if (users.UserCheckPoint(strUsername, strPassword) > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "okok");
                }
            }
        }
    }
}