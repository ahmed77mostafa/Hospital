using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DB_Hospital_Project
{
    
    
    public partial class LoginPage : Page
    {
        Clinic_Entities db = new Clinic_Entities();
        Doctor doc = new Doctor();
        Patient patient_ = new Patient();
        Nurse nurse = new Nurse();
        public LoginPage()
        {
            InitializeComponent();
            
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {


            int Index = Hos_combobox.SelectedIndex;
            if(Index == 0)
            {
                var doc_ = db.Doctors.FirstOrDefault(x => x.doc_name == username_txtbox.Text && x.doc_password == password_txtbox.Text);
                if (doc_ != null)
                {
                    DoctorLogin doctorLogin = new DoctorLogin();
                    NavigationService.Navigate(doctorLogin);
                }
                else
                {
                    MessageBox.Show("Invalid doctor username or passowrd");
                }
            }
            else if(Index == 1)
            {
                var patient_ = db.Patients.FirstOrDefault(x => x.name_ == username_txtbox.Text && x.password_ == password_txtbox.Text);
                if(patient_ != null)
                {
                    PatientLogin patient = new PatientLogin();
                    NavigationService.Navigate(patient);
                }
                else
                {
                    MessageBox.Show("Invalid patient username or password");
                }
            }
            else if(Index == 2)
            {
       
                var nurse_ = db.Nurses.FirstOrDefault(x => x.nurse_name == username_txtbox.Text && x.nurse_password == password_txtbox.Text);
                if(nurse_ != null)
                {
                    NursePage nurse = new NursePage();
                    NavigationService.Navigate(nurse);
                }
                else
                {
                    MessageBox.Show("Invalid nurse username or password");
                }
            }
        }

        private void SignUP_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage Sign_page = new SignUpPage();
            NavigationService.Navigate(Sign_page);
        }

        private void Hos_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Hos_combobox.SelectedIndex;
            if(index == 0)
            {
                label.Content = "Doctor Login";
            }
            else if(index == 1)
            {
                label.Content = "Patient Login";
            }
            else if(index == 2)
            {
                label.Content = "Nurse Login";
            }
        }
    }
}
