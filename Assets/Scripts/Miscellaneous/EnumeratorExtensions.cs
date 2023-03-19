using System;
using System.Collections.Generic;

namespace Miscellaneous
{
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// foreach loop analogue in functional style
        /// </summary>
        /// <param name="enumerable">Your collection</param>
        /// <param name="action">Action which will be invoked with every enumerable element</param>
        /// <typeparam name="T">Collection elements type</typeparam>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var x in enumerable)
                action.Invoke(x);
        }
    }
}