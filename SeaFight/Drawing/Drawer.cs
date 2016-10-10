using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeaFight
{
    public static class Drawer
    {
        public static void DrawPlayerBoard(Cell[,] board, DataGridView dgw)
        {
            for (int i = 0; i < Settings.FIELD_SIZE; i++)
                for (int j = 0; j < Settings.FIELD_SIZE; j++)
                {
                    switch (board[j, i].CellType)
                    {
                        case CellType.EMPTY:
                            {
                                dgw.Rows[i].Cells[j].Style.BackColor = Settings.EMPTY_CELL_COLOR;
                                break;
                            }
                        case CellType.MISSED_HIT:
                            {
                                dgw.Rows[i].Cells[j].Style.BackColor = Settings.MISSED_HIT_CELL_COLOR;
                                break;
                            }
                        case CellType.SHIP_PART_DESTROYED:
                            {
                                dgw.Rows[i].Cells[j].Style.BackColor = Settings.DESTROYED_PART_CELL_COLOR;
                                break;
                            }
                        case CellType.SHIP_PART_OK:
                            {
                                dgw.Rows[i].Cells[j].Style.BackColor = Settings.SHIP_PART_CELL_COLOR;
                                break;
                            }
                        case CellType.UNKNOWN:
                            {
                                dgw.Rows[i].Cells[j].Style.BackColor = Settings.EMPTY_CELL_COLOR;
                                break;
                            }
                    }
                }
        }
    }
}
