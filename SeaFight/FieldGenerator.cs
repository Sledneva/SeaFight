using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFight
{
    public static class FieldGenerator
    {
        //public Cell[,] Board { get; set; }
        //public List<Ship> Ships { get; set; }



        public static bool IsCellAvailable(Cell[,] board, int x, int y)
        {
            if (x < 0 || x >= Settings.FIELD_SIZE || y < 0 || y >= Settings.FIELD_SIZE)
                return false;

            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 || i >= Settings.FIELD_SIZE || j < 0 || j >= Settings.FIELD_SIZE)
                        continue;
                    if (board[i, j].CellType == CellType.SHIP_PART_OK)
                        return false;
                }
            return true;
        }
        public static bool TryShip(Cell[,] board, Ship ship)
        {
            foreach (ShipPart sp in ship.ShipParts) //можно ли поставить корабль из конкретной точки
                if (!IsCellAvailable(board, sp.X, sp.Y))
                    return false;
            return true;
        }
        public static bool SetShip(Cell[,] board, List<Ship> ships, Ship ship) //установка корабля
        {
            if (TryShip(board, ship))
            {
                ships.Add(ship);
                for (int i = 0; i < ship.Length; i++)
                {
                    ShipPart sp = ship.ShipParts[i];
                    board[sp.X, sp.Y].CellType = CellType.SHIP_PART_OK;
                    board[sp.X, sp.Y].ShipPart = sp;
                    //++ShipPartsNumber;
                }
                return true;
            }
            return false;
        }

        public static int CountShipParts(List<Ship> ships) //количество шиппартов
        {
            int shipParts = 0;
            foreach (Ship ship in ships) //проходим по каждому кораблю
                foreach (ShipPart sp in ship.ShipParts) //по каждому шиппарту
                    ++shipParts;
            return shipParts;
        }

        public static void GenerateRandomField(ref Cell[,] board, ref List<Ship> ships)
        {
            board = new Cell[Settings.FIELD_SIZE, Settings.FIELD_SIZE];
            for (int i = 0; i < board.GetLength(1); i++)
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    board[i, j] = new Cell(CellType.EMPTY);
                }
            ships = new List<Ship>();


            int currentShipSize = Settings.BIG_SHIP_LENGTH;
            int currentShipCount = 1;
            while (currentShipSize > 0)
            {
                for (int i = 0; i < currentShipCount; i++)
                {
                    Ship ship = GenerateRandomShip(currentShipSize);
                    while (!TryShip(board, ship))
                        ship = GenerateRandomShip(currentShipSize);
                    SetShip(board, ships, ship);
                }
                currentShipSize--;
                currentShipCount++;
            }
        }
        public static Ship GenerateRandomShip(int length)
        {
            Random rnd = new Random();
            Ship ship = new Ship(length);
            ship.Position = (Position) rnd.Next(0, 2);

            for (int i = 0; i < length; i++)
            {
                if (ship.Position == Position.HORIZONTAL)
                    ship.ShipParts.Add(new ShipPart(ship, new Point(i, 0)));
                else
                    ship.ShipParts.Add(new ShipPart(ship, new Point(0, i)));

            }

            ship.X = rnd.Next(0, Settings.FIELD_SIZE);
            ship.Y = rnd.Next(0, Settings.FIELD_SIZE);
            return ship;
        }

    }
}
