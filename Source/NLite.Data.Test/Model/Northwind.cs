using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLite.Data.Test.Model.Northwind
{
    [Table(Name = "Customers")]
    public class Customer
    {
        //[Id(Name="CustomerId")]
        public string CustomerID;
        //[Column]
        public string ContactName;
        //[Column]
        public string CompanyName;
        [Column]
        //[Ignore]
        public string Phone;
        //[Column]
        public string City;
        //[Column]
        public string Country;
       // [Association(ThisKey="CustomerID", OtherKey="CustomerID")]
        public ICollection<Order> Orders;
    }

    //[Table(Name = "Orders")]
    public class Order
    {
        //[Id(IsDbGenerated = true)]
        public int OrderID;
        //[Column]
        public string CustomerID;
        //[Column]
        public DateTime OrderDate;
       //[ManyToOne(ThisKey = "CustomerId", OtherKey = "CustomerID")]
        public Customer Customer;
        //[Association]
        public IEnumerable<OrderDetail> Details;
    }

    //[Table(Name = "Order Details")]
    public class OrderDetail
    {
        //[Id]
        public int? OrderID { get; set; }
        //[Id]
        public int ProductID { get; set; }
        //[Association]
        public Product Product;
    }


   // [Table(Name = "Products")]
    public class Product
    {
        //[Id]
        public int ID;
        //[Column]
        public string ProductName;
        //[Column]
        public bool Discontinued;

    }
    public class Northwind:DbContext
    {
        //连接字符串名称：基于Config文件中连接字符串的配置
        const string connectionStringName = "Northwind";
        //构造dbConfiguration 对象
        static DbConfiguration dbConfiguration;

        static Northwind()
        {
            if (!DbConfiguration.Items.TryGetValue(connectionStringName, out dbConfiguration))
            {
                dbConfiguration = DbConfiguration
                  .Configure(connectionStringName)
                    // .SetSqlLogger(() =>SqlLog.Trace)
                  .SetMappingConversion(MappingConversion.Plural)
                  .AddClass<Customer>()//注册映射类
                  .AddClass<Order>()//注册映射类
                  .AddClass<OrderDetail>(p =>
                  {
                      p.TableName("Order Details");
                  })//注册映射类
                  .AddClass<Product>()//注册映射类
                    // .AddFile("Model\\Northwind.mapping.xml")
                  ;

            }
        }

      
        public Northwind()
            : base(dbConfiguration)
        {
        }
        public readonly IDbSet<Customer> Customers;
        public readonly IDbSet<Order> Orders;
        public readonly IDbSet<OrderDetail> OrderDetails;
        public readonly IDbSet<Product> Products;
    }
}
