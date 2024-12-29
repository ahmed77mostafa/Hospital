
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
    /// Interaction logic for NursePage.xaml
    /// </summary>
    
    public partial class NursePage : Page
    {
        Clinic_Entities db = new Clinic_Entities();
        Patient pat = new Patient();
        public NursePage()
        {
            InitializeComponent();

            patient_DG.ItemsSource = db.Patients.ToList();
            
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            int selectSSN = Convert.ToInt16(ssn_txtbox.Text);
            
            int age_ = Convert.ToInt16(age_txtbox.Text);
            int doctor = Convert.ToInt16(Doctor_txtbox.Text);

            pat.name_ = firstname_txtbox.Text;



            db.Patients.AddOrUpdate(pat);
            db.SaveChanges();

            patient_DG.ItemsSource = db.Patients.ToList();
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            patient_DG.ItemsSource = db.Patients.Where(x => x.name_.Contains(firstname_txtbox.Text.ToString())).ToList();

        }

    }
}
