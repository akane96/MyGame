using System.Drawing;

namespace MyGame
{
    public class Player
    {
        public PersonName Name { get; }
        public Point Location { get; private set; }
        public int HP { get; private set; }
        
        public Player(PersonName name, Point location)
        {
            Name = name;
            Location = location;
            HP = 100;
        }
    }
}