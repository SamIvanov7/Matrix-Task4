using System;

class Program
{
    // Головний метод, що запускає програму.
    static void Main()
    {
        MatrixOperations();
    }

    // Метод для виконання операцій над матрицею.
    static void MatrixOperations()
    {
        int[,] matrix = new int[10, 10]; // Ініціалізація матриці 10x10.
        Random random = new Random();  // Генератор випадкових чисел.

        // Наповнення матриці випадковими значеннями
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(10, 100);
            }
        }

        // Відображення матриці та виконання операцій
        PrintMatrix(matrix);
        Console.WriteLine("Sum of main diagonal: " + SumMainDiagonal(matrix));
        Console.WriteLine("Min and Max of side diagonal: " + string.Join(", ", MinMaxSideDiagonal(matrix)));

        DisplayRowOrColumn(matrix); // Відображення певного рядка або стовпця
        SwapRowsOrColumns(matrix);  // Поміняти місцями рядки або стовпці

        // Вивеcти матрицю ще раз, щоб показати результат заміни
        PrintMatrix(matrix);
    }
    // Метод для виведення матриці на екран.
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    // Метод для обчислення суми елементів головної діагоналі матриці.
    static int SumMainDiagonal(int[,] matrix)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, i];
        }
        return sum;
    }
    // Метод для знаходження мінімального та максимального значення побічної діагоналі матриці.
    static int[] MinMaxSideDiagonal(int[,] matrix)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int value = matrix[i, matrix.GetLength(0) - 1 - i];
            if (value < min) min = value;
            if (value > max) max = value;
        }

        return new int[] { min, max };
    }
    // Метод для відображення певного рядка або стовпця матриці за вибором 
    static void DisplayRowOrColumn(int[,] matrix)
    {
        Console.WriteLine("Enter 'r' for row or 'c' for column:");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine("\nEnter the ordinal number (0-9):");
        int index = Convert.ToInt32(Console.ReadLine());

        if (choice == 'r')
        {
            Console.WriteLine($"Row {index}:");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[index, j] + "\t");
            }
            Console.WriteLine();
        }
        else if (choice == 'c')
        {
            Console.WriteLine($"Column {index}:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(matrix[i, index] + "\t");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    // Метод для заміни місцями рядків або стовпців матриці за вибором 
    static void SwapRowsOrColumns(int[,] matrix)
    {
        Console.WriteLine("Enter 'r' to swap rows or 'c' to swap columns:");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine("\nEnter the first ordinal number (0-9):");
        int firstIndex = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second ordinal number (0-9):");
        int secondIndex = Convert.ToInt32(Console.ReadLine());

        if (choice == 'r')
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[firstIndex, j];
                matrix[firstIndex, j] = matrix[secondIndex, j];
                matrix[secondIndex, j] = temp;
            }
        }
        else if (choice == 'c')
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[i, firstIndex];
                matrix[i, firstIndex] = matrix[i, secondIndex];
                matrix[i, secondIndex] = temp;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
}
