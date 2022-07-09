namespace MatrixTraversal;

internal class MatrixHandler
{
    public MatrixHandler()
    {

    }

	public void PrintMatrix(ref string[,] matrix)
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
