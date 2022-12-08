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
using Employees.Classes;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для Empp.xaml
    /// </summary>
    public partial class Empp : Page
    {
        public Empp()
        {
            InitializeComponent();
            DGridEmployees.ItemsSource = EmployeesEntities.GetContext().Employee.ToList();
            CmbFiltrLogin.ItemsSource = EmployeesEntities.GetContext().Employee.ToList();
            CmbFiltrLogin.SelectedValuePath = "IdEmployee";
            CmbFiltrLogin.DisplayMemberPath = "FIO";

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddEditEmployee((sender as Button).DataContext as Employee));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddEditEmployee(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var employeeForRemoving = DGridEmployees.SelectedItems.Cast<Employee>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {employeeForRemoving.Count()} записи?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EmployeesEntities.GetContext().Employee.RemoveRange(employeeForRemoving);
                    EmployeesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridEmployees.ItemsSource = EmployeesEntities.GetContext().Employee.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbFiltrLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbFiltrLogin.SelectedValue);
            DGridEmployees.ItemsSource = EmployeesEntities.GetContext().Employee.Where(x => x.IdEmployee == id).ToList();
        }

        private void SearсhEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DGridEmployees.ItemsSource != null)
            {
                DGridEmployees.ItemsSource = EmployeesEntities.GetContext().Employee.Where(x => x.FIO.ToLower().Contains(SearсhEmployee.Text.ToLower())).ToList();
            }
            if (SearсhEmployee.Text.Count() == 0) DGridEmployees.ItemsSource = EmployeesEntities.GetContext().Employee.ToList();
        }
    }
}
