using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Author: Juan Rojas
namespace Cruise_Center_APJ
{
    public partial class reservations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Traveller traveller = (Traveller)(Session["traveller"]);
            CruiseShipDAO cruiseDAO = new CruiseShipDAO(traveller.id, traveller.password);
            lblName.Text = traveller.fName + " " + traveller.lName;
            List<Reservation> reservations = cruiseDAO.GetReservations();
            if (reservations.Count > 0)
            {
                gvReservations.DataSource = reservations;
                gvReservations.DataBind();
            }
            else
            {
                lblNoReservations.Visible = true;
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/ReservationsPage.aspx");
        }

        
        protected void gvReservations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Traveller traveller = (Traveller)(Session["traveller"]);
            TravellerDAO travellerDAO = new TravellerDAO(traveller.id, traveller.password);
            int index = Convert.ToInt32(e.RowIndex);
            int reservationId = Convert.ToInt32(gvReservations.Rows[index].Cells[0].Text);
            travellerDAO.CancelReservation(reservationId);
            Response.Redirect("~/ReservationsPage.aspx");
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Reserve.aspx");
        }
        
    }
}