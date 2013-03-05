using System;
using System.Collections.Generic;
using System.Linq;
using NLite.Data;
namespace Tests
{
	public partial class Customers 
	{
			
		[Id]public String CustomerId { get;set;}
		
		[Column]
public String Phone { get;set;}
	 
	}

}
