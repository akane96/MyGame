using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public sealed partial class BattleControl : UserControl
    {
        private Game _game;
        private Timer timer;
        private static readonly Bitmap Grass = new Bitmap(Image.FromFile("grass.png"));
        private static readonly Bitmap Wall = new Bitmap(Image.FromFile("wall.png"));
        private static readonly Bitmap Player1 = new Bitmap(Image.FromFile("messy.png"));

        public BattleControl()
        {
            DoubleBuffered = true;
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 20;
            KeyDown += OnKeyDown;
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _game.Player.Move(_game.Map, Direction.Up);
                    break;
                case Keys.S:
                    _game.Player.Move(_game.Map, Direction.Down);
                    break;
                case Keys.A:
                    _game.Player.Move(_game.Map, Direction.Left);
                    break;
                case Keys.D:
                    _game.Player.Move(_game.Map, Direction.Right);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e);
            DrawPlayer(e);
        }

        private void DrawPlayer(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Player1, _game.Player.Location.X * Game.CellSize, _game.Player.Location.Y * Game.CellSize, new Rectangle(244, 130, 32, 50), GraphicsUnit.Pixel);
        }

        private void DrawMap(PaintEventArgs e)
        {
            var map = _game.Map;
            var width = _game.Map.Cells.GetLength(0);
            var height = _game.Map.Cells.GetLength(1);
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var location = new Point(x, y);
                    e.Graphics.DrawImage(map.IsWall(location) ? Wall : Grass, location.X * Game.CellSize, y * Game.CellSize);
                }
            }
        }
    }
}