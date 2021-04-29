using System;

namespace MyGame
{
    public class Game
    {
        private GameState state = GameState.Start;
        public event Action<GameState> ChangedState;
        
        public Map Map;
        public Player Player;
        public Monster[] Monsters;

        public Game(Map map, Monster[] monsters)
        {
            Map = map;
            Monsters = monsters;
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