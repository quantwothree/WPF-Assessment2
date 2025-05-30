using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assessment_2_Project
{
    public partial class MainWindow : Window
    {
        private ProjectManager projectManager = new ProjectManager();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender; // Declare and cast the sender to button 
            if (button == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(FirstNameTextBox.Text) || int.TryParse(FirstNameTextBox.Text, out int result)) 
            {
                MessageBox.Show("Please enter your first name"); 
            }
            else if (string.IsNullOrEmpty(LastNameTextBox.Text) || int.TryParse(LastNameTextBox.Text, out int result2))
            {
                MessageBox.Show("Please enter your last name");
            }
            else if (DOBPicker.SelectedDate == null)
            {
                MessageBox.Show("Please select your DoB");
            }
            else if (!int.TryParse(HourlyRateTextBox.Text, out int HourlyRate))
            {
                MessageBox.Show("Please enter your hourly rate: ");
            }
            else
            {
                Contractor contractor = new Contractor(FirstNameTextBox.Text, LastNameTextBox.Text, (DOBPicker.SelectedDate.Value), HourlyRate);
                projectManager.addContractor(contractor);
                MessageBox.Show("Contractor added!"); 
            }
        }

        private void GetContractorsButton_Click(object sender, RoutedEventArgs e)
        {
            List<Contractor> contractorsList = projectManager.getContractors();
            ContractorListBox.ItemsSource = null; // reset the the list so that ListBox recognises the changes to the list so that everytime the button is click the lastest list is shown 
            ContractorListBox.ItemsSource = contractorsList;

        }

        private void JobSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(JobTitleTextBox.Text) || int.TryParse(JobTitleTextBox.Text, out int result))
            {
                MessageBox.Show("Please enter a job name");
            }
            else if (string.IsNullOrEmpty(JobCostTextBox.Text))
            {
                MessageBox.Show("Please enter job's cost");
            }
            else if (!int.TryParse(JobCostTextBox.Text, out int JobCost)) // if job cost is not a number then show massage, if is a number then put in JobCost
            {
                MessageBox.Show("Please enter job's cost");
            }
            else if (JobDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a date for the job");
            }
            else
            {
                Job job = new Job(JobTitleTextBox.Text, JobDatePicker.SelectedDate.Value,JobCost); // same with HourlyRate as above, it needs to be an int, .Text returns a string
                projectManager.addJob(job);
                MessageBox.Show("Job added!");
            }
        }

        private void GetJobsButton_Click(object sender, RoutedEventArgs e)
        {
            List<Job> jobsList = projectManager.getJobs();
            JobListBox.ItemsSource = null; // reset the the list so that JobListBox recognises the changes to the list so that everytime the button is click the lastest list is shown 
            JobListBox.ItemsSource= jobsList;
        }

        private void CompleteJobButton_Click(object sender, RoutedEventArgs e)
        {
            Job selectedJob = JobListBox.SelectedItem as Job; // what does this mean ?
            if (selectedJob == null)
            {
                // if no jobs selected
                MessageBox.Show("Please choose a job to complete"); 
            }
            else
            {
                projectManager.completeJob(selectedJob);
                MessageBox.Show("Job is comepleted!"); 
            }
        }

        private void AssignJobButton_Click(object sender, RoutedEventArgs e)
        {
            Job selectedJob = JobListBox.SelectedItem as Job;
            if (selectedJob == null)
            {
                // if no jobs selected
                MessageBox.Show("Please choose a job to assign");
            }
            else
            {
                List<Contractor> contractorsList = projectManager.getContractors();
                ContractorListBox.ItemsSource = contractorsList;
                if (contractorsList != null)
                {
                    Contractor selectedContractor = ContractorListBox.SelectedItem as Contractor;
                    if (selectedContractor == null)
                    {
                        MessageBox.Show("Please choose a contractor to assign");
                    }
                    else
                    {
                        projectManager.assignJob(selectedContractor, selectedJob);
                        MessageBox.Show(selectedContractor.ToString() + " is assigned to " + selectedJob.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("There is no contractors"); 
                }
                projectManager.getAvailableContractors(); // Is this still needed ?
            }
        }

        private void GetAvailableContractorsButton_Click(object sender, RoutedEventArgs e)
        {
            List<Contractor> contractors = projectManager.getAvailableContractors();
            ContractorListBox.ItemsSource = null;
            ContractorListBox.ItemsSource = contractors; 
        }

        private void RemoveContractorButton_Click(object sender, RoutedEventArgs e)
        {
            Contractor selectedContractor = ContractorListBox.SelectedItem as Contractor;
            if (selectedContractor == null)
            {
                // if no contractor selected
                MessageBox.Show("Please choose a contractor to remove");
            }
            else
            {
                projectManager.removeContractor(selectedContractor);
                MessageBox.Show("Contractor removed!");
            }
        
        }

        private void GetUnassignedJobsButton_Click(object sender, RoutedEventArgs e)
        {
            List<Job> jobs = projectManager.getUnassignedJobs();
            JobListBox.ItemsSource = null;
            JobListBox.ItemsSource = jobs;
        }

        private void GetJobByCostButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MaxCostTextBox.Text) || !int.TryParse(MaxCostTextBox.Text, out int MaxCost))
            {
                MessageBox.Show("Enter max cost: ");
            }
            else if (string.IsNullOrEmpty(MinCostTextBox.Text) || !int.TryParse(MinCostTextBox.Text, out int MinCost))
            {
                MessageBox.Show("Enter min cosy: ");
            }
            else
            {
                List<Job> jobList = projectManager.getJobsByCost(MinCost, MaxCost);
                JobListBox.ItemsSource = jobList;
            }

        }
    }
}