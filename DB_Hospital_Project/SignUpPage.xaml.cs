using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        
        Clinic_Entities db = new Clinic_Entities();
        Doctor doc = new Doctor();
        Patient patient_ = new Patient();
        Nurse nurse = new Nurse();
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            NavigationService.Navigate(loginPage);
        }

        private void signUP_button_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_" };
            string[] nums = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] chars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };
            bool speacial = false;
            bool nums_ = false;
            bool chars_ = false ;
            int SelectedByIndex = Sign_combobox.SelectedIndex;
            for (int i = 0; i < password_txtbox.Text.Length; i++)
            {
                if (password_txtbox.Text.Contains(arr[i]))
                {
                    speacial = true;
                }
                else if (password_txtbox.Text.Contains(nums[i]))
                {
                    nums_ = true;
                }
                else if (password_txtbox.Text.Contains(chars[i]))
                {
                    chars_ = true;
                }
            }
            if(speacial == true && nums_ == true && chars_ == true)
            {
                if (SelectedByIndex == 0)
                {
                    doc.doc_name = username_txtbox.Text;
                    doc.doc_password = password_txtbox.Text;

                    db.Doctors.Add(doc);
                    db.SaveChanges();

                    MessageBox.Show("1 Doctor has added successfully!");
                }
                else if (SelectedByIndex == 1)
                {
                    patient_.name_ = username_txtbox.Text;
                    patient_.password_ = password_txtbox.Text;

                    db.Patients.Add(patient_);
                    db.SaveChanges();

                    MessageBox.Show("1 Patient has added successfully!");
                }
                else if (SelectedByIndex == 2)
                {
                    nurse.nurse_name = username_txtbox.Text;
                    nurse.nurse_password = password_txtbox.Text;

                    db.Nurses.Add(nurse);
                    db.SaveChanges();

                    MessageBox.Show("1 Nurse has added successfully!");
                }
            }

            
           

            
        }

        private void Sign_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedByIndex = Sign_combobox.SelectedIndex;
            if (SelectedByIndex == 0)
            {
                signUP_label.Content = "Doctor SignUP";
            }
            else if (SelectedByIndex == 1)
            {
                signUP_label.Content = "Patient SignUP";
            }
            else if (SelectedByIndex == 2)
            {
                signUP_label.Content = "Nurse SignUP";
            }
        }
    }
}
