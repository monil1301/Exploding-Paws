using System.Collections.Generic;

public static class ListExtension
{
    // Method to check if the list is null or empty
    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list == null || list.Count == 0;
    }
}
