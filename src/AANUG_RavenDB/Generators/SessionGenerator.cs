using System.Collections.Generic;
using System.Linq;

namespace AANUG_RavenDB.Generators
{
	public class SessionGenerator
	{
		public Speaker Speaker { get; private set; }
		public Session[] Sessions { get; private set; }

		public SessionGenerator(Speaker speaker, IEnumerable<Session> sessions)
		{
			Speaker = speaker;
			Sessions = sessions.ToArray();
		}

		public static SessionGenerator[] Generate()
		{
			var data = new List<SpeakerAndSessionData>
			           {
				           new SpeakerAndSessionData("Stefan Daugaard Poulsen", "@cyberzeddk", new[] {"Take-off med Raven DB"}),
				           new SpeakerAndSessionData("Jeppe Cramon", "@jeppec",
					           new[] {"Løskoblet SOA/Event Driven Architecture", "Agile & Domain-Driven Design"}),
				           new SpeakerAndSessionData("Mark Seemann", "@ploeh", new[] {"Ækvivalensklasser med xUnit.net og AutoFixture"}),
				           new SpeakerAndSessionData("Mark S. Rasmussen", "@improvedk", new[] {"SQL Server Advanced Tips & Tricks"}),
				           new SpeakerAndSessionData("Mogens Heller Grabe", "@mookid8000", new[] {"Distribuerede systemer og messaging med Rebus"}),
				           new SpeakerAndSessionData("Henrik Westergaard", "@henrikwh", new[] {"Windows Azure"}),
				           new SpeakerAndSessionData("Jesper Niedermann", "@jniedermann", new[] {"Spiludvikling til iOS med C#"})
			           };

			var conferenceData = data.Select(ssd => {
				                                 var speaker = new Speaker(ssd.Name, ssd.TwitterHandle);

				                                 return new SessionGenerator(
					                                 speaker,
					                                 ssd.Sessions.Select(ses => new Session(ses, speaker))
					                                 );
			                                 });

			return conferenceData.ToArray();
		}

		private class SpeakerAndSessionData
		{
			public SpeakerAndSessionData(string name, string twitterHandle, string[] sessions)
			{
				Name = name;
				TwitterHandle = twitterHandle;
				Sessions = sessions;
			}

			public string Name { get; private set; }
			public string TwitterHandle { get; private set; }
			public string[] Sessions { get; private set; }
		}
	}
}