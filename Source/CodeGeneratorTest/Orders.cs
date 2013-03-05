using System;
using System.Collections.Generic;
using System.Linq;
using NLite.Data;
namespace Tests
{
	public partial class Orders 
	{
			
		[Id]public Int32 OrderId { get;set;}
		
		[Column]
public String CustomerId { get;set;}
	 
	}

}
