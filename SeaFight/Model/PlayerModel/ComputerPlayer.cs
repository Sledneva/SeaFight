using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFight
{
    public class ComputerPlayer: Player
    {

        //
        private Point TargetPoint { get; set; }

        public List<Point> AvailablePointForShooting { get; set; }
        private Random rnd;

        public ComputerPlayer()
        {
            InitializeBoards();
            AvailablePointForShooting = new List<Point>();
            Ships = new List<Ship>();

            FieldGenerator.GenerateRandomField(ref board, ref ships);

            for (int i = 0; i < Settings.FIELD_SIZE; i++)
                for (int j = 0; j < Settings.FIELD_SIZE; j++)
                    AvailablePointForShooting.Add(new Point(i, j));

            rnd = new Random();
            SelectNextTargetPoint();

        }


        public void SelectNextTargetPoint()
        {
            int index = rnd.Next(AvailablePointForShooting.Count);
            TargetPoint = AvailablePointForShooting[index];
        }
        public Point Shoot()
        {
            Point targetPoint = TargetPoint;
            AvailablePointForShooting.Remove(TargetPoint);
            SelectNextTargetPoint();
            return targetPoint;
        }


    }
}
