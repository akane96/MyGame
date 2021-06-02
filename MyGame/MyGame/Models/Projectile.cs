using System.Drawing;
using System.Linq;
using Dungeon;

namespace MyGame
{
    public class Projectile
    {
        private readonly Game _game;
        public Point Location { get; set; }
        public bool IsInAction { get; set; }
        public Map Map { get; }
        public int PowerOutput { get; }

        public Projectile(Point location, Map map, Game game, int powerOutput = 15)
        {
            _game = game;
            Location = location;
            Map = map;
            PowerOutput = powerOutput;
        }

        public void Move(Direction direction)
        {
            var newLocation = Location + DirectionAndValue.DirectionsAndValues[direction];
            if (!Map.InBounds(newLocation) || Map.IsWall(newLocation))
            {
                IsInAction = false;
                return;
            }

            if (Map.Cells[newLocation.X, newLocation.Y] == Cell.Monster)
            {
                var monster = _game.Monsters.First(e => e.Location == newLocation);
                monster.HP -= PowerOutput;
                IsInAction = false;
                if (monster.IsDead)
                    Map.Cells[newLocation.X, newLocation.Y] = Cell.Empty;
            }
            else
                Location = newLocation;
        }
    }
}