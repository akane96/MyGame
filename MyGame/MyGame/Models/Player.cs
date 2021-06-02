using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MyGame
{
    public class Player : PersonBase
    {
        private readonly Game _game;
        public PlayerName Name { get; }
        public List<Projectile> Projectiles { get; set; } = new List<Projectile>();
        public List<(Projectile, Direction)> ProjectilesInAction { get; set; } = new List<(Projectile, Direction)>();

        public Player(PlayerName name, Point location, Game game) : base(location)
        {
            _game = game;
            Name = name;
        }

        public override void Move(Map map, Direction direction)
        {
            var newPoint = Location + DirectionAndValue.DirectionsAndValues[direction];
            if (!map.InBounds(newPoint) || map.IsWall(newPoint)) return;
            if (map.Cells[newPoint.X, newPoint.Y] == Cell.Monster)
            {
                HP = 0;
                return;
            }
            
            Location = newPoint;
            if (map.Cells[Location.X, Location.Y] == Cell.Projectile)
            {
               Projectiles.Add(new Projectile(Location, map, _game));
               map.Cells[Location.X, Location.Y] = Cell.Empty;
            }
        }

        public void ApplyAttackingAbility(Direction direction)
        {
            if (!Projectiles.Any()) return;
            var currentProjectile = Projectiles.Last();
            Projectiles.RemoveAt(Projectiles.Count - 1);
            currentProjectile.IsInAction = true;
            currentProjectile.Location = _game.Player.Location;
            currentProjectile.Move(direction);
            if (currentProjectile.IsInAction)
            {
                ProjectilesInAction.Add((currentProjectile, direction));
            }
        }
    }
}