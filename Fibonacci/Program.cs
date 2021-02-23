using System;
using System.Collections;
using System.Linq;

namespace HelloApp
{
    class Fibonacci : IEnumerable
    {
        private const int standart_end = 20;
        

        public IEnumerator GetEnumerator()
        {
            int previous_element = 0;
            int current_element = 1;
            for (int i = 0; i < standart_end; i++)
            {
                yield return current_element;
                int help = current_element;
                current_element += previous_element;
                previous_element = help;
            }
        }
        public IEnumerable GetNotStandartEnumerator(int begin, int end)
        {
            int previous_element = 0;
            int current_element = 1;
            for (int i = 1; i < begin; i++)
            {
                int help = current_element;
                current_element += previous_element;
                previous_element = help;
            }
            for (int i = begin; i < end; i++)
            {
                yield return current_element;
                int help = current_element;
                current_element += previous_element;
                previous_element = help;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Fibonacci fibonacci = new Fibonacci();
            foreach (int number in fibonacci)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int begin = input[0];
            int end = input[1];

            foreach (int number in fibonacci.GetNotStandartEnumerator(begin, end))
            {
                Console.Write($"{number} ");
            }
            Console.Read();
        }
    }
}
