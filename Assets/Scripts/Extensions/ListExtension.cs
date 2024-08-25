using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtension
    {
        /**
         * Method to check if the list is null or empty
         */
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }
        
        /**
         * Method to get the last element of the list
         */
        public static T Last<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty())
            {
                throw new InvalidOperationException("The list is empty or null.");
            }

            return list[^1];
        }
    }
}
