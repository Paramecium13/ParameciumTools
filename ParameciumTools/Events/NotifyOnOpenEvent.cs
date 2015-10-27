using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameciumTools.Events
{
	public class NotifyOnRecieveEvent<T1,T2> : EventArgs
		where T1 : EventArgs
	{
		protected T1 InnerEvent { get; set; }
		protected SimpleEventHandler<T2> Response { get; set; }

		public NotifyOnRecieveEvent(T1 innerEvent, SimpleEventHandler<T2> resp)
		{
			InnerEvent = innerEvent;
			Response = resp;
		}

		public T1 Open(T2 reciever)
		{
			Response(reciever, EventArgs.Empty);
			return InnerEvent;
		}
	}
}
