using System;
class Bubble
{
    public static void Sort(int[] arr)
    {
        int a = arr.Length;
        for(int i=0; i<a; i++)
        {
            for(int j=0; j<a-1-i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
        for(int i=0; i<a; i++)
        {
            Console.Write(arr[i]+" ");
        }
    }
}