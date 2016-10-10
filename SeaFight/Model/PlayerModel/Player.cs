using System.Collections.Generic;

namespace SeaFight
{

    public abstract class Player
    {
        public Cell[,] Board { get { return board; } set { board = value; } }
        public List<Ship> Ships { get { return ships; } set { ships = value; } }
        public int ShipPartsNumber { get; set; }

        public Cell[,] board;
        public List<Ship> ships;

        public virtual void InitializeBoards()
        {
            ships = new List<Ship>();
            board = new Cell[Settings.FIELD_SIZE, Settings.FIELD_SIZE];
            for (int i = 0; i < Board.GetLength(1); i++)
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    board[i, j] = new Cell(CellType.EMPTY);
                }

        }

    }
}