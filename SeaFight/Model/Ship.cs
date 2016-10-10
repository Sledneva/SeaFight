using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFight
{
    public class Ship 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public bool Destroyed { get; set; } //уничтожен или нет
        public Position Position { get; set; }
        public List<ShipPart> ShipParts { get; set; }   //список шиппартов, из которых корабль состоит


        public Ship(int length)
        {
            Length = length;
            ShipParts = new List<ShipPart>();
            Destroyed = false;
        }
        public Ship(int x, int y, int length, Position position) //принимает координаты x и у, длину. создается корабль с такими координатами, такой длины и позиции
        {
            X = x;
            Y = y;
            Length = length;
            Position = position;
            Destroyed = false;

            ShipParts = new List<ShipPart>();
            for (int i = 0; i < length; i++)
            {
                if (Position == Position.HORIZONTAL)
                    ShipParts.Add(new ShipPart(this, i, 0));
                else if (Position == Position.VERTICAL)
                    ShipParts.Add(new ShipPart(this, 0, i));
            }
        }
    }

    public enum Position
    {
        VERTICAL = 0,
        HORIZONTAL = 1
    }
}
