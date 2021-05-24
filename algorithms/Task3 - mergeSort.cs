using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace algorithms
{
    static class Task3___mergeSort
    {
        private static string inputPath = @"..\..\..\files\task_three\\input.txt";
        private static string outputPath = @"..\..\..\files\task_three\\output.txt";

        private static List<string> outputLines = new List<string>();

        public static void Solution()
        {
            string[] lines = File.ReadAllLines(inputPath);
            int[] nums = Array.ConvertAll(lines[1].Split(new char[] { ' ' }), int.Parse);
            MergeSort(nums);
            Console.WriteLine("gg");

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (string line in outputLines)
                {
                    writer.WriteLine(line);
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    writer.Write(nums[i] + " ");
                }
            }
        }





        static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            string line = leftIndex + " " + rightIndex + " " + array[leftIndex] + " " + array[rightIndex];
            outputLines.Add(line);

            var left = leftIndex;
            var right = middleIndex + 1;
            var tempArray = new int[rightIndex - leftIndex + 1];
            var currentIndex = 0;

            while ((left <= middleIndex) && (right <= rightIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[currentIndex] = array[left];
                    left++;
                }
                else
                {
                    tempArray[currentIndex] = array[right];
                    right++;
                }

                currentIndex++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[currentIndex] = array[i];
                currentIndex++;
            }

            for (var i = right; i <= rightIndex; i++)
            {
                tempArray[currentIndex] = array[i];
                currentIndex++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[leftIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }





    }
}
