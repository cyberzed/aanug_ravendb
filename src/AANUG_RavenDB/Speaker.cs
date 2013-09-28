namespace AANUG_RavenDB
{
	public class Speaker
	{
		public Speaker(string name, string twitterHandle)
		{
			Name = name;
			TwitterHandle = twitterHandle;
		}

		public string Id { get; private set; }

		public string Name { get; private set; }

		public string TwitterHandle { get; private set; }
	}
}