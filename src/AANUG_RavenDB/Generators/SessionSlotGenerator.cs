using System;
using System.Linq;

namespace AANUG_RavenDB.Generators
{
	public static class SessionSlotGenerator
	{
		private static readonly DateTime[] sessionTimes =
		{
			new DateTime(2013, 9, 28, 9, 30, 0),
			new DateTime(2013, 9, 28, 11, 30, 0),
			new DateTime(2013, 9, 28, 14, 0, 0),
			new DateTime(2013, 9, 28, 16, 0, 0)
		};

		public static SessionSlot[] GenerateSessionSlots()
		{
			return sessionTimes.Select(st => new SessionSlot(st)).ToArray();
		}
	}
}