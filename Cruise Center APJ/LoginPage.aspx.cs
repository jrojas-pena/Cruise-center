using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Author: Ali Umar
namespace Cruise_Center_APJ
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    TravellerDAO travellerDAO = new TravellerDAO(userTextbox.Text.ToUpper(), passTextbox.Text);
                    Traveller traveller = travellerDAO.AuthenticateTraveller();
                    Session.Add("traveller", traveller); // Save login information into session
                    Response.Redirect("~/ReservationsPage.aspx"); // Replace with your page
                } catch (Exception ex)
                {
                    errorLabel.Visible = true;
                    errorLabel.Text = "Invalid login! Oracle error: " + ex.Message;
                }
            }
        }
    }
}