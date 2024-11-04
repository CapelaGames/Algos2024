using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuickSort
{

    public static void Sort(int[] numbers, int left, int right)
    {
        if (left >= right) return; //exit if we have 1 number left

        int pivot = Partition(numbers, left, right);
        
        Sort(numbers, left, pivot -1);
        Sort(numbers, pivot +1, right);
    }

    private static int Partition(int[] numbers, int left, int right)
    {
        int i = left;
        int j = right;
        while (i < j)
        {
            while (i < j && numbers[j] >= numbers[left])
            {
                j--;
            }

            while (i < j && numbers[i] <= numbers[left])
            {
                i++;
            }
            Swap(numbers, i, j);
        }
        Swap(numbers, i , left);

        return i;
    }
    static void Swap(int[] numbers, int i, int j)
    {
        int temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }
}
