using Raven.Imports.Newtonsoft.Json;

namespace AANUG_RavenDB
{
	public class ScheduleItem
	{
		[JsonConstructor]
		internal ScheduleItem(SessionSlot sessionSlot, Session session)
		{
			SessionSlot = sessionSlot;
			Session = session;
		}

		public SessionSlot SessionSlot { get; private set; }

		public Session Session { get; private set; }

		protected bool Equals(ScheduleItem other)
		{
			return Equals(SessionSlot.StartTime, other.SessionSlot.StartTime) && Equals(Session.Id, other.Session.Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != GetType())
				return false;
			return Equals((ScheduleItem) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((SessionSlot != null ? SessionSlot.GetHashCode() : 0)*397) ^ (Session != null ? Session.GetHashCode() : 0);
			}
		}

		public static bool operator ==(ScheduleItem left, ScheduleItem right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ScheduleItem left, ScheduleItem right)
		{
			return !Equals(left, right);
		}
	}
}