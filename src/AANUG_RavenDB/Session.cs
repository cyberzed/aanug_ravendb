namespace AANUG_RavenDB
{
	public class Session
	{
		private Session()
		{}

		public Session(string title, Speaker speaker)
		{
			Title = title;
			SpeakerId = speaker.Id;
		}

		public string Id { get; private set; }

		public string Title { get; private set; }

		public string SpeakerId { get; set; }
	}
}