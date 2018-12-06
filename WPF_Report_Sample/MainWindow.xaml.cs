using System;
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
        int par;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            ViewModel = this.DataContext as MainWindowViewModel;
        }

        public MainWindowViewModel ViewModel { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            par = int.Parse(text.Text);

            var t = Task.Run(() => SetDataSources());
            t.Wait();

            this.Viewer.RefreshReport();
        }

        private void SetDataSources()
        {
            this.Viewer.DataSources.Clear();
            //var vm = new ViewModel();

            //var vm = (this.DataContext as ViewModel);

            var orders = ViewModel.Orders.Where(o => o.OrderId == par);
            var OrderDetails = ViewModel.OrderDetails.Where(o => o.OrderId == par);

            this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            {
                Name = "Orders",
                Value = orders
            });

            this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            {
                Name = "OrderDetails",
                Value = OrderDetails
            });
        }
    }
}
