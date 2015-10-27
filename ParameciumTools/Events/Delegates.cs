using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameciumTools.Events
{

	/// <summary>
	/// Handles events with no data where the reciever needs to know the sender's interface/type
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void SimpleEventHandler<T>(T sender, EventArgs e);

	/// <summary>
	/// Handles events where the reciever needs to know the sender's and the event's interfaces.
	/// </summary>
	/// <typeparam name="T1">The type of the sender</typeparam>
	/// <typeparam name="T2">The type of the response event</typeparam>
	/// <param name="sender">The sender</param>
	/// <param name="e">The response event</param>
	public delegate void GenericHandler<T1, T2>(T1 sender, T2 e) where T2 : EventArgs;

}
