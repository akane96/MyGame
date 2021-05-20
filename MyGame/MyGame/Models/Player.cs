using System;
using System.Drawing;

namespace MyGame
{
    public class Player: PersonBase
    {
    public PlayerName Name { get; }

    public Player(PlayerName name, Point location) : base(location)
    {
        Name = name;
    }

    public override void Move(Map map, Direction direction)
    {
        var newPoint = Location + DirectionAndValue.DirectionsAndValues[direction];
        var previousLocation = Location;
        if (!map.InBounds(newPoint) || map.IsWall(newPoint)) return;
        // if (map.Cells[newPoint.X, newPoint.Y] == Cell.Monster)
        // {
        //     HP = 0;
        //     return;
        // }
        Location = newPoint;
        // map.Cells[newPoint.X, newPoint.Y] = Cell.Player;
        // map.Cells[previousLocation.X, previousLocation.Y] = Cell.Empty;
    }

    public void ApplyAttackingAbility(Ability ability, Monster monster)
    {
        throw new NotImplementedException();
    }

    public void RestoreHealth()
    {
        throw new NotImplementedException();
    }
    }
}