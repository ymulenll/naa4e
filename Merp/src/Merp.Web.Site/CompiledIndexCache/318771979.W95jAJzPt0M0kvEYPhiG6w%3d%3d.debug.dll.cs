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

public class Index_Auto_IncomingInvoiceLinkedToJobOrderEvents_ByJoOrderId : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_IncomingInvoiceLinkedToJobOrderEvents_ByJoOrderId()
	{
		this.ViewText = @"from doc in docs.IncomingInvoiceLinkedToJobOrderEvents
select new {
	JoOrderId = doc.JoOrderId
}";
		this.ForEntityNames.Add("IncomingInvoiceLinkedToJobOrderEvents");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "IncomingInvoiceLinkedToJobOrderEvents", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				JoOrderId = doc.JoOrderId,
				__document_id = doc.__document_id
			});
		this.AddField("JoOrderId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("JoOrderId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("JoOrderId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
