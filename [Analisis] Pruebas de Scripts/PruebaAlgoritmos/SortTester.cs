using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace PruebaAlgoritmos
{
    class SortTester
    {
        private static void BubbleSort(int[] arr)
        {
            for (int i = 1; i <= arr.Length - 1; ++i)
                for (int j = 0; j < arr.Length - i; ++j)
                    if (arr[j] > arr[j + 1])
                        Swap(ref arr[j], ref arr[j + 1]);
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

        static private double RandomSort(int arrayLenght, Boolean sortingMethod)
        {
            Stopwatch stopwatch;
            int i;
            Random random = new Random();
            int[] arr = new int[arrayLenght];
            long ticks;
            for (i = 0; i < arrayLenght; i++)
            {
                arr[i] = random.Next(0, 10000);
            }
            if (sortingMethod)
            {
                stopwatch = Stopwatch.StartNew();
                BubbleSort(arr);
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
            }
            else
            {
                stopwatch = Stopwatch.StartNew();
                Quick_Sort(arr, 0, arrayLenght - 1);
                stopwatch.Stop();
                ticks = stopwatch.ElapsedTicks;
            }
            double microseconds = ((double)ticks / Stopwatch.Frequency) * 1000000.0;
            microseconds = Math.Round(microseconds, 2);
            return microseconds;
        }

        static public Dictionary<int, List<double>> SortTest(int[] arr, Boolean sortingMethod) 
        {
            Dictionary<int, List<double>> dict = new Dictionary<int, List<double>>();
            Boolean first_cycle = true;
            int i = 0;
            while (i<arr.Length)
            {
                List<double> timeValues = new List<double>();
                if (first_cycle)
                {
                    first_cycle = false;
                    double time = RandomSort(arr[i], sortingMethod);
                }
                else
                {
                    for (int cont = 0; cont<5; cont++)
                    {
                        double time = RandomSort(arr[i], sortingMethod);
                        timeValues.Add(time);
                    }
                    dict.Add(arr[i], timeValues);
                    i++;
                }
            }
            return dict;
        }

        static void Main(string[] args)
        {
            int[] BSarrayLenghts = { 100, 200, 300, 400, 500, 600 };
            int[] QSarrayLenghts = { 100, 200, 300, 400, 500, 600 };
            Dictionary<int, List<double>> results = SortTest(QSarrayLenghts, false);
            Console.WriteLine("QuickSort results: ");
            foreach (int i in QSarrayLenghts) 
            {
                Console.Write("With n = " + i.ToString() + ", the execution times were: ");
                foreach (double time in results[i]) 
                {
                    Console.Write(time.ToString() + " ");
                }
                Console.Write("microseconds");
                Console.WriteLine("");
            }
            Console.WriteLine("");
            results = SortTest(BSarrayLenghts, true);
            Console.WriteLine("BubbleSort results: ");
            foreach (int i in BSarrayLenghts)
            {
                Console.Write("With n = " + i.ToString() + ", the execution times were: ");
                foreach (double time in results[i])
                {
                    Console.Write(time.ToString() + " ");
                }
                Console.Write("microseconds");
                Console.WriteLine("");
            }

        }
    }
}