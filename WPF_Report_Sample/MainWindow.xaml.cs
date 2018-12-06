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
        }

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
            var vm = new ViewModel();

            var orders = vm.Orders.Where(o => o.OrderId == par);
            var OrderDetails = vm.OrderDetails.Where(o => o.OrderId == par);

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
