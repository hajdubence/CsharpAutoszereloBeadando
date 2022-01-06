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
using System.Windows.Shapes;
using WebApi_Common.Models;

namespace AutoSzerelo_Client
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly Customer _customer;
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();

            if (customer != null)
            {
                _customer = customer;

                NameTextBox.Text = _customer.Name;
                CarTypeTextBox.Text = _customer.CarType;
                LicensePLateTextBox.Text = _customer.LicensePlate;
                ProblemTextBox.Text = _customer.Problem;
                DateOfRecordingTextBox.Text = _customer.DateOfRecording.ToString();
                StatusComboBox.SelectedIndex = (int)_customer.Status;
            }
        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                _customer.Status = (Status)StatusComboBox.SelectedIndex;

                CustomerDataProvider.UpdateCustomer(_customer, _customer.Id);

                DialogResult = true;
                Close();
            }
        }
    }
}
