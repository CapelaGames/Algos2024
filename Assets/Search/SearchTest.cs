using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SearchTest : MonoBehaviour
{
    private int[] numbers = new int[500000];
    public int target;

    

    void Start()
    {
        for(int x = 0; x < 500000 ;x++)
        {
            numbers[x] = Random.Range(0, 10000000);
        }

        numbers[0] = target;
        QuickSort.Sort(numbers,0,numbers.Length-1);

        /*for (int x = 0; x < 50; x++)
        {
            Debug.Log(numbers[x]);
        }*/
        
        
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int x = 0; x < 1000000; x++)
        {
            BinarySearch.Search(numbers, target);
        }
        Debug.Log(BinarySearch.Search(numbers, target));
        stopWatch.Stop();
        Debug.Log(stopWatch.ElapsedMilliseconds);
    }
}

