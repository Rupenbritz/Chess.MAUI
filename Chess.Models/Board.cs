namespace Chess.Models
{
	public class Board
	{
		public int Size { get; set; }
		public Cell[,] Grid { get; set; }

		public Board (int s)
		{
			Size = s;
			Grid = new Cell[Size, Size];
			this.Init();
		}

        public void Init()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Grid[y, x] = new Cell(y, x);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
		{
			switch (chessPiece)
			{
				case "Knight":
					CheckCell(currentCell.Row + 2, currentCell.Col + 1);
					CheckCell(currentCell.Row + 2, currentCell.Col - 1);
					CheckCell(currentCell.Row - 2, currentCell.Col + 1);
					CheckCell(currentCell.Row - 2, currentCell.Col - 1);
					CheckCell(currentCell.Row + 1, currentCell.Col + 2);
					CheckCell(currentCell.Row + 1, currentCell.Col - 2);
					CheckCell(currentCell.Row - 1, currentCell.Col + 2);
					CheckCell(currentCell.Row - 1, currentCell.Col - 2);
                    break;
				case "King":
					break;
				case "Rook":
					break;
				case "Bishop":
					break;
				case "Queen":
					break;
				default:
					break;
			}
			Grid[currentCell.Row, currentCell.Col].Occupied = true;
        }

		private bool CheckCell(int y, int x)
		{
			try
			{
				if (y >= 0 && y < 8 && x >= 0 && x < 8 && !Grid[y, x].Occupied)
				{
					Grid[y, x].LegalNextMove = true;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}

	public class Cell
	{
		public int Row { get; set; }
		public int Col { get; set; }
		public bool Occupied { get; set; }
		public bool LegalNextMove { get; set; }

		public Cell (int x, int y)
		{
			Row = x; Col = y;
		}
	}
}
