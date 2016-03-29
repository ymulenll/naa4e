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

public class Index_Raven_DocumentsByEntityName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Raven_DocumentsByEntityName()
	{
		this.ViewText = @"from doc in docs 
select new 
{ 
	Tag = doc[""@metadata""][""Raven-Entity-Name""], 
	LastModified = (DateTime)doc[""@metadata""][""Last-Modified""],
	LastModifiedTicks = ((DateTime)doc[""@metadata""][""Last-Modified""]).Ticks 
};";
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			select new {
				Tag = doc["@metadata"]["Raven-Entity-Name"],
				LastModified = (DateTime)doc["@metadata"]["Last-Modified"],
				LastModifiedTicks = ((DateTime)doc["@metadata"]["Last-Modified"]).Ticks,
				__document_id = doc.__document_id
			});
		this.AddField("Tag");
		this.AddField("LastModified");
		this.AddField("LastModifiedTicks");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Ticks");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Ticks");
		this.AddQueryParameterForReduce("__document_id");
	}
}
