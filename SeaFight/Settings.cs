using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeaFight
{
    public static class Settings
    {
        public static int FIELD_SIZE = 10;
        public static int BIG_SHIP_LENGTH = 4;

        public static Color MISSED_HIT_CELL_COLOR = Color.Gray;
        public static Color DESTROYED_PART_CELL_COLOR = Color.Red;
        public static Color SHIP_PART_CELL_COLOR = Color.Black;
        public static Color EMPTY_CELL_COLOR = Color.White;
        public static Color UNKNOW_CELL_COLOR = Color.White;

        public static List<Ship> GetShipList()
        {
            List<Ship> Ships = new List<Ship>();

            int CurrentShipsCount = 1;
            int CurrentLength = BIG_SHIP_LENGTH;
            while (CurrentLength > 0)
            {
                for (int i = 0; i < CurrentShipsCount; i++)
                    Ships.Add(new Ship(CurrentLength));

                ++CurrentShipsCount;
                --CurrentLength;
            }
            return Ships;
        }
    }
}
