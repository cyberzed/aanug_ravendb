using System;

namespace AANUG_RavenDB
{
	public class SessionSlot
	{
		private static readonly TimeSpan SessionLength = TimeSpan.FromMinutes(90);

		public DateTime StartTime { get; private set; }

		public DateTime EndTime
		{
			get { return StartTime.Add(SessionLength); }
		}

		public SessionSlot(DateTime startTime)
		{
			StartTime = startTime;
		}

		protected bool Equals(SessionSlot other)
		{
			return StartTime.Equals(other.StartTime);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != GetType())
				return false;
			return Equals((SessionSlot) obj);
		}

		public override int GetHashCode()
		{
			return StartTime.GetHashCode();
		}

		public static bool operator ==(SessionSlot left, SessionSlot right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(SessionSlot left, SessionSlot right)
		{
			return !Equals(left, right);
		}
	}
}