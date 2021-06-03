using System.Drawing;

namespace MyGame
{
    public class Monster: PersonBase
    {
        public Monster(Point location) : base(location)
        {
        }

        public void Hit(Player player)
        {
            if (player.HP < 50)
                player.HP = 0;
            else player.HP -= 50;
        }

        public override void Move(Game game, Direction direction)
        {
            var newPoint = Location + DirectionAndValue.DirectionsAndValues[direction];
            if (!game.Map.InBounds(newPoint) || game.Map.IsWall(newPoint) || game.Map.Cells[newPoint.X, newPoint.Y] == Cell.Monster) return;
            if (game.Map.Cells[newPoint.X, newPoint.Y] == Cell.Projectile)
                game.ProjectileOnMapCount--;
            game.Map.Cells[Location.X, Location.Y] = Cell.Empty;
            Location = newPoint;
            game.Map.Cells[newPoint.X, newPoint.Y] = Cell.Monster;
        }
    }
}