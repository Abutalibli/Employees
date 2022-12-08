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
using System.Windows.Shapes;
using Employees.Classes;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для AddEditKid.xaml
    /// </summary>
    public partial class AddEditKid : Page
    {
        private Kid _kid = new Kid();
        public AddEditKid(Kid selectedKid)
        {
            InitializeComponent();

            if (selectedKid != null)
                _kid = selectedKid;

            DataContext = _kid;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_kid.idKid == 0)
                EmployeesEntities.GetContext().Kid.Add(_kid);

            try
            {
                EmployeesEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
