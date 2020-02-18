using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace PruebaAlgoritmos
{
    class SortTester
    {
        private static void BubbleSort(int[] a)
        {
            for (int i = 1; i <= a.Length - 1; ++i)
                for (int j = 0; j < a.Length - i; ++j)
                    if (a[j] > a[j + 1])
                        Swap(ref a[j], ref a[j + 1]);
        }

        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
        static private double RandomBubbleSort(int arrayLenght)
        {
            Stopwatch stopwatch;
            int i;
            Random random = new Random();
            int[] arr = new int[arrayLenght];
            for (i = 0; i < arrayLenght; i++)
            {
                arr[i] = random.Next(0, 1000);
            }
            stopwatch = Stopwatch.StartNew();
            BubbleSort(arr);
            stopwatch.Stop();
            long ticks = stopwatch.ElapsedTicks;
            double microseconds = ((double)ticks / Stopwatch.Frequency) * 1000000.0;
            microseconds = Math.Round(microseconds, 4);
            return microseconds;
        }
        static private double RandomQuickSort(int arrayLenght)
        {
            Stopwatch stopwatch;
            int i;
            Random random = new Random();
            int[] arr = new int[arrayLenght];
            for (i = 0; i < arrayLenght; i++)
            {
                arr[i] = random.Next(0, 1000);
            }
            stopwatch = Stopwatch.StartNew();
            Quick_Sort(arr,0,arrayLenght-1);
            stopwatch.Stop();
            long ticks = stopwatch.ElapsedTicks;
            double microseconds = ((double)ticks / Stopwatch.Frequency) * 1000000.0;
            microseconds = Math.Round(microseconds, 4);
            return microseconds;
        }

        static public List<Dictionary<int, double>> QuickSortTest(int[] arr) 
        {
            List<Dictionary<int, double>> result = new List<Dictionary<int, double>>();
            Dictionary<int, double> dict = new Dictionary<int, double> ();
            Boolean first_cycle = true;
            int i = 0;
            while (i<arr.Length)
            {
                if (first_cycle)
                {
                    first_cycle = false;
                    double time = RandomQuickSort(arr[i]);
                }
                else
                {
                    double time = RandomQuickSort(arr[i]);
                    dict.Add(arr[i], time);
                    i++;
                }
            }
            result.Add(dict);
            return result;
        }

        static public List<Dictionary<int, double>> BubbleSortTest(int[] arr)
        {
            List<Dictionary<int, double>> result = new List<Dictionary<int, double>>();
            Dictionary<int, double> dict = new Dictionary<int, double>();
            Boolean first_cycle = true;
            int i = 0;
            while (i < arr.Length)
            {
                if (first_cycle)
                {
                    first_cycle = false;
                    double time = RandomBubbleSort(arr[i]);
                }
                else
                {
                    double time = RandomBubbleSort(arr[i]);
                    dict.Add(arr[i], time);
                    i++;
                }
            }
            result.Add(dict);
            return result;
        }

        static void Main(string[] args)
        {
            int[] BSarrayLenghts = { 100, 200, 300, 400, 500, 600 };
            int[] QSarrayLenghts = { 100, 200, 300, 400, 500, 600 };
            List<Dictionary<int, double>> result = QuickSortTest(QSarrayLenghts);
            Dictionary<int, double> tempDict = result[0];
            Console.WriteLine("QuickSort results: ");
            foreach (int i in QSarrayLenghts) 
            {
                Console.WriteLine("With n = " + i.ToString() + ", the execution time is: " + tempDict[i].ToString() + " microseconds");
            }
            result = BubbleSortTest(BSarrayLenghts);
            tempDict = result[0];
            Console.WriteLine("MergeSort results: ");           
            foreach (int i in BSarrayLenghts)
            {
                Console.WriteLine("With n = " + i.ToString() + ", the execution time is: " + tempDict[i].ToString() + " microseconds");
            }
        }
    }
}