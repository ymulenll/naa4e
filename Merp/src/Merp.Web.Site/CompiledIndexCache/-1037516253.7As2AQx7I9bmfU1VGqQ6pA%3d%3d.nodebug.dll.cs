using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;

public class Index_All_JobOrders : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_All_JobOrders()
	{
		this.ViewText = @"from jo in docs.FixedPriceJobOrders
select new {
	Id = jo.__document_id,
	Customer = jo.Customer,
	Manager = jo.Manager,
	Name = jo.Name,
	Number = jo.Number,
	DateOfStart = jo.DateOfStart,
	DateOfCompletion = jo.DateOfCompletion,
	IsCompleted = jo.IsCompleted,
	PurchaseOrderNumber = jo.PurchaseOrderNumber,
	Description = jo.Description
}
from jo in docs.TimeAndMaterialJobOrders
select new {
	Id = jo.__document_id,
	Customer = jo.Customer,
	Manager = jo.Manager,
	Name = jo.Name,
	Number = jo.Number,
	DateOfStart = jo.DateOfStart,
	DateOfCompletion = jo.DateOfCompletion,
	IsCompleted = jo.IsCompleted,
	PurchaseOrderNumber = jo.PurchaseOrderNumber,
	Description = jo.Description
}";
		this.ForEntityNames.Add("FixedPriceJobOrders");
		this.AddMapDefinition(docs => 
			from jo in ((IEnumerable<dynamic>)docs)
			where string.Equals(jo["@metadata"]["Raven-Entity-Name"], "FixedPriceJobOrders", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Id = jo.__document_id,
				Customer = jo.Customer,
				Manager = jo.Manager,
				Name = jo.Name,
				Number = jo.Number,
				DateOfStart = jo.DateOfStart,
				DateOfCompletion = jo.DateOfCompletion,
				IsCompleted = jo.IsCompleted,
				PurchaseOrderNumber = jo.PurchaseOrderNumber,
				Description = jo.Description,
				__document_id = jo.__document_id
			});
		this.ForEntityNames.Add("TimeAndMaterialJobOrders");
		this.AddMapDefinition(docs => 
			from jo in ((IEnumerable<dynamic>)docs)
			where string.Equals(jo["@metadata"]["Raven-Entity-Name"], "TimeAndMaterialJobOrders", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Id = jo.__document_id,
				Customer = jo.Customer,
				Manager = jo.Manager,
				Name = jo.Name,
				Number = jo.Number,
				DateOfStart = jo.DateOfStart,
				DateOfCompletion = jo.DateOfCompletion,
				IsCompleted = jo.IsCompleted,
				PurchaseOrderNumber = jo.PurchaseOrderNumber,
				Description = jo.Description,
				__document_id = jo.__document_id
			});
		this.AddField("Id");
		this.AddField("Customer");
		this.AddField("Manager");
		this.AddField("Name");
		this.AddField("Number");
		this.AddField("DateOfStart");
		this.AddField("DateOfCompletion");
		this.AddField("IsCompleted");
		this.AddField("PurchaseOrderNumber");
		this.AddField("Description");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("Customer");
		this.AddQueryParameterForMap("Manager");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForMap("Number");
		this.AddQueryParameterForMap("DateOfStart");
		this.AddQueryParameterForMap("DateOfCompletion");
		this.AddQueryParameterForMap("IsCompleted");
		this.AddQueryParameterForMap("PurchaseOrderNumber");
		this.AddQueryParameterForMap("Description");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("Customer");
		this.AddQueryParameterForReduce("Manager");
		this.AddQueryParameterForReduce("Name");
		this.AddQueryParameterForReduce("Number");
		this.AddQueryParameterForReduce("DateOfStart");
		this.AddQueryParameterForReduce("DateOfCompletion");
		this.AddQueryParameterForReduce("IsCompleted");
		this.AddQueryParameterForReduce("PurchaseOrderNumber");
		this.AddQueryParameterForReduce("Description");
	}
}
