using System;


namespace AHW5
{   /// <summary>
    /// 3. Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.
    /// Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.
    /// </summary>
    class Program
    {
        public static char[] open = new char[] { '(', '[', '{' };
        public static char[] close = new char[] { ')', ']', '}' };

        static void Main(string[] args)
        {            
            Console.WriteLine("Введите выражение, содержащее скобочную последовательность");
            string input = Console.ReadLine();
            CheckSequence(input);
            
            Console.ReadKey();
        }


        /// <summary>
        /// Проверяет символ на открывающую скобку
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsOpening(char c)
        {
            for(int i = 0; i < open.Length; i++)
            {
                if (c == open[i]) return true;
            }
            return false;
        }
        /// <summary>
        /// Проверяет символ на закрывающую скобку
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsClosing(char c)
        {
            for (int i = 0; i < close.Length; i++)
            {
                if (c == close[i]) return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращает открывающую скобку для указанной закрывающей
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char GetOpening(char c)
        {
            for(int i = 0; i < close.Length; i++)
            {
                if (c == close[i]) return open[i];
            }
            return '0';
        }

        /// <summary>
        /// Проверяет последовательность
        /// </summary>
        /// <param name="sequence"></param>
        public static void CheckSequence(string sequence)
        {
            Stack stack = new Stack();
            stack.Init(10);
            string res = "Последовательность верна";
            for (int i = 0; i < sequence.Length; i++)
            {
                if (IsOpening(sequence[i])) // если открывающая - пушим в стэк
                {
                    stack.Push(sequence[i]);
                }
                    
                else if (IsClosing(sequence[i])) // если закрывающая - ищем для нее последнюю открывающую
                {
                    if (stack.Pop() != GetOpening(sequence[i]))
                    {
                        res = "Последовательноcть неверна";
                        break;
                    }
                }
                else continue;
            }
            Console.WriteLine(res);
        }

        public static void PrintCursor(int pos)
        {
            for(int i = 0; i<=pos; i++)
            {
                if (i == pos) Console.WriteLine('^');
                else Console.Write(' ');
            }
        }

        /// <summary>
        /// Структура реализующая стэк
        /// </summary>
        public struct Stack
        {
            char[] array;

            int N;
            int maxN;

            public void Init(int maxN)
            {
                this.maxN = maxN;
                array = new char[maxN];
                N = -1;
            }

            public void Push(char el)
            {
                if (N < maxN)
                {
                    N++;
                    array[N] = el;
                } else {
                    Console.WriteLine("Stack overflow");
                }
            }

            public char Pop()
            {
                if (N != -1)
                {
                    return array[N--];
                } else {
                    Console.WriteLine("Stack empty");
                    return '#';
                }                
            }

            public void Print()
            {
                if(N > 0)
                {
                    for (int i = N; N >= 0; N--)
                    {
                        Console.WriteLine(array[N]);
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
