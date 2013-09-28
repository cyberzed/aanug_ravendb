using System.Linq;
using Raven.Client.Indexes;

namespace AANUG_RavenDB.Indexes
{
	public class SpeakerSessionOverview2Transformer : AbstractTransformerCreationTask<SpeakerSessionOverview>
	{
		public SpeakerSessionOverview2Transformer()
		{
			TransformResults = results => (from r in results
			                               select new
			                                      {
				                                      r.SpeakerId,
				                                      SpeakerName = LoadDocument<Speaker>(r.SpeakerId).Name,
				                                      r.Count
			                                      }
				);
		}
	}
}