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

namespace WPF_Report_Sample
{
    public partial class MainWindow : Window
    {
        int par;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Viewer.DataSources.Clear();

            //var db = new NorthwindContext();
            //this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            //{
            //    Name = "OrderDetails",
            //    Value = db.Order_Details.Where(o => o.OrderID == par)
            //});

            //this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            //{
            //    Name = "Orders",
            //    Value = db.Orders.Where(o => o.OrderID == par)
            //});

            //this.Viewer.RefreshReport();

            //db.Database.Connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            par = int.Parse(text.Text);
            SetDataSources();
        }

        private void SetDataSources()
        {
            this.Viewer.DataSources.Clear();

            var db = new NorthwindContext();
            this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            {
                Name = "OrderDetails",
                Value = db.Order_Details.Where(o => o.OrderID == par)
            });

            this.Viewer.DataSources.Add(new Syncfusion.Windows.Reports.ReportDataSource()
            {
                Name = "Orders",
                Value = db.Orders.Where(o => o.OrderID == par)
            });

            this.Viewer.RefreshReport();
            //db.Database.Connection.Close();

        }
    }
}
