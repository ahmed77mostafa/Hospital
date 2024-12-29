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
    /// <summary>
    /// Interaction logic for PatientLogin.xaml
    /// </summary>
    public partial class PatientLogin : Page
    {
        Clinic_Entities db = new Clinic_Entities();
        Doctor doc = new Doctor();
        
        public PatientLogin()
        {
            InitializeComponent();
            doc_DG.ItemsSource = db.Doctors.ToList();
        }

        private void doc_search_Click(object sender, RoutedEventArgs e)
        {
            var search_doc = db.Doctors.Where(x => x.doc_name.Contains(doc_textbox.Text.ToString())).ToList();
            doc_DG.ItemsSource = search_doc;
        }
    }
}
