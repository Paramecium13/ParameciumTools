using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameciumTools.Events
{

	/// <summary>
	/// Routes events to subscribing delegates based on the predicate they provided
	/// </summary>
	/// <typeparam name="T">The type of the events to be routed</typeparam>
	public class EventRouter<T>
		where T : EventArgs
	{
		protected List<Tuple<Predicate<T>, Delegate>> Subscribers { get; set; } = new List<Tuple<Predicate<T>, Delegate>>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="del">The delegate that handles accepted events</param>
		/// <param name="filter">If it returns true for the event, the event and its sender are sent to the delegate</param>
		public void Subscribe(Delegate del, Predicate<T> filter)
		{
			if(! Subscribers.Any(s => s.Item1 == filter && s.Item2 == del))
				Subscribers.Add(new Tuple<Predicate<T>, Delegate>(filter, del));
		}

		public void Publish(object sender, T e)
		{
			foreach(Delegate del in Subscribers.Where(s => s.Item1(e)).Select(s=> s.Item2))
			{
				del.DynamicInvoke(sender, e);
			}
		}

		public void Unsubscribe(object sub)
		{
			Subscribers.RemoveAll(s => s.Item2.Target == sub);
		}

	}
}
