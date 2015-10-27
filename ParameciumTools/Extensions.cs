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

		/// <summary>
		/// Substitutes all instances of one element with another element.
		/// </summary>
		/// <typeparam name="T">The type of the list, must implement IEquatable T .</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="toReplace">The element to replace.</param>
		/// <param name="replacement">The element to replace with.</param>
		/// <returns></returns>
		public static List<T> Substitute<T>(this List<T> list, T toReplace, T replacement)
			where T : IEquatable<T>
		{
			List<T> NewIEnum = new List<T>(list.Count());
			foreach (var item in list)
			{
				NewIEnum.Add(item.Equals(toReplace) ? replacement : item);
			}
			return NewIEnum;
		}

		/// <summary>
		/// Substitutes all items in 'toReplace' with 'replacement'.
		/// </summary>
		/// <typeparam name="T">The type of the list's elements.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="toReplace">A collection of the elements to replace.</param>
		/// <param name="replacement">The element to replace with.</param>
		/// <returns></returns>
		public static List<T> Substitute<T>(this List<T> list, IEnumerable<T> toReplace, T replacement)
		{
			List<T> NewIEnum = new List<T>(list.Count());
			foreach (var item in list)
			{
				NewIEnum.Add(toReplace.Contains(item) ? replacement : item);
			}
			return NewIEnum;
		}

		/// <summary>
		/// Replaces all instances of the keys in the provided list with their associated values.
		/// </summary>
		/// <typeparam name="T">The type of the list's elements.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="substitutions">The dictionary of substitutions.</param>
		/// <returns></returns>
		public static List<T> Substitute<T>(this List<T> list, Dictionary<T,T> substitutions)
		{
			List<T> NewIEnum = new List<T>(list.Count());
			foreach (var item in list)
			{
				NewIEnum.Add(substitutions.ContainsKey(item) ? substitutions[item] : item);
			}
			return NewIEnum;
		}

	}
}
