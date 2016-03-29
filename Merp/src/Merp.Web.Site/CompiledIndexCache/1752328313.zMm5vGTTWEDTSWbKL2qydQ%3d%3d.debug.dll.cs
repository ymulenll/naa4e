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

public class Index_Auto_TimeAndMaterialJobOrderRegisteredEvents_ByJobOrderId : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_TimeAndMaterialJobOrderRegisteredEvents_ByJobOrderId()
	{
		this.ViewText = @"from doc in docs.TimeAndMaterialJobOrderRegisteredEvents
select new {
	JobOrderId = doc.JobOrderId
}";
		this.ForEntityNames.Add("TimeAndMaterialJobOrderRegisteredEvents");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "TimeAndMaterialJobOrderRegisteredEvents", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				JobOrderId = doc.JobOrderId,
				__document_id = doc.__document_id
			});
		this.AddField("JobOrderId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("JobOrderId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("JobOrderId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
