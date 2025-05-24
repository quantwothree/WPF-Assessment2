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
                MessageBox.Show("Contractor added!"); 
            }
        }
    }
}