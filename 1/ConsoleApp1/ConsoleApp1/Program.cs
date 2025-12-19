using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Выберите задание (1-8) или 0 для выхода:");
            Console.WriteLine("1. Проверить, только ли одно число четное");
            Console.WriteLine("2. Найти максимальное из трех чисел");
            Console.WriteLine("3. Вывести числа в порядке возрастания");
            Console.WriteLine("4. Проверить, бьет ли конь фигуру");
            Console.WriteLine("5. Проверить, бьет ли ферзь фигуру");
            Console.WriteLine("6. Проверить корректность даты");
            Console.WriteLine("7. Получить дату следующего дня");
            Console.WriteLine("8. Вывести число с правильным падежом 'рубль'");
            Console.WriteLine("0. Выход");
            Console.WriteLine("================================");

            Console.Write("Ваш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 8)
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
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
                case 7:
                    Task7();
                    break;
                case 8:
                    Task8();
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Задание 1: Проверить, только ли одно число четное
    static void Task1()
    {
        Console.WriteLine("Задание 1: Даны три целых числа. Вывести «истина», если только одно из них является четным.");

        Console.Write("Введите первое число: ");
        int a = GetInt();
        Console.Write("Введите второе число: ");
        int b = GetInt();
        Console.Write("Введите третье число: ");
        int c = GetInt();

        int evenCount = 0;
        if (a % 2 == 0) evenCount++;
        if (b % 2 == 0) evenCount++;
        if (c % 2 == 0) evenCount++;

        Console.WriteLine($"Результат: {(evenCount == 1 ? "истина" : "ложь")}");
    }

    // Задание 2: Найти максимальное из трех чисел
    static void Task2()
    {
        Console.WriteLine("Задание 2: Даны три целых числа. Получить максимальное из них.");

        Console.Write("Введите первое число: ");
        int a = GetInt();
        Console.Write("Введите второе число: ");
        int b = GetInt();
        Console.Write("Введите третье число: ");
        int c = GetInt();

        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;

        Console.WriteLine($"Максимальное число: {max}");
    }

    // Задание 3: Вывести числа в порядке возрастания
    static void Task3()
    {
        Console.WriteLine("Задание 3: Даны три целых числа. Вывести эти числа в порядке возрастания.");

        Console.Write("Введите первое число: ");
        int a = GetInt();
        Console.Write("Введите второе число: ");
        int b = GetInt();
        Console.Write("Введите третье число: ");
        int c = GetInt();

        // Сортировка трех чисел
        if (a > b) (a, b) = (b, a);
        if (b > c) (b, c) = (c, b);
        if (a > b) (a, b) = (b, a);

        Console.WriteLine($"Числа в порядке возрастания: {a}, {b}, {c}");
    }

    // Задание 4: Проверить, бьет ли конь фигуру
    static void Task4()
    {
        Console.WriteLine("Задание 4: Проверить, бьет ли конь фигуру.");
        Console.WriteLine("Шахматная доска: от 1 до 8 по горизонтали и вертикали.");

        Console.Write("Введите координату X коня (1-8): ");
        int knightX = GetIntInRange(1, 8);
        Console.Write("Введите координату Y коня (1-8): ");
        int knightY = GetIntInRange(1, 8);

        Console.Write("Введите координату X фигуры противника (1-8): ");
        int enemyX = GetIntInRange(1, 8);
        Console.Write("Введите координату Y фигуры противника (1-8): ");
        int enemyY = GetIntInRange(1, 8);

        // Конь бьет, если разница по X и Y составляет (1,2) или (2,1)
        int dx = Math.Abs(knightX - enemyX);
        int dy = Math.Abs(knightY - enemyY);

        bool isAttacking = (dx == 1 && dy == 2) || (dx == 2 && dy == 1);

        Console.WriteLine($"Конь на ({knightX},{knightY}) {(isAttacking ? "бьет" : "не бьет")} фигуру на ({enemyX},{enemyY})");
    }

    // Задание 5: Проверить, бьет ли ферзь фигуру
    static void Task5()
    {
        Console.WriteLine("Задание 5: Проверить, бьет ли ферзь фигуру.");
        Console.WriteLine("Шахматная доска: от 1 до 8 по горизонтали и вертикали.");

        Console.Write("Введите координату X ферзя (1-8): ");
        int queenX = GetIntInRange(1, 8);
        Console.Write("Введите координату Y ферзя (1-8): ");
        int queenY = GetIntInRange(1, 8);

        Console.Write("Введите координату X фигуры противника (1-8): ");
        int enemyX = GetIntInRange(1, 8);
        Console.Write("Введите координату Y фигуры противника (1-8): ");
        int enemyY = GetIntInRange(1, 8);

        // Ферзь бьет, если фигура на той же горизонтали, вертикали или диагонали
        bool isSameRow = queenY == enemyY;
        bool isSameColumn = queenX == enemyX;
        bool isSameDiagonal = Math.Abs(queenX - enemyX) == Math.Abs(queenY - enemyY);

        bool isAttacking = isSameRow || isSameColumn || isSameDiagonal;

        Console.WriteLine($"Ферзь на ({queenX},{queenY}) {(isAttacking ? "бьет" : "не бьет")} фигуру на ({enemyX},{enemyY})");
    }

    // Задание 6: Проверить корректность даты
    static void Task6()
    {
        Console.WriteLine("Задание 6: Проверить корректность даты.");

        Console.Write("Введите день: ");
        int day = GetInt();
        Console.Write("Введите месяц: ");
        int month = GetInt();
        Console.Write("Введите год: ");
        int year = GetInt();

        bool isValid = IsValidDate(day, month, year);

        Console.WriteLine($"Дата {day:00}.{month:00}.{year} {(isValid ? "корректна" : "некорректна")}");
    }

    // Задание 7: Получить дату следующего дня
    static void Task7()
    {
        Console.WriteLine("Задание 7: Получить дату следующего дня.");

        Console.Write("Введите день: ");
        int day = GetInt();
        Console.Write("Введите месяц: ");
        int month = GetInt();
        Console.Write("Введите год: ");
        int year = GetInt();

        if (!IsValidDate(day, month, year))
        {
            Console.WriteLine("Введена некорректная дата!");
            return;
        }

        // Получаем следующую дату
        DateTime currentDate = new DateTime(year, month, day);
        DateTime nextDate = currentDate.AddDays(1);

        Console.WriteLine($"Текущая дата: {day:00}.{month:00}.{year}");
        Console.WriteLine($"Дата следующего дня: {nextDate.Day:00}.{nextDate.Month:00}.{nextDate.Year}");
    }

    // Задание 8: Вывести число с правильным падежом 'рубль'
    static void Task8()
    {
        Console.WriteLine("Задание 8: Вывести число с правильным падежом 'рубль'.");

        Console.Write("Введите число от 1 до 999: ");
        int number = GetIntInRange(1, 999);

        string rubleForm = GetRubleForm(number);

        Console.WriteLine($"{number} {rubleForm}");
    }

    // Вспомогательные методы

    static int GetInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.Write("Неверный ввод. Введите целое число: ");
        }
    }

    static int GetIntInRange(int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                return result;
            Console.Write($"Неверный ввод. Введите число от {min} до {max}: ");
        }
    }

    static bool IsValidDate(int day, int month, int year)
    {
        if (year < 1 || month < 1 || month > 12 || day < 1)
            return false;

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // Проверка на високосный год для февраля
        if (month == 2 && IsLeapYear(year))
            daysInMonth[1] = 29;

        return day <= daysInMonth[month - 1];
    }

    static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    static string GetRubleForm(int number)
    {
        int lastTwoDigits = number % 100;
        int lastDigit = number % 10;

        // Исключения для 11-19
        if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
            return "рублей";

        // Для остальных чисел смотрим на последнюю цифру
        return lastDigit switch
        {
            1 => "рубль",
            2 or 3 or 4 => "рубля",
            _ => "рублей"
        };
    }
}