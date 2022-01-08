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
using WpfAppDemoCRUD.Data;

namespace WpfAppDemoCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDbContext dbContext;
        Employee NewEmployee = new Employee();

        public MainWindow(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetEmployees();

            AddNewEmployeeGrid.DataContext = NewEmployee;
        }

        private void GetEmployees()
        {
            EmployeeDG.ItemsSource = dbContext.Employees.ToList();
        }

        private void AddEmployee(object s, RoutedEventArgs e)
        {
            dbContext.Employees.Add(NewEmployee);
            dbContext.SaveChanges();
            GetEmployees();
            NewEmployee = new Employee();
            AddNewEmployeeGrid.DataContext = NewEmployee;
        }

        Employee selectedEmployee = new Employee();
        private void UpdateEmployeeForEdit(object s, RoutedEventArgs e)
        {
            selectedEmployee = (s as FrameworkElement).DataContext as Employee;
            UpdateEmployeeGrid.DataContext = selectedEmployee;
        }

        private void UpdateEmployee(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedEmployee);
            dbContext.SaveChanges();
            GetEmployees();
        }

        private void DeleteEmployee(object s, RoutedEventArgs e)
        {
            var employeeToBeDeleted = (s as FrameworkElement).DataContext as Employee;
            dbContext.Employees.Remove(employeeToBeDeleted);
            dbContext.SaveChanges();
            GetEmployees();
        }
    }
}
