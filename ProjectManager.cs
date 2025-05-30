using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_Project
{
    public class ProjectManager 
    {
        List<Contractor> contractors = new List<Contractor>();

        List<Contractor> assignedContractors = new List<Contractor>();

        List<Job> jobs = new List<Job>();

        List<Job> assignedJobs = new List<Job>();   


        public void addContractor (Contractor contractorToAdd)
        {
            contractors.Add(contractorToAdd);
        }
        public void removeContractor (Contractor contractorToRemove)
        {
            contractors.Remove(contractorToRemove);
        }
        public List<Contractor> getContractors()
        {
            if (assignedContractors == null)
            {
                return contractors;
            }
            else
            {
                List<Contractor> temporary = new List<Contractor>(contractors);
                temporary.AddRange(assignedContractors); //AddRange adds a list to another list, its an action, returns nothing
                return temporary; // temporary now includes contractors + assignedContractors 
            }
        }
        public void addJob (Job jobToAdd)
        {
            jobs.Add(jobToAdd);
        }
        public void removeJob (Job jobToRemove) // optional 
        {
            jobs.Remove(jobToRemove); 
        }
        public List<Job> getJobs ()
        {
            if (assignedJobs == null)
            {
                return jobs;
            }
            else
            {
                List<Job> temporary = new List<Job>(jobs);
                temporary.AddRange(assignedJobs); //AddRange adds a list to another list, its an action, returns nothing
                return temporary; // temporary now includes jobs + assignedJobs 
            }
        }

        public void assignJob(Contractor contractorToAssign, Job jobToAssign)
        {
            jobToAssign.ContractorAssigned = contractorToAssign;

            assignedContractors.Add(contractorToAssign);

            contractors.Remove(contractorToAssign);

            assignedJobs.Add(jobToAssign);

            jobs.Remove (jobToAssign);  
        }
        public void completeJob (Job job)
        {
            job.Completed = true; 
        }
        public List<Contractor> getAvailableContractors()
        {
            return contractors; 
        }

        public List<Job> getUnassignedJobs()
        {
            return jobs; 
        }
        public List<Job> getJobsByCost(int minCost, int maxCost)
        {
            List<Job> jobsByCostAscending = new List<Job> ();
            foreach (Job job in jobs)
            {
                if (job.Cost > minCost && job.Cost < maxCost)
                {
                    jobsByCostAscending.Add(job);
                }
            }

            jobsByCostAscending.Sort((x,y) => x.Cost.CompareTo(y.Cost));
            return jobsByCostAscending;

        }


    }
}
