using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using MineSweeper.Properties;

namespace MineSweeper
{
    public partial class MineSweeperForm : Form
    {
        private enum Difficulty { Expert, Intermediate, Beginner }

        private Difficulty difficulty;

        public MineSweeperForm()
        {
            InitializeComponent();

            this.LoadGame_Click(null, null);
            this.tileGrid.TileFlagStatusChange += this.TileFlagStatusChenged;
        }

        private void TileFlagStatusChenged (object sender, TileGrid.TileFlagStatusChangedEventArgs e)
        {
            this.flagCounter_lbl.Text = e.Flags.ToString();
            this.flagCounter_lbl.ForeColor = e.LabelColor;
        }

        private class TileGrid : Panel
        {
            private static readonly HashSet<Tile> gridSearchBlacklist = new HashSet<Tile>();
            private static readonly Random rnd = new Random();

            private Size gridSize;

            private int mineCnt;
            private int flagCnt;
            private bool minesGenerated;

            internal event EventHandler<TileFlagStatusChangedEventArgs> TileFlagStatusChange = delegate { };

            private Tile this[Point point] => (Tile)Controls[$"Tile_{point.X}_{point.Y}"];

            private class Tile : PictureBox
            {
                internal const int length = 26;

                private static readonly int[][] adjacentCoords =
                {
                    new [] {-1, -1}, new [] {0, -1}, new [] {1, -1}, new [] {1, 0}, new [] {1, 1}, new [] {0, 1}, new [] {-1, 1}, new [] {-1, 0}
                };

                private bool flagged;

                internal Tile(int x, int y)
                {
                    this.Name = $"Tile_{x}_{y}";
                    this.Location = new Point(x * length, y * length);
                    this.GridPosition = new Point(x, y);
                    this.Size = new Size(length, length);
                    this.Image = Resources.tile;
                    this.SizeMode = PictureBoxSizeMode.Zoom;
                }

                internal Tile[] AdjacentTiles { get; private set; }

                internal Point GridPosition { get; }

                internal bool Opened { get; private set; }
                internal bool Mined { get; private set; }
                internal bool Flagged
                {
                    get => this.flagged;
                    set
                    {
                        this.flagged = value;
                        this.Image = value ? Resources.flag : Resources.tile;
                    }
                }

                private int AdjacentMines => this.AdjacentTiles.Count(tile => tile.Mined);

                internal void SetAdjacentTiles()
                {
                    TileGrid tileGrid = (TileGrid)this.Parent;

                    List<Tile> adjacentTiles = new List<Tile>(8);

                    foreach (int[] adjacentCoord in adjacentCoords)
                    {
                        Tile tile = tileGrid[new Point(this.GridPosition.X + adjacentCoord[0], this.GridPosition.Y + adjacentCoord[1])];
                        if (tile != null)
                        {
                            adjacentTiles.Add(tile);
                        }
                    }

                    this.AdjacentTiles = adjacentTiles.ToArray();
                }

                internal void TestAdjacentTiles()
                {
                    if (this.flagged || gridSearchBlacklist.Contains(this))
                    {
                        return;
                    }

                    gridSearchBlacklist.Add(this);

                    if (this.AdjacentMines == 0)
                    {
                        foreach (Tile tile in this.AdjacentTiles)
                            tile.TestAdjacentTiles();
                    }

                    this.Open();
                }

                internal void Mine()
                {
                    this.Mined = true;
                }

                private void Open()
                {
                    this.Opened = true;
                    this.Image = (Image)Resources.ResourceManager.GetObject($"cell_{this.AdjacentMines}");
                }
            }

            internal class TileFlagStatusChangedEventArgs : EventArgs
            {
                internal int Flags { get; }

                internal Color LabelColor { get; }

                internal TileFlagStatusChangedEventArgs(int flags, Color labelColor)
                {
                    this.Flags = flags;
                    this.LabelColor = labelColor;
                }
            }

