using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cruise_Center_APJ
{
    public class Traveller
    {
        public string id { get; set; }
        public string password { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }

        public Traveller(string id, string password, string fName, string lName)
        {
            this.id = id;
            this.password = password;
            this.fName = fName;
            this.lName = lName;
        }

        public override string ToString()
        {
            return String.Format("travellerID: {0}, first Name: {1}, Last Name: {2},", id, fName, lName);
        }  
       
    }
}