using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFight
{

    public class Cell //для хранения клетки поля 
    {

        public ShipPart ShipPart { get; set; } //часть корабля, то есть корабль состоит из шип партов
        public CellType CellType { get; set; } //ссылка на часть корабля

        public Cell()
        {
            ShipPart = null;
            CellType = CellType.EMPTY;
        }
        public Cell(ShipPart shipPart)
        {
            ShipPart = shipPart;
            if (shipPart.Destroyed)
                CellType = CellType.SHIP_PART_DESTROYED;
            else
                CellType = CellType.SHIP_PART_OK;
        }
        public Cell(CellType cellType)
        {
            ShipPart = null;
            CellType = cellType;
        }

    }

    public enum CellType
    {
        EMPTY,
        SHIP_PART_OK,
        SHIP_PART_DESTROYED,
        MISSED_HIT,
        UNKNOWN
    }
}
