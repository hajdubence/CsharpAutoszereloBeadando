using AutoSzerelo_Client.DataProviders;
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
using WebApi_Common.Models;

namespace AutoSzerelo_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateCustomersListBox();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedCustomer = CustomerListBox.SelectedItem as Repair;

            if (selectedCustomer != null)
            {
                var window = new CustomerWindow(selectedCustomer);
                if(window.ShowDialog() ?? false)
                {
                    UpdateCustomersListBox();
                }

                CustomerListBox.UnselectAll();
            }

        }

        private void UpdateCustomersListBox()
        {
            var customers = CustomerDataProvider.GetCustomers().ToList();
            CustomerListBox.ItemsSource = customers;    
        }
    }
}
