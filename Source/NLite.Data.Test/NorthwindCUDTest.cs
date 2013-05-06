using System;
using System.Linq;
using NLite.Data.Test.Model.Northwind;
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace NLite.Data.Test
{
	[TestClass]
	public class NorthwindCUDTest : TestBase
	{
		private Northwind db;

		protected virtual string ConnectionStringName
		{
			get { return "Northwind"; }
		}

		[TestInitialize]
		public void Initialize()
		{
			db = new Northwind();
			db.Orders.Delete(p => p.CustomerID.StartsWith("XX"));
			db.Customers.Delete(p => p.CustomerID.StartsWith("XX"));
		}

		[TearDown]
		public void TearDown()
		{
			db.Orders.Delete(p => p.CustomerID.StartsWith("XX"));
			db.Customers.Delete(p => p.CustomerID.StartsWith("XX"));
			db.Dispose();
		}


		[TestMethod]
		public void TestInsertCustomerNoResult()
		{
			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Seattle",
				Country = "USA"
			};
			var result = db.Customers.Insert(cust);
			AssertValue(1, result);
		}


		[TestMethod]
		public void TestInsertCustomerWithResult()
		{
			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Seattle",
				Country = "USA"
			};
			var result = db.Customers.Insert(cust, c => c.City);
			AssertValue(result, "Seattle");
		}

		[TestMethod]
		public void TestBatchInsertCustomersNoResult()
		{
			int n = 10;
			var custs = Enumerable.Range(1, n).Select(
				i => new
				{
					CustomerID = "XX" + i,
					CompanyName = "Company" + i,
					ContactName = "Contact" + i,
					City = "Seattle",
					Country = "USA"
				});
			var results = db.Customers.Batch(custs, (u, c) => u.Insert(c));
			AssertValue(n, results.Count());
			AssertTrue(results.All(r => object.Equals(r, 1)));
		}




		[TestMethod]
		public void TestInsertOrderWithNoResult()
		{
			this.TestInsertCustomerNoResult();
			var order = new Order
			{
				CustomerID = "XX1",
				OrderDate = DateTime.Today,
			};
			var result = db.Orders.Insert(order);
			Assert.AreNotEqual(0, order.OrderID);
			Assert.AreEqual(1, result);
		}


		[TestMethod]
		public void TestUpdateCustomerNoResult()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Portland",
				Country = "USA"
			};

			var result = db.Customers.Update(cust);
			AssertValue(1, result);
		}

		[TestMethod]
		public void TestUpdateCustomerWithResult()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Portland",
				Country = "USA"
			};

			var result = db.Customers.Update(cust, null, c => c.City);
			AssertValue("Portland", result);
		}



		[TestMethod]
		public void TestUpdateCustomerWithUpdateCheckThatDoesNotSucceed()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				//CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Portland",
				Country = "USA"
			};

			var result = db.Customers.Update(cust, d => d.City == "111");
			AssertValue(0, result); // 0 for failure
		}

		[TestMethod]
		public void TestUpdateCustomerWithUpdateCheckThatSucceeds()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Portland",
				Country = "USA"
			};

			var result = db.Customers.Update(cust/*, d => d.City == "Seattle"*/);
			AssertValue(1, result);
		}

		[TestMethod]
		public void TestBatchUpdateCustomer()
		{
			this.TestBatchInsertCustomersNoResult();

			int n = 10;
			var custs = Enumerable.Range(1, n).Select(
				i => new
				{
					CustomerID = "XX" + i,
					CompanyName = "Company" + i,
					ContactName = "Contact" + i,
					City = "Seattle",
					Country = "USA"
				});



			var results = db.Customers.Batch(custs, (u, c) => u.Update(c));
			AssertValue(n, results.Count());
			AssertTrue(results.All(r => object.Equals(r, 1)));

			var ids = custs.Select(p => p.CustomerID).ToList();

			db.Customers.Update(new { Country = "ZH-CN" }, p => ids.Contains(p.CustomerID));


		}


		[TestMethod]
		public void TestBatchUpdateCustomerWithUpdateCheck()
		{
			this.TestBatchInsertCustomersNoResult();

			int n = 10;
			var pairs = Enumerable.Range(1, n).Select(
				i => new
				{
					original = new
					{
						CustomerID = "XX" + i,
						CompanyName = "Company" + i,
						ContactName = "Contact" + i,
						City = "Seattle",
						Country = "USA"
					},
					current = new
					{
						CustomerID = "XX" + i,
						CompanyName = "Company" + i,
						ContactName = "Contact" + i,
						City = "Portland",
						Country = "USA"
					}
				});



			var results = db.Customers.Batch(pairs, (u, x) => u.Update(x.current, d => d.City == x.original.City));
			AssertValue(n, results.Count());
			AssertTrue(results.All(r => object.Equals(r, 1)));
		}




		[TestMethod]
		public void TestDeleteCustomer()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Seattle",
				Country = "USA"
			};

			var result = db.Customers.Delete(cust);
			AssertValue(1, result);
		}


		[TestMethod]
		public void TestDeleteCustomerForNonExistingCustomer()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX2",
				CompanyName = "Company2",
				ContactName = "Contact2",
				City = "Seattle",
				Country = "USA"
			};

			var result = db.Customers.Delete(cust);
			AssertValue(0, result);
		}

		[TestMethod]
		public void TestDeleteCustomerWithDeleteCheckThatSucceeds()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Seattle",
				Country = "USA"
			};

			var result = db.Customers.Delete(cust, d => d.City == "Seattle");
			AssertValue(1, result);
		}

		[TestMethod]
		public void TestDeleteCustomerWithDeleteCheckThatDoesNotSucceed()
		{
			this.TestInsertCustomerNoResult();

			var cust = new
			{
				CustomerID = "XX1",
				CompanyName = "Company1",
				ContactName = "Contact1",
				City = "Seattle",
				Country = "USA"
			};

			var result = db.Customers.Delete(cust, d => d.City == "Portland");
			AssertValue(0, result);
		}


		[TestMethod]
		public void TestBatchDeleteCustomers()
		{
			db.UsingTransaction(()=>
			                    {
			                    	this.TestBatchInsertCustomersNoResult();

			                    	int n = 10;
			                    	var custs = Enumerable.Range(1, n).Select(
			                    		i => new
			                    		{
			                    			CustomerID = "XX" + i,
			                    			CompanyName = "Company" + i,
			                    			ContactName = "Contact" + i,
			                    			City = "Seattle",
			                    			Country = "USA"
			                    		});

			                    	var results = db.Customers.Batch(custs, (u, c) => u.Delete(c));
			                    	AssertValue(n, results.Count());
			                    	AssertTrue(results.All(r => object.Equals(r, 1)));
			                    });
		}


		[TestMethod]
		public void TestBatchDeleteCustomersWithDeleteCheck()
		{
			this.TestBatchInsertCustomersNoResult();

			int n = 10;
			var custs = Enumerable.Range(1, n).Select(
				i => new
				{
					CustomerID = "XX" + i,
					CompanyName = "Company" + i,
					ContactName = "Contact" + i,
					City = "Seattle",
					Country = "USA"
				});

			var results = db.Customers.Batch(custs, (u, c) => u.Delete(c, d => d.City == c.City));
			AssertValue(n, results.Count());
			AssertTrue(results.All(r => object.Equals(r, 1)));
		}


		[TestMethod]
		public void TestBatchDeleteCustomersWithDeleteCheckThatDoesNotSucceed()
		{
			this.TestBatchInsertCustomersNoResult();

			int n = 10;
			var custs = Enumerable.Range(1, n).Select(
				i => new
				{
					CustomerID = "XX" + i,
					CompanyName = "Company" + i,
					ContactName = "Contact" + i,
					City = "Portland",
					Country = "USA"
				});

			var results = db.Customers.Batch(custs, (u, c) => u.Delete(c, d => d.City == c.City));
			AssertValue(n, results.Count());
			AssertTrue(results.All(r => object.Equals(r, 0)));
		}


		[TestMethod]
		public void TestDeleteWhere()
		{
			this.TestBatchInsertCustomersNoResult();

			var result = db.Customers.Delete(c => c.CustomerID.StartsWith("XX"));
			AssertValue(10, result);
		}




	}
}
