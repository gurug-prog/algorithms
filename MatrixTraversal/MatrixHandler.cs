namespace MatrixTraversal;

internal class MatrixHandler
{
    public MatrixHandler()
    {
    }

    public string[,] GenerateMatrix(int size)
    {
        var matrix = new string[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var numElement = i * size + j;
                if (numElement < 10)
                {
                    matrix[i, j] = $"0{numElement.ToString()}";
                }
                else
                {
                    matrix[i, j] = $"{numElement.ToString()}";
                }
            }
        }

        return matrix;
    }

    public void TraverseHorizontalSnake(in string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
            }
            else
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
            }
        }
    }

    public void PrintMatrix(in string[,] matrix)
    {
        for (int n = 0; n < matrix.GetLength(0); n++)
        {
            for (int m = 0; m < matrix.GetLength(1); m++)
            {
                Console.Write($"{matrix[n, m]} ");
            }
            Console.WriteLine();
        }
    }
}
