using AutoSzerelo_Common.DataProviders;
using AutoSzerelo_Common.Models;
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

namespace Iroda_Client
{
    /// <summary>
    /// Interaction logic for RepairInfoWindow.xaml
    /// </summary>
    public partial class RepairInfoWindow : Window
    {
        private Repair _repair;
        public RepairInfoWindow(Repair repair)
        {
            InitializeComponent();

            if (repair == null)
            {
                CustomerNameTextBox.IsReadOnly = false;
                CarTypeTextBox.IsReadOnly = false;
                CarLicensePLateTextBox.IsReadOnly = false;
                ProblemTextBox.IsReadOnly = false;
            }
            else
            {
                _repair = repair;
                CustomerNameTextBox.Text = _repair.CustomerName;
                CarTypeTextBox.Text = _repair.CarType;
                CarLicensePLateTextBox.Text = _repair.CarLicensePlate;
                ProblemTextBox.Text = _repair.Problem;
                DateOfRecordingTextBox.Text = _repair.DateOfRecording.ToString();
                StatusComboBox.SelectedIndex = (int)_repair.Status;
            }
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: validate

            if (_repair == null)
            {
                _repair = new Repair();
                _repair.CustomerName = CustomerNameTextBox.Text;
                _repair.CarType = CarTypeTextBox.Text;
                _repair.CarLicensePlate = CarLicensePLateTextBox.Text;
                _repair.Problem = ProblemTextBox.Text;

                RepairDataProvider.AddRepair(_repair);
            }
            else
            {
                _repair.CustomerName = CustomerNameTextBox.Text;
                _repair.CarType = CarTypeTextBox.Text;
                _repair.CarLicensePlate = CarLicensePLateTextBox.Text;
                _repair.Problem = ProblemTextBox.Text;
                _repair.Status = (Status)StatusComboBox.SelectedIndex;

                RepairDataProvider.UpdateRepair(_repair, _repair.Id);
            }

            DialogResult = true;
            Close();
        }
        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
