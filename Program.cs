using System;

int[,,] Create3DMatrix(int n, int m, int d) {
    int[,,] matrix = new int[n, m, d];
    int nextDigit = 10;
    for (int i = 0; i < matrix.GetLength(2); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            for (int k = 0; k < matrix.GetLength(0); k++) {
                matrix[k, j, i] = nextDigit++;
            }
        }
    }
    return  matrix;
}

int[,,] Shuffle3DMatrix(int[,,] matrix) {
    int n1, m1, k1;
    int n2, m2, k2;
    int temp;
    for (int i = 0; i < 1000; i++) {
        n1 = new Random().Next(0, matrix.GetLength(0));
        m1 = new Random().Next(0, matrix.GetLength(1));
        k1 = new Random().Next(0, matrix.GetLength(2));

        n2 = new Random().Next(0, matrix.GetLength(0));
        m2 = new Random().Next(0, matrix.GetLength(1));
        k2 = new Random().Next(0, matrix.GetLength(2));

        temp = matrix[n1, m1, k1];
        matrix[n1, m1, k1] = matrix[n2, m2, k2];
        matrix[n2, m2, k2] = temp;
    }
    return  matrix;
}

void PrintMatrix(int[,,] matrix) {
    for (int i = 0; i < matrix.GetLength(2); i++) {
        Console.WriteLine($" --- {i} --- ");

        Console.Write("   ");
        for (int k = 0; k < matrix.GetLength(1); k++)
            Console.Write($" {k} ");
        Console.WriteLine();

        for (int j = 0; j < matrix.GetLength(0); j++) {
            Console.Write($" {j} ");
            for (int k = 0; k < matrix.GetLength(1); k++) {
                Console.Write($"{matrix[k, j, i]:d2} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int n = 0;
Console.Write("Please, enter the size of the first dimention: ");
while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 22) {
    Console.Write("This is not a valid size. Please, enter the first dimention: ");
}

int m = 0;
Console.Write("Please, enter the size of the second dimention: ");
while (!int.TryParse(Console.ReadLine(), out m) || n * m < 4 || n * m > 44 ) {
    Console.Write("This is not a valid size. Please, enter the second dimention: ");
}

int d = 0;
Console.Write("Please, enter the size of the third dimention: ");
while (!int.TryParse(Console.ReadLine(), out d) || d * n * m < 8 || d * n * m > 90 ) {
    Console.Write("This is not a valid size. Please, enter the third dimention: ");
}

PrintMatrix(Shuffle3DMatrix(Create3DMatrix(n, m, d)));