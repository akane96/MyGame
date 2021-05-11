using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public partial class StartControl : UserControl
    {
        private Game _game;
        public StartControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this._game != null)
                return;
            this._game = game;
            var button = new Button();
            button.Name = "Начать игру";
            button.BackColor = Color.Brown;
            Controls.Add(button);
            button.Click += (sender, args) =>
            {
                game.ChangeState(GameState.SelectionPlayer);
            };
        }
    }
}