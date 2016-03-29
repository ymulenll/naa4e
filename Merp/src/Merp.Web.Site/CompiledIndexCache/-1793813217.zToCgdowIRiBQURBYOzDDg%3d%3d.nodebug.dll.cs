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

public class Index_DomainEvents_Stream : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_DomainEvents_Stream()
	{
		this.ViewText = @"from evt in docs
						let mtd = evt[""@metadata""]
                        where mtd[""Memento-DomainEvent""] != null
						select new
						{
							Tag = mtd[""Raven-Entity-Name""],
							_ = evt.Select( k => this.CreateField( k.Key, k.Value, true, true ) ),
							Id = evt.__document_id,
							TimelineId = evt.TimelineId,
							TimeStamp = evt.TimeStamp
						}";
		this.AddMapDefinition(docs => 
			from evt in ((IEnumerable<dynamic>)docs)
			let mtd = evt["@metadata"]
			where mtd["Memento-DomainEvent"] != null
			select new {
				Tag = mtd["Raven-Entity-Name"],
				_ = evt.Select((Func<dynamic, dynamic>)(k => this.CreateField(k.Key, k.Value, true, true))),
				Id = evt.__document_id,
				TimelineId = evt.TimelineId,
				TimeStamp = evt.TimeStamp,
				__document_id = evt.__document_id
			});
		this.AddField("Tag");
		this.AddField("_");
		this.AddField("Id");
		this.AddField("TimelineId");
		this.AddField("TimeStamp");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("TimelineId");
		this.AddQueryParameterForMap("TimeStamp");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("TimelineId");
		this.AddQueryParameterForReduce("TimeStamp");
	}
}
