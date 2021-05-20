using System;
using System.Drawing;
using System.Linq;
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
        private static readonly Bitmap Monster = new Bitmap(Image.FromFile(@"monsters\1.png"));
        private readonly Random _random = new Random();

        public BattleControl()
        {
            DoubleBuffered = true;
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 500;
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
                    return;
            }
            MoveMonster();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            
            Invalidate();
        }

        private void MoveMonster()
        {
            foreach (var monster in _game.Monsters)
            {
                var distance = GetDistanceBetweenPoints(monster.Location, _game.Player.Location);
                if (distance <= 4)
                {
                    var nextDirection = WayFinder.FindDirection(_game.Map, monster.Location, _game.Player.Location);
                    if (nextDirection == Direction.None)
                        return;
                    monster.Move(_game.Map, nextDirection);
                }
                else
                {
                    var value = _random.Next(0, 3);
                    var direction = DirectionAndValue.DirectionsAndValues.Keys.ToArray()[value];
                    monster.Move(_game.Map, direction);
                }

                if (monster.Location != _game.Player.Location) continue;
                _game.Player.HP = 0;
                return;
            }
        }

        private int GetDistanceBetweenPoints(Point first, Point second)
        {
            return (int) Math.Round(Math.Sqrt((first.X - second.X) * (first.X - second.X) +
                                              (first.Y - second.Y) * (first.Y - second.Y)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e);
            DrawPlayer(e);
            DrawMonsters(e);
        }

        private void DrawMonsters(PaintEventArgs e)
        {
            foreach (var monster in _game.Monsters)
            {
                e.Graphics.DrawImage(Monster, monster.Location.X * Game.CellSize, monster.Location.Y * Game.CellSize);
            }
        }

        private void DrawPlayer(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Player1, _game.Player.Location.X * Game.CellSize, _game.Player.Location.Y * Game.CellSize, new Rectangle(237, 125, 50, 50), GraphicsUnit.Pixel);
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