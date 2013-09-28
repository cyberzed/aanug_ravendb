using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Raven.Imports.Newtonsoft.Json;

namespace AANUG_RavenDB
{
	public class Conference
	{
		private readonly Dictionary<SessionSlot, List<Session>> schedule = new Dictionary<SessionSlot, List<Session>>();

		public string Id { get; private set; }
		public string ConferenceName { get; private set; }
		public SessionSlot[] SessionSlots { get; private set; }

		[JsonIgnore]
		public IReadOnlyDictionary<SessionSlot, List<Session>> Plan
		{
			get { return new ReadOnlyDictionary<SessionSlot, List<Session>>(schedule); }
		}

		public Session[] Sessions
		{
			get
			{
				return (from sl in schedule.Values
				        from s in sl
				        select s).ToArray();
			}
		}

		public Conference(string conferenceName, SessionSlot[] sessionSlots)
		{
			ConferenceName = conferenceName;
			SessionSlots = sessionSlots;
		}

		public void AddSession(SessionSlot sessionSlot, Session session)
		{
			if (sessionSlot == null)
				throw new ArgumentNullException("sessionSlot");
			if (session == null)
				throw new ArgumentNullException("session");

			if (!SessionSlots.Contains(sessionSlot))
				throw new ArgumentOutOfRangeException("sessionSlot");

			var sessionList = new List<Session>();

			if (!schedule.ContainsKey(sessionSlot))
				schedule[sessionSlot] = sessionList;

			if (!sessionList.Contains(session))
				sessionList.Add(session);
		}
	}
}