using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_Project
{
    public class Contractor
    {
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public DateTime StartDate { get; set; }
        public float HourlyRate { get; set; }

        public Contractor ()
        {

        }

        public Contractor (string FirstName, string LastName, DateTime StartDate, float HourlyRate )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.StartDate = StartDate;
            this.HourlyRate = HourlyRate;
        }


    }
}
