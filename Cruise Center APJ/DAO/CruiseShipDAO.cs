using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace Cruise_Center_APJ
{
    // Author: Ali Umar
    public class CruiseShipDAO
    {
        private string username { get; set; }
        private string password { get; set; }

        public CruiseShipDAO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public List<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", this.username, this.password));
                OracleCommand cmd = new OracleCommand("SELECT * FROM reservation INNER JOIN cruise USING(ship_id) WHERE traveller_id = :traveller_id", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();

                cmd.Parameters.AddWithValue("traveller_id", username);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int resId = Convert.ToInt32(dr["reservation_id"]);
                    int shipId = Convert.ToInt32(dr["ship_id"]);
                    string shipName = Convert.ToString(dr["ship_name"]);
                    int cabNo = Convert.ToInt32(dr["cabin_no"]);
                    reservations.Add(new Reservation(resId, shipName, cabNo, String.Join(",", this.GetDestinations(shipId))));
                }

            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Exception Thrown! Message: {0}", ex.Message));
            } 
            return reservations;
        }

        public List<string> GetDestinations(int ShipId)
        {
            List<string> destinations = new List<string>();
            try
            {
                OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", this.username, this.password));
                OracleCommand cmd = new OracleCommand("SELECT destination FROM destination WHERE ship_id = :ship_id ORDER BY destination", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();

                cmd.Parameters.AddWithValue("ship_id", ShipId);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    string dest = Convert.ToString(dr["destination"]);
                    destinations.Add(dest);
                }

            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Exception Thrown! Message: {0}", ex.Message));
            } 
            return destinations;
        }
    }
}