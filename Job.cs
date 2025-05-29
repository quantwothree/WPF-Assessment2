using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_Project
{
    public class Job
    {
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; } 
        public int Cost { get; set; }
        public bool Completed { get; set; }
        public Contractor ContractorAssigned { get; set; } 

        public Job()
        { 
            this.ContractorAssigned = new Contractor();
            this.Completed = false; 
        }
        public Job (string Title, DateTime Date, int Cost)
        {
            this.Title = Title;
            this.Date = Date;   
            this.Cost = Cost;   
        }
        public override string ToString() // To display proper text on MiddleListBox, changing how ToString() behave on a Job object 
        {
            return $"{Title} {Date} - ${Cost}";
        }


    }
}
