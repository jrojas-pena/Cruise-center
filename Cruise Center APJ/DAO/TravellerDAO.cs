using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
//Author: Juan Rojas
namespace Cruise_Center_APJ
{
    
    public class TravellerDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public TravellerDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
        public Traveller AuthenticateTraveller()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT first_name, last_name FROM traveller WHERE id = :traveller_id", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue(":traveller_id", UserName);
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            if (dr != null)
            {
                string fName = Convert.ToString(dr["first_name"]);
                string lName = Convert.ToString(dr["last_name"]);
                return new Traveller(UserName, Password, fName, lName);
            }
            return null;
        }
        public void CancelReservation(int ReservationId)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand();
            OracleTransaction trans;

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add(":reservation_id", OracleType.Number);
            conn.Open();
            trans = conn.BeginTransaction();
            cmd.Transaction = trans;
            try
            {

                cmd.CommandText = "DELETE FROM reservation WHERE reservation_id = :reservation_id";
                cmd.Parameters[":reservation_id"].Value = ReservationId;
                cmd.ExecuteNonQuery();

                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}