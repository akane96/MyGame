using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public partial class PlayerSelectionControl : UserControl
    {
        private Game game;
        public PlayerSelectionControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game == null)
            {
                this.game = game;
            }

            var buttonPlayer1 = new Button();
            buttonPlayer1.Name = "Игрок1";
            buttonPlayer1.Click += (sender, args) =>
            {
                var player1 = new Player(PlayerName.Muse, new Point(12, 1));
                game.CreatePlayer(player1);
                game.ChangeState(GameState.Battle);
            };
            Controls.Add(buttonPlayer1);
        }
    }
}