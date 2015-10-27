using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameciumTools.Events
{

	/// <summary>
	/// Allows recievers to respond to it without knowing anything about the sender's interface.
	/// </summary>
	/// <typeparam name="T1">The type of the inner event</typeparam>
	/// <typeparam name="T2">The type of the response event</typeparam>
	/// <typeparam name="T3">The type of the recieving object</typeparam>
	public class RespondableEvent<T1,T2,T3> : EventArgs
		where T1 : EventArgs
		where T2 : EventArgs
	{
		public T1 InnerEvent { get; protected set; }
		protected GenericHandler<T3, T2> _ResponseHandler;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="innerEvent">The inner event</param>
		/// <param name="responseHandler">The method in the sending object that will handle the response</param>
		public RespondableEvent(T1 innerEvent, GenericHandler<T3,T2> responseHandler)
		{
			InnerEvent = innerEvent;
			_ResponseHandler = responseHandler;
		}

		/// <summary>
		/// Responds to the sender of this event
		/// </summary>
		/// <param name="sender">The object responding</param>
		/// <param name="e">The response event</param>
		public void Respond(T3 sender,T2 e)
		{
			if (_ResponseHandler != null)
				_ResponseHandler(sender, e);
		}

	}
}
