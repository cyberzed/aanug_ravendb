﻿using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Imports.Newtonsoft.Json;

namespace AANUG_RavenDB
{
	public class Conference
	{
		public string Id { get; private set; }
		public string ConferenceName { get; private set; }

		public SessionSlot[] SessionSlots { get; private set; }

		public List<ScheduleItem> Schedule { get; private set; }

		[JsonIgnore]
		public Session[] Sessions
		{
			get
			{
				return (from si in Schedule
				        select si.Session).ToArray();
			}
		}

		public Conference(string conferenceName, SessionSlot[] sessionSlots)
		{
			ConferenceName = conferenceName;
			SessionSlots = sessionSlots;

			Schedule = new List<ScheduleItem>();
		}

		public void AddSession(SessionSlot sessionSlot, Session session)
		{
			if (sessionSlot == null)
				throw new ArgumentNullException("sessionSlot");
			if (session == null)
				throw new ArgumentNullException("session");

			if (!SessionSlots.Contains(sessionSlot))
				throw new ArgumentOutOfRangeException("sessionSlot");

			if (!Schedule.Any(si => si.SessionSlot == sessionSlot && si.Session == session))
				Schedule.Add(new ScheduleItem(sessionSlot, session));
		}
	}

	public class ScheduleItem
	{
		public ScheduleItem(SessionSlot sessionSlot, Session session)
		{
			SessionSlot = sessionSlot;
			Session = session;
		}

		public SessionSlot SessionSlot { get; private set; }

		public Session Session { get; private set; }
	}
}