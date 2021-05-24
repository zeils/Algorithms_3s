using System;
using System.Collections.Generic;
using System.IO;

namespace algorithms
{
    static class Task2___antiQuickSort
    {
        private static string inputPath = @"..\..\..\files\task_two\\input.txt";
        private static string outputPath = @"..\..\..\files\task_two\\output.txt";

        public static void Solution()
        {
           
            string[] lines = File.ReadAllLines(inputPath);
            int n = Convert.ToInt16(lines[0]);
            int[] nums = new int[n];
            int counter = 0;

            nums = Generate(n);
            //QuickSort(nums, ref counter);
            //Console.WriteLine(counter);
            string outLine = "";

            for (int i = 0; i < nums.Length; i++)
            {
                outLine = outLine + " " + nums[i];
            }
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(outLine);
            }
        }

        private static int[] Generate(int n)
        {
            int[] nums = new int[n];
            int leftCounter = 0;
            int righCounter = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i%2 != 0) 
                {
                    nums[leftCounter] = i;
                    leftCounter++;
                }
                else 
                {
                    nums[n-righCounter-1] = i;
                    righCounter++;

                }    
            }
            return nums;
        }



        private static void Swap(ref int x, ref int y, ref int counter)
        {
            var t = x;
            x = y;
            y = t;
            counter++;
        }
        private static int Partition(int[] array, int minIndex, int maxIndex, ref int counter) //метод возвращающий индекс опорного элемента
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i], ref counter);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex], ref counter);
            return pivot;
        }
        private static int[] QuickSort(int[] array, int minIndex, int maxIndex, ref int counter)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, ref counter);
            QuickSort(array, minIndex, pivotIndex - 1, ref counter);
            QuickSort(array, pivotIndex + 1, maxIndex, ref counter);

            return array;
        }
        private static int[] QuickSort(int[] array, ref int counter)
        {
            return QuickSort(array, 0, array.Length - 1, ref counter);
        }

    }
}
