using System.Drawing;

namespace MyGame
{
    public class Monster: PersonBase
    {
        public MonsterName Name { get; set; }
        
        public Monster(Point location) : base(location)
        {
        }

        public void Hit(Player player)
        {
            if (player.HP < 50)
                player.HP = 0;
            else player.HP -= 50;
        }

        public override void Move(Map map, Direction direction)
        {
            var newPoint = Location + DirectionAndValue.DirectionsAndValues[direction];
            if (!map.InBounds(newPoint) || map.IsWall(newPoint) || map.Cells[newPoint.X, newPoint.Y] == Cell.Monster) return;
            map.Cells[Location.X, Location.Y] = Cell.Empty;
            Location = newPoint;
            map.Cells[newPoint.X, newPoint.Y] = Cell.Monster;
        }
    }
}