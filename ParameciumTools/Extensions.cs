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
			List<T> result = new List<T>(list.Count());
			foreach (var item in list)
			{
				result.Add(item.Equals(toReplace) ? replacement : item);
			}
			return result;
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
			List<T> result = new List<T>(list.Count());
			foreach (var item in list)
			{
				result.Add(toReplace.Contains(item) ? replacement : item);
			}
			return result;
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
			List<T> result = new List<T>(list.Count());
			foreach (var item in list)
			{
				result.Add(substitutions.ContainsKey(item) ? substitutions[item] : item);
			}
			return result;
		}

		/// <summary>
		/// Whenever pred1 is true for an item and pred2 is true for the next item, those two items are replaced with
		/// the result of the merger when it is given them.
		/// </summary>
		/// <typeparam name="T">The type contained in the list.</typeparam>
		/// <param name="pred1">The predicate for the first match.</param>
		/// <param name="pred2">The predicate for the second match.</param>
		/// <param name="merger">The function that takes in two matching items and returns a new item.</param>
		/// <returns></returns>
		public static List<T> Substitute<T>(this List<T> list, Predicate<T> pred1, Predicate<T> pred2, Func<T,T,T> merger)
		{
			int count = list.Count;
			List<T> result = new List<T>(count);
			// Set the max index at 2 less than the number of elements in list so it doesn't exceed the bounds when
			// checking the (i+1)th element
			int i = 0;
			while (i < count -1)
			{
				if(pred1(list[i]) && pred2(list[i+1]))
				{
					result.Add(merger(list[i], list[i + 1]));
					i += 2;
				}
				else
				{
					result.Add(list[i]);
					i++;
				}
			}
			return result;
		}

	}
}
