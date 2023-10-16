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
    int[] n = new int[6];
    int temp;
    for (int i = 0; i < 1000; i++) {
        int k = 0;
        for (int j = 0; j < 6; j++) {
            if (k == 3) k = 0;
            n[j] = new Random().Next(0, matrix.GetLength(k++));
        }

        temp = matrix[n[0], n[1], n[2]];
        matrix[n[0], n[1], n[2]] = matrix[n[3], n[4], n[5]];
        matrix[n[3], n[4], n[5]] = temp;
    }
    return  matrix;
}

void PrintMatrix(int[,,] matrix) {
    for (int i = 0; i < matrix.GetLength(2); i++) {
        Console.WriteLine($" --- {i} --- ");

        Console.Write("__|");
        for (int k = 0; k < matrix.GetLength(1); k++)
            Console.Write($"_{k}_");
        Console.WriteLine();

        for (int j = 0; j < matrix.GetLength(0); j++) {
            Console.Write($" {j}|");
            for (int k = 0; k < matrix.GetLength(1); k++) {
                Console.Write($"{matrix[k, j, i]:d2} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int InputDimentions(string order, double leftLimit, double rightLimit) {
    int n = 0;
    Console.Write($"Please, enter the size of the {order} dimention: ");
    while (!int.TryParse(Console.ReadLine(), out n) || n < leftLimit || n > rightLimit) {
        Console.Write("This is not a valid size. Please, enter the first dimention: ");
    }
    return n;
}
int n = InputDimentions("first", 2, 22);
int m = InputDimentions("second", 4 / n, 44 / n);
int d = InputDimentions("third", 8 / n / m, 90 / n / m);

PrintMatrix(Shuffle3DMatrix(Create3DMatrix(n, m, d)));