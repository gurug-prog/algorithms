using MatrixTraversal;

var mh = new MatrixHandler();
var matrix = mh.GenerateMatrix(5);
var lineDelimiter = new string('-', 40) + "\n";

Console.WriteLine("Simple printing:");
Console.WriteLine(lineDelimiter);
mh.PrintMatrix(matrix);

Console.WriteLine("\nHorizontal snake traversal:");
Console.WriteLine(lineDelimiter);
mh.TraverseHorizontalSnake(matrix);
