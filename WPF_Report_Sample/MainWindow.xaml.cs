﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_Report_Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            ViewModel = this.DataContext as MainWindowViewModel;
        }

        public MainWindowViewModel ViewModel { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = Task.Run(() => SetDataSources());
            t.Wait();

            this.Viewer.RefreshReport();
        }

        private void SetDataSources()
        {
            this.Viewer.DataSources.Clear();

            var orders = ViewModel.Orders;
            var orderDetails = ViewModel.OrderDetails;

            this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            {
                Name = "Orders",
                Value = orders
            });

            this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            {
                Name = "OrderDetails",
                Value = orderDetails
            });
        }
    }
}
