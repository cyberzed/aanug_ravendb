using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace AANUG_RavenDB.Indexes
{
	public class SpeakerNameIndex : AbstractIndexCreationTask<Speaker>
	{
		public SpeakerNameIndex()
		{
			Map = docs => from d in docs
			              select new {d.Name};

			Index(s => s.Name, FieldIndexing.Analyzed);
		}
	}
}