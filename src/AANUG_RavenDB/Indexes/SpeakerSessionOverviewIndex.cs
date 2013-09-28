using System.Linq;
using Raven.Client.Indexes;

namespace AANUG_RavenDB.Indexes
{
	public class SpeakerSessionOverviewIndex : AbstractIndexCreationTask<Session, SpeakerSessionOverview>
	{
		public SpeakerSessionOverviewIndex()
		{
			Map = docs => from d in docs
			              select new
			                     {
				                     d.SpeakerId,
				                     Count = 1,
			                     };

			Reduce = results => from r in results
			                    group r by r.SpeakerId
			                    into grpSpeakers
			                    select new
			                           {
				                           SpeakerId = grpSpeakers.Key,
				                           Count = grpSpeakers.Sum(sso => sso.Count)
			                           };
		}
	}
}