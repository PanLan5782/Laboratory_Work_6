using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] M = null;
            string userCommand = null;
            do
            {

                Console.WriteLine("1. Работа с многомерным массивом ");
                Console.WriteLine("2. Обработка строк");
                Console.WriteLine("3.Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        TwoDimentionArr();
                        break;
                    case "2":
                        StringWorks();
                        break;
                    case "3":
                        break;

                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }

        private static void StringWorks()
        {
            int[,] M = null;
            string userCommand = null;

            string s = null;

            do
            {
                Console.WriteLine("1. Создать строку с помощью Набора Готовых Строк");
                Console.WriteLine("2. Создать строку вводом с клавиатуры");
                Console.WriteLine("3. Удалить первое и последнее предложение  в строке");
                Console.WriteLine("4. Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        s = CreateString1();
                        break;
                    case "2":
                        s = CreateString2();
                        break;
                    case "3":
                        DeleteSentense(ref s);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "4");
        }

        private static void DeleteSentense(ref string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Строка пустая. Сформируйте строку.");
                return;
            }
            s = s.Replace("!", "!$");
            s = s.Replace(".", ".$");
            s = s.Replace("?", "?$");
            string[] a = s.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);

            string result = null;

            for (int i = 1; i < a.Length - 1; i++)
                result += a[i];

            s = result;
            {
                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Строка пустая. Сформируйте строку.");
                    return;
                }
                Console.WriteLine("Строка:{0}", s);

            }
        }

        private static void PrintString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Строка пустая. Сформируйте строку.");
                return;
            }
            Console.WriteLine("Строка:{0}", s);

        }

        private static string CreateString1()
        {
            Console.WriteLine("Выберите предложение:");
            string userCommand = null;
            do
            {

                Console.WriteLine("1. Мама мыла раму? ");
                Console.WriteLine("2. Саша, шла ли по шоссе! ");
                Console.WriteLine("3.Программировать на C#? Может лучше погулять? ");
                Console.WriteLine("4.Ленин жил. Ленин жив. Ленин будет жить!");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        return "Мама мыла раму?";
                    case "2":

                        return "Саша, шла ли по шоссе!";
                    case "3":

                        return "Программировать на C#? Может лучше погулять?";
                    case "4":

                        return "Ленин жил. Ленин жив. Ленин будет жить!";
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "5");

            return string.Empty;
        }


        private static string CreateString2()
        {
            Console.WriteLine("Введите предложение:");
            return Console.ReadLine();

        }

        static void TwoDimentionArr()
        {
            int[,] M = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1. Создать двумерный массив с помощью Датчика Случайных Чисел");
                Console.WriteLine("2. Создать двумерный массив вводом с клавиатуры");
                Console.WriteLine("3. Удалить строки с максимальным элементом");
                Console.WriteLine("4. Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        CreateArray2(ref M);
                        break;
                    case "2":
                        CreateArray1(ref M);
                        break;
                    case "3":
                        DeleteRow(ref M);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "5");
        }

        private static void DeleteRow(ref int[,] table)
        {
            if (table == null)
            {
                Console.WriteLine("Массив пустой. Сформируйте массив.");
                return;
            }
            int row, column;
            int max = int.MinValue;

            for (row = 0; row < table.GetLength(0); row++)
            {
                for (column = 0; column < table.GetLength(1); column++)
                    if (table[row, column] > max)
                        max = table[row, column];
            }

            int count = 0; // кол-во строчек с максимальным элементом
            for (row = 0; row < table.GetLength(0); row++)
            {
                for (column = 0; column < table.GetLength(1); column++)
                    if (table[row, column] == max)
                    {
                        count++;
                        break;
                    }
            }
            int rowNum = 0;   //номер строки нового массива
            int[,] newMass = new int[table.GetLength(0) - count, table.GetLength(1)];
            for (row = 0; row < table.GetLength(0); row++)
            {
                bool foundMax = false;
                for (column = 0; column < table.GetLength(1); column++)
                    if (table[row, column] == max)
                    {
                        foundMax = true;
                        break;
                    }

                if (!foundMax)
                {
                    for (column = 0; column < table.GetLength(1); column++)
                        newMass[rowNum, column] = table[row, column];
                    rowNum++;
                }
            }
            table = newMass;
            {
                if (table == null)
                {
                    Console.WriteLine("Массив пустой. Сформируйте массив.");
                    return;
                }
                int i, j;
                for (i = 0; i < table.GetLength(0); i++)
                {
                    for (j = 0; j < table.GetLength(1); j++)
                        Console.Write("{0,4}", table[i, j]);
                    Console.WriteLine();
                }

            }
        }


        private static void CreateArray1(ref int[,] table)
        {
            bool ok = true;

            Random rnd = new Random();
            int strings, columns;
            do
            {
                Console.WriteLine("Введите количество строк");
                ok = Int32.TryParse(Console.ReadLine(), out strings);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }

            while (!ok);
            do
            {
                Console.WriteLine("Введите количество столбцов");
                ok = Int32.TryParse(Console.ReadLine(), out columns);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);
            table = new int[strings, columns];
            int i, j;
            for (i = 0; i < strings; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    do
                    {
                        Console.WriteLine($"Введите элемент {i + 1} строки {j + 1} столбца");
                        ok = Int32.TryParse(Console.ReadLine(), out table[i, j]);
                        if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
                    }
                    while (!ok);
                }

                Console.WriteLine();
            }
            {
                if (table == null)
                {
                    Console.WriteLine("Массив пустой. Сформируйте массив.");
                    return;
                }

                for (i = 0; i < table.GetLength(0); i++)
                {
                    for (j = 0; j < table.GetLength(1); j++)
                        Console.Write("{0,4}", table[i, j]);
                    Console.WriteLine();
                }

            }
        }

        static void CreateArray2(ref int[,] table)
        {
            bool ok = true;
            Random rnd = new Random();
            int strings, columns;
            do
            {
                Console.WriteLine("Введите количество строк");
                ok = Int32.TryParse(Console.ReadLine(), out strings);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);

            do
            {
                Console.WriteLine("Введите количество столбцов");
                ok = Int32.TryParse(Console.ReadLine(), out columns);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);
            table = new int[strings, columns];
            int i, j;
            for (i = 0; i < strings; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    table[i, j] = rnd.Next(1, 10);
                }
                Console.WriteLine();
            }
            {
                if (table == null)
                {
                    Console.WriteLine("Массив пустой. Сформируйте массив.");
                    return;
                }

                for (i = 0; i < table.GetLength(0); i++)
                {
                    for (j = 0; j < table.GetLength(1); j++)
                        Console.Write("{0,4}", table[i, j]);
                    Console.WriteLine();
                }

            }

        }

        static void PrintArray2(ref int[,] table)

        {
            if (table == null)
            {
                Console.WriteLine("Массив пустой. Сформируйте массив.");
                return;
            }
            int i, j;
            for (i = 0; i < table.GetLength(0); i++)
            {
                for (j = 0; j < table.GetLength(1); j++)
                    Console.Write("{0,4}", table[i, j]);
                Console.WriteLine();
            }

        }
    }
}

