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
        masterEntities db = new masterEntities();
        medicine medicine = new medicine();
        public DoctorLogin()
        {
            InitializeComponent();
            DG_doc.ItemsSource = db.medicines.ToList();
        }

        private void addbutton_Click(object sender, object e)
        {
            int code = int.Parse(Code_txtbox.Text);
            Medicine_txtbox.Text = medicine.med_name;
            code = medicine.med_code;

            db.medicines.Add(medicine);
            db.SaveChanges();
            DG_doc.ItemsSource = db.medicines.ToList();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            int code = int.Parse(Code_txtbox.Text);
            Medicine_txtbox.Text = medicine.med_name;
            code = medicine.med_code;

            db.medicines.AddOrUpdate(medicine);
            db.SaveChanges();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            int delete = int.Parse(Code_txtbox.Text);
            db.medicines.FirstOrDefault(x => int.Parse(x.med_code) = delete);

            db.medicines.Remove(medicine);
            db.SaveChanges();
        }
    }
}
