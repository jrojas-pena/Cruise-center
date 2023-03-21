using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Author: Ali Umar
namespace Cruise_Center_APJ
{
    public class Reservation
    {
        public int resId { get; set; }
        public string shipName { get; set; }
        public int cabNo { get; set; }
        public string destinations { get; set; }

        public Reservation(int resId, string shipName, int cabNo, string dest)
        {
            this.resId = resId;
            this.shipName = shipName;
            this.cabNo = cabNo;
            this.destinations = dest;
        }

        public override string ToString() 
        {
            return String.Format("reservationID: {0}, shipID: {1}, cabinNo: {2}, destinations: {3}", resId, shipName, cabNo, destinations); 
        }  

    }
}