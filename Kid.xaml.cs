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
    /// Логика взаимодействия для kid.xaml
    /// </summary>
    public partial class kid : Page
    {
        public kid()
        {
            InitializeComponent();
            DGridKid.ItemsSource = EmployeesEntities.GetContext().Kid.ToList();
            CmbFiltrLogin1.ItemsSource = EmployeesEntities.GetContext().Kid.ToList();
            CmbFiltrLogin1.SelectedValuePath = "idKid";
            CmbFiltrLogin1.DisplayMemberPath = "FIO";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddEditKid(null));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var kidForRemoving = DGridKid.SelectedItems.Cast<Kid>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {kidForRemoving.Count()} записи?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EmployeesEntities.GetContext().Kid.RemoveRange(kidForRemoving);
                    EmployeesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridKid.ItemsSource = EmployeesEntities.GetContext().Employee.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ошибка");
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new AddEditKid((sender as Button).DataContext as Kid));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbFiltrLogin1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(CmbFiltrLogin1.SelectedValue);
            DGridKid.ItemsSource = EmployeesEntities.GetContext().Kid.Where(x => x.idKid == id).ToList();
        }

        private void SearсhKid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DGridKid.ItemsSource != null)
            {
                DGridKid.ItemsSource = EmployeesEntities.GetContext().Employee.Where(x => x.FIO.ToLower().Contains(SearсhKid.Text.ToLower())).ToList();
            }
            if (SearсhKid.Text.Count() == 0) DGridKid.ItemsSource = EmployeesEntities.GetContext().Employee.ToList();
        }
    }
}
