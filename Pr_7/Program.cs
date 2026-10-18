using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа 7. вариант 6";

            Console.WriteLine("Здравствуй!");
            Console.WriteLine("Программа находит число с максимальной суммой делителей на отрезке [2, m].");
            Console.WriteLine("(Считаются все делители, включая 1 и само число)\n");

            while (true)
            {
                try
                {
                    Console.Write("Введите число m (или 0 для выхода из программы): ");
                    string input = Console.ReadLine();

                    // Досрочный выход из цикла (требование задания)
                    if (input == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Выход из программы. До свидания!");
                        break;
                    }

                    int m;
                    if (!Int32.TryParse(input, out m))
                    {
                        throw new FormatException("Вы ввели не число!");
                    }

                    if (m < 2)
                    {
                        throw new ArgumentOutOfRangeException(nameof(m), "Число m должно быть больше либо равно 2.");
                    }

                    int maxSum = 0;
                    int bestNumber = 0;

                    for (int currentNumber = 2; currentNumber <= m; currentNumber++)
                    {
                        int currentSum = 0;

                        for (int divisor = 1; divisor <= currentNumber; divisor++)
                        {
                            if (currentNumber % divisor == 0)
                            {
                                currentSum += divisor;
                            }
                        }

                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            bestNumber = currentNumber;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nНа отрезке [2, {m}] число с максимальной суммой делителей — это {bestNumber}.");
                    Console.WriteLine($"Сумма его делителей: {maxSum}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка формата: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка диапазона: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (OverflowException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка переполнения: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ReadKey();
        }
    }
}