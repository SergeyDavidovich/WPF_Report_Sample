using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Report_Sample
{
    public class ViewModel
    {
        NorthwindContext context;
        public ViewModel()
        {
            context = new NorthwindContext();
            var orders = context.Orders.ToList();
            var orderDetails = context.Order_Details.ToList();

            Orders = new ObservableCollection<OrderObject>(orders
                .Select(o => new OrderObject
                {
                    OrderId = o.OrderID,
                    CustomerName = o.Customers.CompanyName,
                    EmployeeName = o.Employees.LastName,
                    OrderDate = o.OrderDate.Value
                }));

            OrderDetails = new ObservableCollection<OrderDetailObject>
                (orderDetails.Select(o => new OrderDetailObject
                {
                    OrderId = o.OrderID,
                    ProductName = o.Products.ProductName,
                    UnitPrice = o.UnitPrice,
                    Quantity = o.Quantity,
                    Discount = o.Discount
                }

                ));
        }

        public ObservableCollection<OrderObject> Orders { get; set; }

        public ObservableCollection<OrderDetailObject> OrderDetails { get; set; }
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
