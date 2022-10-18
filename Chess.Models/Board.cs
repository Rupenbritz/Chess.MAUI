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
					switch(y)
					{
						case 0:
							//Black pieces
							Grid[y, x] = new Cell(y, x, new Piece(GetPieceNameByLocation(x)));
                            break;
						case 1:
                            //Black pieces
                            var bp = new Piece(GetPieceNameByLocation(x));
                            Grid[y, x] = new Cell(y, x, new Piece(GetPieceNameByLocation(-1)));
                            break;
						case 6:
                            //White pieces
                            Grid[y, x] = new Cell(y, x, new Piece(GetPieceNameByLocation(-1), true));
                            break;
						case 7:
                            //White pieces
                            Grid[y, x] = new Cell(y, x, new Piece(GetPieceNameByLocation(x), true));
                            break;
						default:
                            //Empty
                            Grid[y, x] = new Cell(y, x);
                            break;
					}
                }
            }
        }

		private string GetPieceNameByLocation(int x)
		{
            switch (x)
            {
                case 0:
				case 7:
					return "Rook";
                case 1:
				case 6:
					return "Knight";
                case 2:
				case 5:
					return "Bishop";
                case 3:
					return "Queen";
				case 4:
					return "King";
                default:
					return "Pawn";
            }
        }

        public void MarkNextLegalMoves(Cell currentCell)
        {
			for (int y = 0; y < Size; y++)
			{
				for (int x = 0; x < Size; x++)
				{
					var cell = Grid[y, x];

                    if (!cell.Occupied)
					{
						cell.LegalNextMove = false;
					}
				}
			}

			if (currentCell.Piece != null)
			{
				switch (currentCell.Piece.Name)
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
		public Piece Piece { get; set; }
		public bool Occupied { get; set; }
		public bool LegalNextMove { get; set; }

		public Cell (int x, int y, Piece p = null)
		{
			Row = x; 
			Col = y;
			if (p != null)
			{
				this.Piece = p;
				Occupied = true;
			}
		}
	}

	public class Piece
	{
		public string Name { get; set; }
		public bool IsWhite { get; set; }

		public Piece(string name, bool isWhite = false)
		{
			Name = name;
			IsWhite = isWhite;
		}
	}
}
