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
    /// Логика взаимодействия для AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Page
    {
        public Employee _employee = new Employee();
        public AddEditEmployee(Employee selectedEmployee)
        {
            InitializeComponent();

            if (selectedEmployee != null)
                _employee = selectedEmployee;
            DataContext = _employee;
            ComboKids.ItemsSource = EmployeesEntities.GetContext().Kid.ToList();
            ComboDepartmants.ItemsSource = EmployeesEntities.GetContext().Department.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_employee.IdEmployee == 0)
                EmployeesEntities.GetContext().Employee.Add(_employee);

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
