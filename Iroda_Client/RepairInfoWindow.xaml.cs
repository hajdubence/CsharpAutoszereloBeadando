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
                DateOfRecordingLabel.Visibility = Visibility.Collapsed;
                DateOfRecordingTextBox.Visibility = Visibility.Collapsed;
                StatusLabel.Visibility = Visibility.Collapsed;
                StatusComboBox.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
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
            Repair validatedRepair = new Repair();
            validatedRepair.CustomerName = CustomerNameTextBox.Text;
            validatedRepair.CarType = CarTypeTextBox.Text;
            validatedRepair.CarLicensePlate = CarLicensePLateTextBox.Text;
            validatedRepair.Problem = ProblemTextBox.Text;

            if (!validatedRepair.ValidateCustomerName())
                MessageBox.Show("Ügyfél neve nem lehet üres és nem tatalmazhat speciális karaktereket vagy számokat.",
                    "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (!validatedRepair.ValidateCarType())
                MessageBox.Show("Autó típusa nem lehet üres és nem tatalmazhat speciális karaktereket.",
                    "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (!validatedRepair.ValidateCarLicensePlate())
                MessageBox.Show("Rendszám nem lehet üres és a következö formátmunak kell lennie: XXX-000",
                    "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (!validatedRepair.ValidateProblem())
                MessageBox.Show("Probléma leírása nem lehet üres.",
                    "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                if (_repair == null)
                {
                    RepairDataProvider.AddRepair(validatedRepair);
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
            
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztosan törli?", "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                RepairDataProvider.DeleteRepair(_repair.Id);
                DialogResult = true;
                Close();
            }
        }

    }
}
