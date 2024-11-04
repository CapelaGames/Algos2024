using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BinarySearch 
{
    /// <summary>
    /// Binary Search
    /// </summary>
    /// <param name="numbers">Search in this list</param>
    /// <param name="target">Search target</param>
    /// <returns>index of target in numbers, -1 means index not found </returns>
    static public int Search(int[] numbers, int target)
    {
        int i = 0;
        int j = numbers.Length - 1;

        while (i <= j)
        {
            int m = i + (j - i) / 2; //Calculate middle point
            if (numbers[m] < target)
            {
                i = m + 1; // move i
            }
            else if(numbers[m] > target)
            {
                j = m - 1; // move j
            }
            else
            {
                return m; // we found the target
            }
        }
        return -1; // we didn't find the target
    }
    
    
}
