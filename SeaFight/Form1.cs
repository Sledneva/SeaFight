using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class Form1: Form
    {
        Game game;
        string letters = "ABCDEFGHQW";

        //
        List<Ship> ShipsToPlace;
        int CurrentShipLength = Settings.BIG_SHIP_LENGTH;

        Position CurrentShipPosition
        {
            get
            {
                if (radioButton_Horizontal.Checked)
                    return Position.HORIZONTAL;
                return Position.VERTICAL;
            }
        }

        public Form1()
        {
            InitializeComponent();
            game = new Game();
            InitGrid(gridPlayer);
        }

        private void InitGrid(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            grid.DefaultCellStyle.BackColor = Color.White;
            for (int x = 0; x < Settings.FIELD_SIZE; x++)
                grid.Columns.Add("col" + x.ToString(), letters.Substring(x, 1));
            for (int y = 0; y < Settings.FIELD_SIZE; y++)
            {
                grid.Rows.Add();
                grid.Rows[y].HeaderCell.Value = (y + 1).ToString();
                grid.Height = Settings.FIELD_SIZE * grid.Rows[0].Height + grid.ColumnHeadersHeight + 2; //поле * высоту ячейки + высота первой ячейки
                grid.ClearSelection();
            }
        }

        private bool SetShip(int gridX, int gridY, Ship ship)
        {
            return FieldGenerator.SetShip(game.Player.Board, game.Player.Ships, new Ship(gridX, gridY, CurrentShipLength, CurrentShipPosition));
            //return game.Player.SetShip(new Ship(gridX, gridY, CurrentShipLength, CurrentShipPosition));
        }

        private void gridPlayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (game.CurrentStage == Stage.PREGAME)
            {
                if (SetShip(e.ColumnIndex, e.RowIndex,null))
                {
                    Drawer.DrawPlayerBoard(game.Player.Board, gridPlayer);
                    ShipsToPlace.RemoveAt(0);
                    if (ShipsToPlace.Count == 0)
                    {
                        button1.Enabled = true;
// -------
                    }
                    else
                    {
                        CurrentShipLength = ShipsToPlace[0].Length;
                        label_NextShipSize.Text = CurrentShipLength.ToString();
                    }
                }
            }
            gridPlayer.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShipsToPlace = Settings.GetShipList();
            label_NextShipSize.Text = ShipsToPlace.First().Length.ToString();

        }

        private void enemyGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (game.CurrentStage == Stage.GAME /*&& game.CurrentTurn == Turn.PLAYER*/)
            {
                int x = e.ColumnIndex;
                int y = e.RowIndex;

                game.Shoot(game.Player, game.Computer, x, y);
                Drawer.DrawPlayerBoard(game.Player.Board, gridPlayer);
                Drawer.DrawPlayerBoard(game.Player.EnemyBoard, enemyGrid);
            }
            enemyGrid.ClearSelection();
        }

        private void button_GeneretaRandom_Click(object sender, EventArgs e)
        {
            FieldGenerator.GenerateRandomField(ref game.Player.board, ref game.Player.ships);
            button1.Enabled = true;
            //InitGrid(enemyGrid);
            //Drawer.DrawPlayerBoard(game.Player.EnemyBoard, enemyGrid);
            Drawer.DrawPlayerBoard(game.Player.Board, gridPlayer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridPlayer.ClearSelection();

            //label_NextShipSize.Hide();
            label_Stage.Text = "Игра";
            groupBox1.Hide();

            InitGrid(enemyGrid);
            game.StartGame();

            button1.Hide();
        }
    }
}
