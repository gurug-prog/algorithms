using System.ComponentModel;

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
                    matrix[i, j] = $"0{numElement}";
                }
                else
                {
                    matrix[i, j] = $"{numElement}";
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
        Console.WriteLine();
    }

    public void TraverseVerticalSnake(in string[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j % 2 == 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
            }
            else
            {
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
            }
        }
        Console.WriteLine();
    }

    public void TraverseZigzag(in string[,] matrix)
    {
        var resultStr = string.Empty;
        var elementsPassed = 0;
        var countElements = matrix.GetLength(0) * matrix.GetLength(1);
        var i = 0;
        var j = 0;
        var state = ZigzagState.LeftRightDiag;
        var prevState = ZigzagState.LeftRightDiag;
        while (elementsPassed != countElements)
        {
            switch (state)
            {
                case ZigzagState.LeftRight:
                    j++;
                    if (prevState == ZigzagState.LeftRightDiag)
                    {
                        state = ZigzagState.RightLeftDiag;
                    }
                    else if (prevState == ZigzagState.RightLeftDiag)
                    {
                        state = ZigzagState.LeftRightDiag;
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException();
                    }
                    prevState = ZigzagState.LeftRight;
                    break;
                case ZigzagState.TopDown:
                    i++;
                    if (prevState == ZigzagState.LeftRightDiag)
                    {
                        state = ZigzagState.RightLeftDiag;
                    }
                    else if (prevState == ZigzagState.RightLeftDiag)
                    {
                        state = ZigzagState.LeftRightDiag;
                    }
                    else
                    {
                        //
                    }
                    prevState = ZigzagState.TopDown;
                    break;
                case ZigzagState.RightLeftDiag:
                    while (j != 0 && i + 1 < matrix.GetLength(0))
                    {
                        resultStr += $"{matrix[i, j]} ";
                        elementsPassed++;
                        i++;
                        j--;
                    }
                    resultStr += $"{matrix[i, j]} ";
                    elementsPassed++;
                    if (i + 1 < matrix.GetLength(0))
                    {
                        state = ZigzagState.TopDown;
                    }
                    else
                    {
                        state = ZigzagState.LeftRight;
                    }
                    prevState = ZigzagState.RightLeftDiag;
                    break;
                case ZigzagState.LeftRightDiag:
                    while (i != 0 && j + 1 < matrix.GetLength(1))
                    {
                        resultStr += $"{matrix[i, j]} ";
                        elementsPassed++;
                        j++;
                        i--;
                    }
                    resultStr += $"{matrix[i, j]} ";
                    elementsPassed++;
                    if (j + 1 < matrix.GetLength(1))
                    {
                        state = ZigzagState.LeftRight;
                    }
                    else
                    {
                        state = ZigzagState.TopDown;
                    }
                    prevState = ZigzagState.LeftRightDiag;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        Console.WriteLine(resultStr);
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
