using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Выберите задание (1-8) или 0 для выхода:");
            Console.WriteLine("1. Вычислить сумму произведений");
            Console.WriteLine("2. Вычислить двойной факториал n!!");
            Console.WriteLine("3. Найти числа Армстронга на отрезке");
            Console.WriteLine("4. Найти дружественные числа на отрезке");
            Console.WriteLine("5. Вычислить x^n");
            Console.WriteLine("6. Найти счастливые билеты");
            Console.WriteLine("7. Найти n-е число Фибоначчи");
            Console.WriteLine("8. Вычислить полином по схеме Горнера");
            Console.WriteLine("0. Выход");
            Console.WriteLine("================================");

            Console.Write("Ваш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 8)
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                Console.ReadKey();
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
        }
    }

    // Задание 1: Вычислить сумму произведений
    static void Task1()
    {
        Console.WriteLine("Задание 1: Вычислить сумму 1·2 + 2·3·4 + ... + n·(n+1)·...·(2n)");
        Console.Write("Введите натуральное число n: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Ошибка: n должно быть натуральным числом!");
            return;
        }

        long sum = 0;

        for (int i = 1; i <= n; i++)
        {
            long product = 1;
            // Вычисляем произведение от i до 2i
            for (int j = i; j <= 2 * i; j++)
            {
                product *= j;
            }
            sum += product;
        }

        Console.WriteLine($"Результат: S({n}) = {sum}");

        // Демонстрация шагов для небольших n
        if (n <= 5)
        {
            Console.WriteLine("\nШаги вычисления:");
            long runningSum = 0;
            for (int i = 1; i <= n; i++)
            {
                long product = 1;
                string expression = "";
                for (int j = i; j <= 2 * i; j++)
                {
                    product *= j;
                    expression += j + (j < 2 * i ? "·" : "");
                }
                runningSum += product;
                Console.WriteLine($"{i}-е слагаемое: {expression} = {product}");
                Console.WriteLine($"Текущая сумма: {runningSum}");
            }
        }
    }

    // Задание 2: Вычислить двойной факториал
    static void Task2()
    {
        Console.WriteLine("Задание 2: Вычислить двойной факториал n!!");
        Console.WriteLine("Если n четное: n!! = 2·4·6·...·n");
        Console.WriteLine("Если n нечетное: n!! = 1·3·5·...·n");
        Console.Write("Введите натуральное число n: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Ошибка: n должно быть натуральным числом!");
            return;
        }

        long doubleFactorial = 1;
        int start = (n % 2 == 0) ? 2 : 1;

        for (int i = start; i <= n; i += 2)
        {
            doubleFactorial *= i;
        }

        Console.WriteLine($"Результат: {n}!! = {doubleFactorial}");

        // Покажем шаги вычисления
        Console.Write("\nВычисление: ");
        for (int i = start; i <= n; i += 2)
        {
            Console.Write(i);
            if (i + 2 <= n) Console.Write("·");
        }
        Console.WriteLine($" = {doubleFactorial}");
    }

    // Задание 3: Найти числа Армстронга
    static void Task3()
    {
        Console.WriteLine("Задание 3: Найти числа Армстронга на отрезке [a, b]");
        Console.WriteLine("Число Армстронга: сумма кубов цифр равна самому числу");
        Console.Write("Введите начало отрезка a: ");

        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Ошибка ввода!");
            return;
        }

        Console.Write("Введите конец отрезка b: ");
        if (!int.TryParse(Console.ReadLine(), out int b) || b < a)
        {
            Console.WriteLine("Ошибка: b должно быть >= a!");
            return;
        }

        Console.WriteLine($"\nЧисла Армстронга на отрезке [{a}, {b}]:");
        bool found = false;

        for (int num = a; num <= b; num++)
        {
            if (IsArmstrongNumber(num))
            {
                Console.WriteLine(GetArmstrongExplanation(num));
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Чисел Армстронга на отрезке [{a}, {b}] не найдено.");
        }
    }

    // Задание 4: Найти дружественные числа
    static void Task4()
    {
        Console.WriteLine("Задание 4: Найти дружественные числа на отрезке [a, b]");
        Console.WriteLine("Дружественные числа: сумма делителей первого равна второму и наоборот");
        Console.Write("Введите начало отрезка a: ");

        if (!int.TryParse(Console.ReadLine(), out int a) || a <= 0)
        {
            Console.WriteLine("Ошибка: a должно быть натуральным числом!");
            return;
        }

        Console.Write("Введите конец отрезка b: ");
        if (!int.TryParse(Console.ReadLine(), out int b) || b < a)
        {
            Console.WriteLine("Ошибка: b должно быть >= a!");
            return;
        }

        Console.WriteLine($"\nПоиск дружественных чисел на отрезке [{a}, {b}]...");
        var pairs = FindAmicableNumbers(a, b);

        if (pairs.Count == 0)
        {
            Console.WriteLine($"Дружественных чисел на отрезке [{a}, {b}] не найдено.");
        }
        else
        {
            Console.WriteLine($"Найдено {pairs.Count} пар дружественных чисел:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.Item1} и {pair.Item2}");
                Console.WriteLine($"  Делители {pair.Item1} (без самого числа): {GetDivisorsString(pair.Item1)} = {SumOfDivisors(pair.Item1)}");
                Console.WriteLine($"  Делители {pair.Item2} (без самого числа): {GetDivisorsString(pair.Item2)} = {SumOfDivisors(pair.Item2)}");
            }
        }
    }

    // Задание 5: Вычислить x^n
    static void Task5()
    {
        Console.WriteLine("Задание 5: Вычислить x^n");
        Console.Write("Введите основание x: ");

        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Ошибка ввода!");
            return;
        }

        Console.Write("Введите степень n (целое число): ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Ошибка: n должно быть целым числом!");
            return;
        }

        double result = Power(x, n);
        Console.WriteLine($"\nРезультат: {x}^{n} = {result}");

        if (n >= 0)
        {
            Console.WriteLine("\nВычисление:");
            if (n == 0)
            {
                Console.WriteLine($"{x}^0 = 1 (по определению)");
            }
            else
            {
                double current = 1;
                for (int i = 1; i <= n; i++)
                {
                    current *= x;
                    Console.WriteLine($"{x}^{i} = {current}");
                }
            }
        }
        else
        {
            Console.WriteLine($"\nОтрицательная степень: {x}^{n} = 1 / ({x}^{Math.Abs(n)})");
            Console.WriteLine($"{x}^{Math.Abs(n)} = {Power(x, Math.Abs(n))}");
        }
    }

    // Задание 6: Найти счастливые билеты
    static void Task6()
    {
        Console.WriteLine("Задание 6: Найти все счастливые билеты");
        Console.WriteLine("Билет счастливый, если сумма первых 3 цифр равна сумме последних 3 цифр");

        Console.WriteLine("\nВсе счастливые билеты (000000-999999):");

        int count = 0;
        const int totalTickets = 1000000;

        // Для демонстрации покажем первые 20 и последние 20
        List<string> firstTickets = new List<string>();
        List<string> lastTickets = new List<string>();

        for (int i = 0; i < totalTickets; i++)
        {
            string ticket = i.ToString("D6");
            if (IsLuckyTicket(ticket))
            {
                count++;
                if (count <= 20)
                {
                    firstTickets.Add(ticket);
                }
                else if (count > 20 && lastTickets.Count < 20)
                {
                    lastTickets.Add(ticket);
                }
            }
        }

        Console.WriteLine($"Всего счастливых билетов: {count}");
        Console.WriteLine($"Вероятность получить счастливый билет: {(double)count / totalTickets:P2}");

        Console.WriteLine("\nПервые 20 счастливых билетов:");
        for (int i = 0; i < firstTickets.Count; i++)
        {
            Console.Write($"{firstTickets[i]} ");
            if ((i + 1) % 10 == 0) Console.WriteLine();
        }

        if (lastTickets.Count > 0)
        {
            Console.WriteLine("\nПоследние 20 счастливых билетов:");
            for (int i = 0; i < lastTickets.Count; i++)
            {
                Console.Write($"{lastTickets[i]} ");
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
        }

        // Статистика по суммам
        Console.WriteLine("\nСтатистика по суммам первых трех цифр:");
        int[] sumStats = new int[28]; // Сумма трех цифр может быть от 0 до 27

        for (int i = 0; i < totalTickets; i++)
        {
            string ticket = i.ToString("D6");
            if (IsLuckyTicket(ticket))
            {
                int sum = (ticket[0] - '0') + (ticket[1] - '0') + (ticket[2] - '0');
                sumStats[sum]++;
            }
        }

        for (int sum = 0; sum <= 27; sum++)
        {
            if (sumStats[sum] > 0)
            {
                Console.WriteLine($"Сумма {sum}: {sumStats[sum]} билетов");
            }
        }
    }

    // Задание 7: Найти n-е число Фибоначчи
    static void Task7()
    {
        Console.WriteLine("Задание 7: Найти n-е число Фибоначчи");
        Console.WriteLine("F₁ = F₂ = 1, Fᵢ = Fᵢ₋₁ + Fᵢ₋₂ для i ≥ 3");
        Console.Write("Введите номер числа Фибоначчи n: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Ошибка: n должно быть натуральным числом!");
            return;
        }

        long fibonacci = Fibonacci(n);
        Console.WriteLine($"\nF({n}) = {fibonacci}");

        Console.WriteLine("\nПоследовательность Фибоначчи до F(n):");
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"F({i}) = {Fibonacci(i)}");
        }

        // Дополнительная информация
        if (n > 10)
        {
            Console.WriteLine($"\nОтношение F({n})/F({n - 1}) ≈ {(double)fibonacci / Fibonacci(n - 1):F10}");
            Console.WriteLine("(приближается к золотому сечению φ ≈ 1.6180339887...)");
        }
    }

    // Задание 8: Вычислить полином по схеме Горнера
    static void Task8()
    {
        Console.WriteLine("Задание 8: Вычислить полином по схеме Горнера");
        Console.WriteLine("y = x¹⁰ + 2x⁹ + 3x⁸ + ... + 10x + 11");
        Console.Write("Введите значение x: ");

        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Ошибка ввода!");
            return;
        }

        double result = HornersMethod(x);
        Console.WriteLine($"\nПри x = {x}:");
        Console.WriteLine($"y = {result}");

        // Покажем полином в развернутом виде
        Console.WriteLine("\nПолином в развернутом виде:");
        Console.Write("y = ");
        for (int i = 10; i >= 0; i--)
        {
            int coefficient = 11 - i;
            if (i == 10)
                Console.Write($"{coefficient}x^{i}");
            else if (i == 1)
                Console.Write($" + {coefficient}x");
            else if (i == 0)
                Console.Write($" + {coefficient}");
            else
                Console.Write($" + {coefficient}x^{i}");
        }

        Console.WriteLine($"\n\nВычисление по схеме Горнера:");
        Console.WriteLine("y = (((((((((x + 2)x + 3)x + 4)x + 5)x + 6)x + 7)x + 8)x + 9)x + 10)x + 11");

        // Покажем шаги вычисления
        double[] coefficients = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        double current = coefficients[0];
        Console.WriteLine($"\nНачинаем с коэффициента при x¹⁰: {current}");

        for (int i = 1; i < coefficients.Length; i++)
        {
            current = current * x + coefficients[i];
            Console.WriteLine($"Шаг {i}: умножаем на x = {x}, прибавляем {coefficients[i]} → {current}");
        }
    }

    // Вспомогательные методы

    // Проверка числа Армстронга
    static bool IsArmstrongNumber(int number)
    {
        int sum = 0;
        int temp = number;
        int digits = number.ToString().Length;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += (int)Math.Pow(digit, 3); // Сумма кубов цифр
            temp /= 10;
        }

        return sum == number;
    }

    // Получить объяснение для числа Армстронга
    static string GetArmstrongExplanation(int number)
    {
        string result = $"{number} = ";
        int temp = number;
        List<int> digits = new List<int>();

        while (temp > 0)
        {
            digits.Add(temp % 10);
            temp /= 10;
        }

        digits.Reverse();

        for (int i = 0; i < digits.Count; i++)
        {
            result += $"{digits[i]}³";
            if (i < digits.Count - 1)
                result += " + ";
        }

        result += $" = {string.Join(" + ", digits.ConvertAll(d => (d * d * d).ToString()))}";
        return result;
    }

    // Найти дружественные числа на отрезке
    static List<Tuple<int, int>> FindAmicableNumbers(int a, int b)
    {
        var pairs = new List<Tuple<int, int>>();
        var checkedNumbers = new HashSet<int>();

        for (int i = a; i <= b; i++)
        {
            if (checkedNumbers.Contains(i))
                continue;

            int sumI = SumOfDivisors(i);

            if (sumI > i && sumI <= b)
            {
                int sumJ = SumOfDivisors(sumI);
                if (sumJ == i && sumJ != sumI)
                {
                    pairs.Add(new Tuple<int, int>(i, sumI));
                    checkedNumbers.Add(i);
                    checkedNumbers.Add(sumI);
                }
            }
        }

        return pairs;
    }

    // Сумма делителей (без самого числа)
    static int SumOfDivisors(int number)
    {
        if (number <= 1) return 0;

        int sum = 1; // 1 всегда является делителем

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                sum += i;
                if (i != number / i)
                    sum += number / i;
            }
        }

        return sum;
    }

    // Получить строку с делителями
    static string GetDivisorsString(int number)
    {
        if (number <= 1) return "нет";

        var divisors = new List<int> { 1 };

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                divisors.Add(i);
                if (i != number / i)
                    divisors.Add(number / i);
            }
        }

        divisors.Sort();
        return string.Join("+", divisors);
    }

    // Возведение в степень
    static double Power(double x, int n)
    {
        if (n == 0) return 1;

        bool negative = n < 0;
        n = Math.Abs(n);

        double result = 1;
        for (int i = 0; i < n; i++)
        {
            result *= x;
        }

        return negative ? 1.0 / result : result;
    }

    // Проверка счастливого билета
    static bool IsLuckyTicket(string ticket)
    {
        int sum1 = (ticket[0] - '0') + (ticket[1] - '0') + (ticket[2] - '0');
        int sum2 = (ticket[3] - '0') + (ticket[4] - '0') + (ticket[5] - '0');
        return sum1 == sum2;
    }

    // Число Фибоначчи
    static long Fibonacci(int n)
    {
        if (n <= 2) return 1;

        long a = 1, b = 1;
        for (int i = 3; i <= n; i++)
        {
            long temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }

    // Схема Горнера для полинома
    static double HornersMethod(double x)
    {
        // Коэффициенты для x^10 + 2x^9 + 3x^8 + ... + 10x + 11
        double[] coefficients = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        double result = coefficients[0];

        for (int i = 1; i < coefficients.Length; i++)
        {
            result = result * x + coefficients[i];
        }

        return result;
    }
}