            private void Tile_MouseDown(object sender, MouseEventArgs e)
            {
                Tile tile = sender as Tile;

                if (!tile.Opened)
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left when !tile.Flagged:
                            if (!this.minesGenerated)
                                this.GenerateMines(tile);

                            if (tile.Mined)
                            {
                                this.DisableTiles(true);
                            }
                            else
                            {
                                tile.TestAdjacentTiles();
                                gridSearchBlacklist.Clear();
                            }
                            break;
                        case MouseButtons.Right when this.flagCnt > 0:
                            if (tile.Flagged)
                            {
                                tile.Flagged = false;

                                this.flagCnt++;
                            }
                            else
                            {
                                tile.Flagged = true;

                                this.flagCnt--;
                            }
                            TileFlagStatusChange(this, new TileFlagStatusChangedEventArgs(this.flagCnt, this.flagCnt < this.flagCnt * 0.25 ? Color.Red : Color.Black));
                            break;
                    }
                }

                this.CheckForWin();
            }

            internal void LoadGrid(Size gridSize, int mines)
            {
                this.Controls.Clear();

                this.minesGenerated = false;

                this.gridSize = gridSize;
                this.mineCnt = flagCnt = mines;
                this.Size = new Size(gridSize.Width * Tile.length, gridSize.Height * Tile.length);

                for(int x = 0; x < gridSize.Width; x++)
                    for(int y = 0; y < gridSize.Height; y++)
                    {
                        Tile tile = new Tile(x, y);
                        tile.MouseDown += Tile_MouseDown;

                        Controls.Add(tile);
                    }

                foreach (Tile tile in this.Controls)
                    tile.SetAdjacentTiles();
            }

            private void GenerateMines(Tile safeTile)
            {
                int safeTileCount = safeTile.AdjacentTiles.Length + 1;

                Point[] usedPositions = new Point[this.mineCnt + safeTileCount];
                usedPositions[0] = safeTile.GridPosition;

                for (int i = 1; i < safeTileCount; i++)
                    usedPositions[i] = safeTile.AdjacentTiles[i - 1].GridPosition;

                for (int i = safeTileCount; i < usedPositions.Length; i++)
                {
                    Point point = new Point(rnd.Next(this.gridSize.Width), rnd.Next(this.gridSize.Height));

                    if (!usedPositions.Contains(point))
                    {
                        this[point].Mine();

                        usedPositions[i] = point;
                    }
                    else
                        i--;

                    this.minesGenerated = true;
                }
            }

            private void DisableTiles(bool isGameOver)
            {
                foreach (Tile tile in this.Controls)
                {
                    tile.MouseDown -= this.Tile_MouseDown;

                    if (isGameOver)
                    {
                        tile.Image = !tile.Opened && tile.Mined && !tile.Flagged ? Resources.mine : tile.Flagged && !tile.Mined ? Resources.false_flag : tile.Image;
                    }
                }
            }

            private void CheckForWin()
            {
                if (this.flagCnt != 0 || this.Controls.OfType<Tile>().Count(tile => tile.Opened || tile.Flagged) != this.gridSize.Width * this.gridSize.Height)
                    return;

                MessageBox.Show("Ügyes, megoldottad a játékot!", "Nyertél", MessageBoxButtons.OK);

                this.DisableTiles(false);
            }
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            int x, y, mines;

            switch (difficulty)
            {
                case Difficulty.Beginner:
                    x = y = 9;
                    mines = 10;
                    break;
                case Difficulty.Intermediate:
                    x = y = 16;
                    mines = 40;
                    break;
                case Difficulty.Expert:
                    x = 32;
                    y = 24;
                    mines = 99;
                    break;
                default:
                    throw new InvalidOperationException("Nem implementált nehézségi szint.");
            }

            this.tileGrid.LoadGrid(new Size(x, y), mines);
            this.MaximumSize = this.MinimumSize = new Size(this.tileGrid.Width + 36, this.tileGrid.Height + 98);
            this.flagCounter_lbl.Text = mines.ToString();
            this.flagCounter_lbl.ForeColor = Color.Black;
        }

        private void NewGame_menuStripOption_Click(object sender, EventArgs e)
        {
            this.LoadGame_Click(null, null);
        }

        private void Exit_menuStripOption_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Biztos ki akarsz lépni?", "Játék bezárása", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void MenuStip_DifficultyChanged(object sender, EventArgs e)
        {
            this.difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), (string)((ToolStripMenuItem)sender).Tag);
            this.LoadGame_Click(null, null);
        }
    }
}
