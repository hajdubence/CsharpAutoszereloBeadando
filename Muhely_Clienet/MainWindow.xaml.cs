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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Muhely_Clienet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateRepairDataGrid();
        }

        private void RepairDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedRepair = RepairDataGrid.SelectedItem as Repair;

            if (selectedRepair != null)
            {
                var window = new RepairInfoWindow(selectedRepair);
                if (window.ShowDialog() ?? false)
                {
                    UpdateRepairDataGrid();
                }

                RepairDataGrid.UnselectAllCells();
            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateRepairDataGrid();
        }

        private void UpdateRepairDataGrid()
        {
            var repairs = RepairDataProvider.GetRepairs().ToList();
            RepairDataGrid.DataContext = repairs;
        }
    }
}
