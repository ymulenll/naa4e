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

public class Index_Auto_OutgoingInvoiceLinkedToJobOrderEvents_ByJobOrderIdAndTimeStamp : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_OutgoingInvoiceLinkedToJobOrderEvents_ByJobOrderIdAndTimeStamp()
	{
		this.ViewText = @"from doc in docs.OutgoingInvoiceLinkedToJobOrderEvents
select new {
	JobOrderId = doc.JobOrderId,
	TimeStamp = doc.TimeStamp
}";
		this.ForEntityNames.Add("OutgoingInvoiceLinkedToJobOrderEvents");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "OutgoingInvoiceLinkedToJobOrderEvents", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				JobOrderId = doc.JobOrderId,
				TimeStamp = doc.TimeStamp,
				__document_id = doc.__document_id
			});
		this.AddField("JobOrderId");
		this.AddField("TimeStamp");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("JobOrderId");
		this.AddQueryParameterForMap("TimeStamp");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("JobOrderId");
		this.AddQueryParameterForReduce("TimeStamp");
		this.AddQueryParameterForReduce("__document_id");
	}
}
