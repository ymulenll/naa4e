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

public class Index_Auto_IncomingInvoiceLinkedToJobOrderEvents_ByJobOrderIdAndJoOrderId : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_IncomingInvoiceLinkedToJobOrderEvents_ByJobOrderIdAndJoOrderId()
	{
		this.ViewText = @"from doc in docs.IncomingInvoiceLinkedToJobOrderEvents
select new {
	JobOrderId = doc.JobOrderId,
	JoOrderId = doc.JoOrderId
}";
		this.ForEntityNames.Add("IncomingInvoiceLinkedToJobOrderEvents");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "IncomingInvoiceLinkedToJobOrderEvents", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				JobOrderId = doc.JobOrderId,
				JoOrderId = doc.JoOrderId,
				__document_id = doc.__document_id
			});
		this.AddField("JobOrderId");
		this.AddField("JoOrderId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("JobOrderId");
		this.AddQueryParameterForMap("JoOrderId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("JobOrderId");
		this.AddQueryParameterForReduce("JoOrderId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
