using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace algorithms
{
    static class Task1___minimum_queue
    {
        private static string inputPath = @"..\..\..\files\task_one\\input.txt";
        private static string outputPath = @"..\..\..\files\task_one\\output.txt";

        private static Stack<double> stack = new Stack<double>();

        public static void Solution()
        {
            string[] lines = File.ReadAllLines(inputPath);       
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (string line in lines)
                {

                    switch (line[0])
                    {
                        case '+':
                            {

                                stack.Push(Convert.ToDouble(line.Substring(2)));
                                break;
                            }
                        case '-':
                            {
                                stack.Pop();
                                break;
                            }
                        case '?':
                            {
                                writer.WriteLine(FindMinumum());
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }

        private static Stack<T> Clone<T>(this Stack<T> stack)
        {
            return new Stack<T>(new Stack<T>(stack));
        }

        private static double FindMinumum()
        {
            Stack<double> newStack = Clone<double>(stack);
            if (newStack.Count == 0)
            {
                Console.WriteLine("error");
                return 0;
            }

            double minumum = newStack.Pop();
            while (newStack.Count != 0)
            {
                double num = newStack.Pop();
                if (minumum > num) minumum = num;
            }



            return minumum;
        }

    }
}
