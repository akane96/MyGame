using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame
{
    public class Game
    {
        private GameState state = GameState.Start;
        public const int CellSize = 50;
        public event Action<GameState> ChangedState;
        
        public Map Map;
        public Player Player;
        public Monster[] Monsters;
        public int ProjectileOnMapCount { get; set; }
        public int ProjectileOnMapMaxCount { get; }
        public readonly Random Random = new Random(); 

        public Game(Map map, Monster[] monsters, int projectileOnMapMaxCount = 7)
        {
            Map = map;
            CreateProjectile();
            Monsters = monsters;
            ProjectileOnMapMaxCount = projectileOnMapMaxCount;
        }

        public void CreateProjectile()
        {
            var emptyCells = new List<(int, int)>();
            for (var i = 0; i < Map.Cells.GetLength(0); i++)
            for (var j = 0; j < Map.Cells.GetLength(1); j++)
            {
                if (Map.Cells[i, j] == Cell.Empty)
                    emptyCells.Add((i, j));
            }
            while (ProjectileOnMapCount != ProjectileOnMapMaxCount)
            {
                var nextCell = Random.Next(0, emptyCells.Count);
                Map.Cells[emptyCells[nextCell].Item1, emptyCells[nextCell].Item2] = Cell.Projectile;
                emptyCells.RemoveAt(nextCell);
                ProjectileOnMapCount++;
            }
        }

        public void ChangeState(GameState gameState)
        {
            state = gameState;
            ChangedState?.Invoke(gameState);
        }

        public void CreatePlayer(Player player)
        {
            Player = player;
        }
    }
}