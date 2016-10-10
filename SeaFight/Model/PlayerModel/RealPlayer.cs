using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFight
{
    public class RealPlayer: Player
    {
        public Cell[,] EnemyBoard { get; set; }


        public RealPlayer()
        {
            Ships = new List<Ship>();
            InitializeBoards();
            ShipPartsNumber = 0;
        }

        public override void InitializeBoards()
        {
            Board = new Cell[Settings.FIELD_SIZE, Settings.FIELD_SIZE];
            EnemyBoard = new Cell[Settings.FIELD_SIZE, Settings.FIELD_SIZE];
            for (int i = 0; i < Board.GetLength(1); i++)
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    Board[i, j] = new Cell(CellType.EMPTY);
                    EnemyBoard[i, j] = new Cell(CellType.UNKNOWN);
                }
        }
    }


}
