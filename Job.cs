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
            Contractor ContractorAssigned = new Contractor();
        }
        public Job (string Title, DateTime Date, int Cost, bool Completed, Contractor ContractorAssigned)
        {
            this.Title = Title;
            this.Date = Date;   
            this.Cost = Cost;   
            this.Completed = Completed; 
            this.ContractorAssigned = ContractorAssigned;
        }



    }
}
