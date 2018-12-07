using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Report_Sample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        NorthwindContext context;
        public MainWindowViewModel()
        {
            OrderId = 10248;        
        }

        public ObservableCollection<OrderObject> Orders { get; set; }

        public ObservableCollection<OrderDetailObject> OrderDetails { get; set; }

        public ObservableCollection<decimal> TotalSum { get; set; }

        private int orderId;
        public int OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                NotifyPropertyChanged();
            }
        }
        public void SetDataSets()
        {
            context = new NorthwindContext();
            var orders = context.Orders.ToList();
            var orderDetails = context.Order_Details.ToList();

            Orders = new ObservableCollection<OrderObject>
               (orders
               .Select(o => new OrderObject
               {
                   OrderId = o.OrderID,
                   CustomerName = o.Customers.CompanyName,
                   EmployeeName = o.Employees.LastName,
                   OrderDate = o.OrderDate.Value
               })
               .Where(o => o.OrderId == this.OrderId));

            OrderDetails = new ObservableCollection<OrderDetailObject>
                (orderDetails.
                Select(o => new OrderDetailObject
                {
                    OrderId = o.OrderID,
                    ProductName = o.Products.ProductName,
                    UnitPrice = o.UnitPrice,
                    Quantity = o.Quantity,
                    Discount = o.Discount
                })
                .Where(o => o.OrderId == this.OrderId));

            //TotalSum = new ObservableCollection<decimal>
            //(orderDetails.Select(o=>new decimal {o.UnitPrice+o.Quantity+o.Discount}));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class OrderObject
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class OrderDetailObject
    {
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public string ProductName { get; set; }
    }
}
