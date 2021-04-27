using System;

namespace MyGame
{
    public class Game
    {
        private GameState state = GameState.None;
        private event Action<GameState> changedState;
        
        public Map Map;
        public Player Player;
        public Monster[] Monsters;

        public Game(Map map, Player player, Monster[] monsters)
        {
            Map = map;
            Player = player;
            Monsters = monsters;
        }

        public void ChangeState(GameState gameState)
        {
            state = gameState;
            changedState?.Invoke(gameState);
        }
    }
}