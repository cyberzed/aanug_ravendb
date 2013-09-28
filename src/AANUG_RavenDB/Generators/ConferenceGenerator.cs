namespace AANUG_RavenDB.Generators
{
	public static class ConferenceGenerator
	{
		public static Conference Generate()
		{
			var sessionSlots = SessionSlotGenerator.GenerateSessionSlots();

			return new Conference("Aalborg .NET User Group Developer Conference 2013", sessionSlots);
		}
	}
}