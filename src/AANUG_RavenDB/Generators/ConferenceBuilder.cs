using Raven.Client;

namespace AANUG_RavenDB.Generators
{
	public class ConferenceBuilder
	{
		private readonly IDocumentStore documentStore;

		public ConferenceBuilder(IDocumentStore documentStore)
		{
			this.documentStore = documentStore;
		}

		public void Setup()
		{
			using (var documentSession = documentStore.OpenSession())
			{
				var conference = ConferenceGenerator.Generate();

				var speakersAndSessions = SessionGenerator.Generate();

				foreach (var speakersAndSession in speakersAndSessions)
				{
					var speaker = speakersAndSession.Speaker;

					var sessions = speakersAndSession.Sessions;

					documentSession.Store(speaker);

					documentSession.SaveChanges();

					foreach (var session in sessions)
					{
						session.SpeakerId = speaker.Id;

						documentSession.Store(session);
					}
				}

				documentSession.Store(conference);

				documentSession.SaveChanges();
			}
		}
	}
}