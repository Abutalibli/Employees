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
    /// Логика взаимодействия для AddEditDepartment.xaml
    /// </summary>
    public partial class AddEditDepartment : Page
    {
        private Department _departmants = new Department();
        public AddEditDepartment(Department selectedDepartment)
        {
            InitializeComponent();
            if (selectedDepartment != null) 
                _departmants = selectedDepartment;
            
            DataContext = _departmants;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0) 
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_departmants.IdDepartmant == 0)
                EmployeesEntities.GetContext().Department.Add(_departmants);

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
