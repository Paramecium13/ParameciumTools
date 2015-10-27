using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameciumTools
{
	/// <summary>
	/// Contains extension methods for .NET generic collections.
	/// </summary>
    public static class Extensions
    {

		public static List<T> Substitute<T>(this List<T> IEnum, T toReplace, T replacement)
			where T : IEquatable<T>
		{
			List<T> NewIEnum = new List<T>(IEnum.Count());
			foreach (var item in IEnum)
			{
				NewIEnum.Add(item.Equals(toReplace) ? replacement : item);
			}
			return NewIEnum;
		}

	}
}
