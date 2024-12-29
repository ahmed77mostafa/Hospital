using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// <summary>
    /// Interaction logic for DoctorLogin.xaml
    /// </summary>
    public partial class DoctorLogin : Page
    {
        Clinic_Entities db = new Clinic_Entities();
        Patient patient_ = new Patient();
        public DoctorLogin()
        {
            InitializeComponent();
            DG_doc.ItemsSource = db.Patients.ToList();
        }


        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            patient_ = db.Patients.FirstOrDefault(x => x.phone == Phone_txtbox.Text);
            patient_.phone = Phone_txtbox.Text;
            db.Patients.AddOrUpdate(patient_);

            MessageBox.Show("Phone has changed successfully!!");
            db.SaveChanges();

            DG_doc.ItemsSource = db.Patients.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            patient_ = db.Patients.FirstOrDefault(x => x.phone == Phone_txtbox.Text);
            db.Patients.Remove(patient_);

            MessageBox.Show("Patient has deleted successfully!!");
            db.SaveChanges();

            DG_doc.ItemsSource = db.Patients.ToList();
        }
    }
}
