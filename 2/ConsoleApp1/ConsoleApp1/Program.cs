using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Выберите задание (1-3) или 0 для выхода:");
            Console.WriteLine("1. Проверить, входит ли цифра в число");
            Console.WriteLine("2. Перевернуть число");
            Console.WriteLine("3. Проверить, является ли число числом Фибоначчи");
            Console.WriteLine("0. Выход");
            Console.WriteLine("================================");

            Console.Write("Ваш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 3)
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.\n");
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Выход из программы.");
                break;
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Задание 1: Проверить, входит ли цифра в число
    static void Task1()
    {
        Console.WriteLine("Задание 1: Определить, входит ли заданная цифра в запись целого числа.");

        Console.Write("Введите целое число: ");
        if (!long.TryParse(Console.ReadLine(), out long number))
        {
            Console.WriteLine("Ошибка: Введено не корректное число!");
            return;
        }

        Console.Write("Введите цифру для поиска (0-9): ");
        if (!int.TryParse(Console.ReadLine(), out int digit) || digit < 0 || digit > 9)
        {
            Console.WriteLine("Ошибка: Цифра должна быть от 0 до 9!");
            return;
        }

        // Работаем с абсолютным значением числа (для отрицательных чисел)
        long absNumber = Math.Abs(number);
        bool containsDigit = false;
        long tempNumber = absNumber;

        // Проверяем каждую цифру числа
        if (tempNumber == 0 && digit == 0)
        {
            containsDigit = true;
        }
        else
        {
            while (tempNumber > 0)
            {
                if (tempNumber % 10 == digit)
                {
                    containsDigit = true;
                    break;
                }
                tempNumber /= 10;
            }
        }

        Console.WriteLine($"Цифра {digit} {(containsDigit ? "входит" : "не входит")} в число {number}");
    }

    // Задание 2: Перевернуть число
    static void Task2()
    {
        Console.WriteLine("Задание 2: Из заданного целого числа сформировать новое, цифры в котором идут в обратном порядке.");

        Console.Write("Введите целое число: ");
        if (!long.TryParse(Console.ReadLine(), out long number))
        {
            Console.WriteLine("Ошибка: Введено не корректное число!");
            return;
        }

        long reversedNumber = ReverseNumber(number);

        Console.WriteLine($"Исходное число: {number}");
        Console.WriteLine($"Число в обратном порядке: {reversedNumber}");
    }

    // Задание 3: Проверить, является ли число числом Фибоначчи
    static void Task3()
    {
        Console.WriteLine("Задание 3: Определить, является ли заданное целое число числом Фибоначчи.");
        Console.WriteLine("Числа Фибоначчи: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...");

        Console.Write("Введите целое число: ");
        if (!long.TryParse(Console.ReadLine(), out long number))
        {
            Console.WriteLine("Ошибка: Введено не корректное число!");
            return;
        }

        bool isFibonacci = IsFibonacci(number);

        Console.WriteLine($"Число {number} {(isFibonacci ? "является" : "не является")} числом Фибоначчи");

        // Покажем несколько ближайших чисел Фибоначчи для справки
        if (!isFibonacci)
        {
            Console.WriteLine("\nБлижайшие числа Фибоначчи:");
            ShowNearbyFibonacci(number);
        }
    }

    // Вспомогательные методы

    // Метод для переворота числа
    static long ReverseNumber(long number)
    {
        // Сохраняем знак числа
        bool isNegative = number < 0;
        long absNumber = Math.Abs(number);

        long reversed = 0;

        // Особый случай для 0
        if (absNumber == 0)
        {
            return 0;
        }

        // Переворачиваем цифры
        while (absNumber > 0)
        {
            reversed = reversed * 10 + absNumber % 10;
            absNumber /= 10;
        }

        // Восстанавливаем знак
        return isNegative ? -reversed : reversed;
    }

    // Метод для проверки, является ли число числом Фибоначчи
    static bool IsFibonacci(long number)
    {
        // Числа Фибоначчи не могут быть отрицательными
        if (number < 0)
            return false;

        // 0 и 1 - числа Фибоначчи
        if (number == 0 || number == 1)
            return true;

        // Проверяем, является ли число числом Фибоначчи
        // Используем свойство: число n является числом Фибоначчи тогда и только тогда,
        // когда (5*n² + 4) или (5*n² - 4) является полным квадратом

        long nSquared = number * number;
        long check1 = 5 * nSquared + 4;
        long check2 = 5 * nSquared - 4;

        return IsPerfectSquare(check1) || IsPerfectSquare(check2);
    }

    // Метод для проверки, является ли число полным квадратом
    static bool IsPerfectSquare(long number)
    {
        if (number < 0)
            return false;

        long sqrt = (long)Math.Sqrt(number);
        return sqrt * sqrt == number;
    }

    // Метод для показа ближайших чисел Фибоначчи
    static void ShowNearbyFibonacci(long number)
    {
        if (number < 0)
        {
            Console.WriteLine("(отрицательные числа не являются числами Фибоначчи)");
            return;
        }

        long a = 0, b = 1;

        // Ищем два ближайших числа Фибоначчи
        while (b < number)
        {
            long temp = a + b;
            a = b;
            b = temp;
        }

        Console.WriteLine($"Меньшее: {a}");
        Console.WriteLine($"Большее: {b}");
    }
}