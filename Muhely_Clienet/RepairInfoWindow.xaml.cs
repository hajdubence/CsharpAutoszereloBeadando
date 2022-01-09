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

namespace Muhely_Clienet
{
    /// <summary>
    /// Interaction logic for RepairInfoWindow.xaml
    /// </summary>
    public partial class RepairInfoWindow : Window
    {
        private readonly Repair _repair;
        public RepairInfoWindow(Repair repair)
        {
            InitializeComponent();

            if (repair != null)
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

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                _repair.Status = (Status)StatusComboBox.SelectedIndex;

                RepairDataProvider.UpdateRepair(_repair, _repair.Id);

                DialogResult = true;
                Close();
            }
        }
    }
}
