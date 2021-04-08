namespace MyGame
{
    public class Map
    {
        public readonly Cell[,] Cells;

        public Map(Cell[,] cells)
        {
            Cells = cells;
        }
    }
}