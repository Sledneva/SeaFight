using System.Drawing;

namespace SeaFight
{
    public class ShipPart
    {
        private int x; //координаты относительно корабля
        private int y;
        public bool Destroyed { get; set; }
        public Ship ParentShip { get; set; } //корабль которому принадлежит шип парт

        public int X
        {
            get
            {
                return x + ParentShip.X; //коорд корабля + 
            }

            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y + ParentShip.Y;
            }

            set
            {
                y = value;
            }
        }

        public ShipPart(Ship parentShip,Point p)
        {
            X = p.X;
            Y = p.Y;
            ParentShip = parentShip;
            Destroyed = false;
        }
        public ShipPart(Ship parentShip, int x, int y)
        {
            X = x;
            Y = y;
            ParentShip = parentShip;
            Destroyed = false;
        }
    }
}