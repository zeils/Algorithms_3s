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





        private static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            string line = leftIndex + " " + rightIndex + " " + array[leftIndex] + " " + array[rightIndex];
            outputLines.Add(line);

            var left = leftIndex;
            var right = middleIndex + 1;
            var newArray = new int[rightIndex - leftIndex + 1];
            var currentIndex = 0;

            while ((left <= middleIndex) && (right <= rightIndex))
            {
                if (array[left] < array[right])
                {
                    newArray[currentIndex] = array[left];
                    left++;
                }
                else
                {
                    newArray[currentIndex] = array[right];
                    right++;
                }

                currentIndex++;
            }

            for (int i = left; i <= middleIndex; i++)
            {
                newArray[currentIndex] = array[i];
                currentIndex++;
            }

            for (int i = right; i <= rightIndex; i++)
            {
                newArray[currentIndex] = array[i];
                currentIndex++;
            }

            for (int i = 0; i < newArray.Length; i++)
            {
                array[leftIndex + i] = newArray[i];
            }
        }

        private static int[] MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(array, leftIndex, middleIndex);
                MergeSort(array, middleIndex + 1, rightIndex);
                Merge(array, leftIndex, middleIndex, rightIndex);
            }
            if (leftIndex == rightIndex)
            {
                string line = leftIndex + " " + rightIndex + " " + array[leftIndex] + " " + array[rightIndex];
                outputLines.Add(line);
            }

            return array;
        }

        private static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }





    }
}
