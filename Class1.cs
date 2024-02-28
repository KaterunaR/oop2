using System;
using System.Collections.Generic;

class MyMatrix
{
    public static int col = 5;
    public static int row = 5;
    public int[,] matrix = new int[row, col];
    public int RowCount { get; set; } = row;
    public int ColCount { get; set; } = col;

    public void FillMatrix()
    {
        Random random = new Random();
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                matrix[i, j] = random.Next(-5, 10);
            }
        }
    }

    public int FirstColumnWithoutNegativeElement()
    {
        for (int j = 0; j < ColCount; j++)
        {
            bool columnHasNegative = false;
            for (int i = 0; i < RowCount; i++)
            {
                if (matrix[i, j] < 0)
                {
                    columnHasNegative = true;
                    break;
                }
            }
            if (!columnHasNegative)
            {
                return j; 
            }
        }
        return -1; 
    }

    public void SortRowsByCountOfEqualElements()
    {
        List<KeyValuePair<int, int>> rowCounts = new List<KeyValuePair<int, int>>();
        for (int i = 0; i < RowCount; i++)
        {
            int count = CountEqualElementsInRow(i);
            rowCounts.Add(new KeyValuePair<int, int>(i, count));
        }

        rowCounts.Sort((x, y) => x.Value.CompareTo(y.Value));

        int[,] sortedMatrix = new int[RowCount, ColCount];
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                sortedMatrix[i, j] = matrix[rowCounts[i].Key, j];
            }
        }

        matrix = sortedMatrix; 
    }

    private int CountEqualElementsInRow(int rowIndex)
    {
        HashSet<int> uniqueElements = new HashSet<int>();
        for (int j = 0; j < ColCount; j++)
        {
            uniqueElements.Add(matrix[rowIndex, j]);
        }
        return uniqueElements.Count;
    }
}



