using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SeaFight
{
    public class Game
    {
        public Stage CurrentStage { get; set; } //этап игры: либо расстановка, либо игра, либо игра закончена

        public RealPlayer Player { get; }
        public ComputerPlayer Computer { get; }

        public Turn CurrentTurn //чей ход, человек либо компьютер
        {
            get
            {
                return currentTurn;
            }

            set
            {
                currentTurn = value;
                if (value == Turn.COMPUTER)
                    Shoot(Computer, Player);
            }
        }
        private Turn currentTurn;

        public Game()
        {
            Player = new RealPlayer();
            Computer = new ComputerPlayer();
            CurrentStage = Stage.PREGAME;
        }

        public void StartGame()
        {
            CurrentStage = Stage.GAME; //игра начинается
            Random rnd = new Random();
            Player.ShipPartsNumber = FieldGenerator.CountShipParts(Player.Ships); //количество живых частей корабля
            Computer.ShipPartsNumber = FieldGenerator.CountShipParts(Computer.Ships);
            CurrentTurn = Turn.COMPUTER;
        }
        public void EndGame()
        {
            System.Windows.Forms.MessageBox.Show("GAME OVER");
        }
        public bool Shoot(RealPlayer source, ComputerPlayer target, int x, int y) //игрок стреляет в компьютер
        {
            if (x >= 0 && y >= 0)
            {
                if (target.Board[x, y].CellType == CellType.SHIP_PART_OK) //проверка клетки по координатам смотрим на доску и обращаемся к переменной клетки
                {
                    target.Board[x, y].ShipPart.Destroyed = true; //часть корабля уничтожена
                    target.Board[x, y].CellType = CellType.SHIP_PART_DESTROYED;
                    Player.EnemyBoard[x, y].CellType = CellType.SHIP_PART_DESTROYED; //попали в корабль, получаем ссылку на корабль
                    Ship targetShip = target.Board[x, y].ShipPart.ParentShip; //вызываем из шип дестроед передаем таргет шип
                    if (IsShipDestroyed(targetShip)) 
                    {
                        MarkCellsAsHit(target.Board, targetShip); //помечаем клетки вокруг корабля
                        MarkCellsAsHit(Player.EnemyBoard, targetShip);
                    }
                    --target.ShipPartsNumber; //уменьшаем корабли противника

                    source.EnemyBoard[x, y].ShipPart = target.Board[x, y].ShipPart;
                    source.EnemyBoard[x, y].CellType = CellType.SHIP_PART_DESTROYED;
                    if (IsComputerLost() || IsPlayerLost()) //проверка на проигрыш
                    {
                        currentTurn = Turn.NONE;
                        EndGame();
                    }
                    return true;
                }
                else if (target.Board[x, y].CellType == CellType.EMPTY)
                {
                    target.Board[x, y].CellType = CellType.MISSED_HIT;

                    source.EnemyBoard[x, y].CellType = CellType.MISSED_HIT;

                    NextTurn(); //передача хода следующему игроку
                    return false;
                }

                //else if (target.Board[x, y].CellType == CellType.MISSED_HIT
                //    || target.Board[x, y].CellType == CellType.SHIP_PART_DESTROYED)
                //{
                //}
            }
            return false;


        }
        public bool Shoot(ComputerPlayer source, RealPlayer target)
        {
            Point targetPoint = source.Shoot(); //точка, в которую будем стрелять
            int x = targetPoint.X;
            int y = targetPoint.Y;

            if (target.Board[x, y].CellType == CellType.SHIP_PART_OK)
            {
                target.Board[x, y].ShipPart.Destroyed = true;
                target.Board[x, y].CellType = CellType.SHIP_PART_DESTROYED;

                --target.ShipPartsNumber;

                Ship targetShip = target.Board[x, y].ShipPart.ParentShip;
                if (IsShipDestroyed(targetShip)) //удаляем ненужные точки
                {
                    List<Point> markedPoints = MarkCellsAsHit(target.Board, targetShip); //список точек вокруг корабля

                    for (int i = 0; i < markedPoints.Count; i++)
                        Computer.AvailablePointForShooting.Remove(markedPoints[i]);

                }
                Shoot(Computer, Player); //если попали, то еще раз вызываем метод
                

                if (IsComputerLost() || IsPlayerLost())
                {
                    currentTurn = Turn.NONE;
                    EndGame();
                }
                return true;
            }
            else if (target.Board[x, y].CellType == CellType.EMPTY)
            {
                target.Board[x, y].CellType = CellType.MISSED_HIT;
                NextTurn();
                return false;
            }
            return false;
        }


        private bool IsPlayerLost()
        {
            return Player.ShipPartsNumber == 0 ? true : false;
        }
        private bool IsComputerLost()
        {
            return Computer.ShipPartsNumber == 0 ? true : false;
        }
        private void NextTurn()
        {
            if (CurrentTurn == Turn.COMPUTER)
                CurrentTurn = Turn.PLAYER;
            else
                CurrentTurn = Turn.COMPUTER;
        }
        private bool IsShipDestroyed(Ship ship)
        {
            if (ship.ShipParts.Find(p => !p.Destroyed) == null) //обращается к списку всех частей корабля. ЕСЛИ ПОИСК = НУЛ
                return true;
            return false;
        }
        private List<Point> MarkCellsAsHit(Cell[,] board, Ship ship)
        {
            List<Point> MarkedPoints = new List<Point>();
            foreach (ShipPart sp in ship.ShipParts)
            {
                for (int i = sp.X - 1; i <= sp.X + 1; i++)
                    for (int j = sp.Y - 1; j <= sp.Y + 1; j++)
                    {
                        if (i >= 0 && j >= 0 && i < Settings.FIELD_SIZE && j < Settings.FIELD_SIZE)
                            //if (!(i == sp.X && j == sp.Y))
                            if (board[i, j].CellType == CellType.EMPTY || board[i, j].CellType == CellType.UNKNOWN)
                            {
                                board[i, j].CellType = CellType.MISSED_HIT;
                                MarkedPoints.Add(new Point(i, j));
                            }
                    }
            }
            return MarkedPoints;
        }
        

    }

    public enum Turn
    {
        PLAYER,
        COMPUTER,
        NONE
    }
    public enum Stage
    {
        PREGAME,
        GAME,
        POSTGAME
    }
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
