using System.Linq;
using Raven.Client.Indexes;

namespace AANUG_RavenDB.Indexes
{
	public class SpeakerSessionOverview2Index : AbstractIndexCreationTask<Session, SpeakerSessionOverview>
	{
		public SpeakerSessionOverview2Index()
		{
			Map = docs => from d in docs
			              select new
			                     {
				                     d.SpeakerId,
				                     SpeakerName = string.Empty,
				                     Count = 1,
			                     };

			Reduce = results => from r in results
			                    group r by r.SpeakerId
			                    into grpSpeakers
			                    select new
			                           {
				                           SpeakerId = grpSpeakers.Key,
				                           SpeakerName = string.Empty,
				                           Count = grpSpeakers.Sum(sso => sso.Count)
			                           };
		}
	}
}