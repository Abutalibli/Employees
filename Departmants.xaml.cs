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
    /// Логика взаимодействия для Departmants.xaml
    /// </summary>
    public partial class Departmants : Page
    {
        public Departmants()
        {
            InitializeComponent();
            DGridDepartment.ItemsSource = EmployeesEntities.GetContext().Department.ToList();
            CmbFiltrLogin2.ItemsSource = EmployeesEntities.GetContext().Department.ToList();
            CmbFiltrLogin2.SelectedValuePath = "IdDepartmant";
            CmbFiltrLogin2.DisplayMemberPath = "name";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddEditDepartment((sender as Button).DataContext as Department));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddEditDepartment(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var departmentForRemoving = DGridDepartment.SelectedItems.Cast<Department>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {departmentForRemoving.Count()} записи?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EmployeesEntities.GetContext().Department.RemoveRange(departmentForRemoving);
                    EmployeesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridDepartment.ItemsSource = EmployeesEntities.GetContext().Department.ToList();
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) 
            {
                EmployeesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridDepartment.ItemsSource = EmployeesEntities.GetContext().Department.ToList();
            }
        }

        private void CmbFiltrLogin2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbFiltrLogin2.SelectedValue);
            DGridDepartment.ItemsSource = EmployeesEntities.GetContext().Department.Where(x => x.IdDepartmant == id).ToList();
        }

        private void SearсhDepartmants_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DGridDepartment.ItemsSource != null)
            {
                DGridDepartment.ItemsSource = EmployeesEntities.GetContext().Department.Where(x => x.name.ToLower().Contains(SearсhDepartmants.Text.ToLower())).ToList();
            }
            if (SearсhDepartmants.Text.Count() == 0) DGridDepartment.ItemsSource = EmployeesEntities.GetContext().Department.ToList();
        }
    }
}
