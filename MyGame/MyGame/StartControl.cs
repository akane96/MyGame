using System.Windows.Forms;

namespace MyGame
{
    public partial class StartControl : UserControl
    {
        private Game game;
        public StartControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game == null)
                this.game = game;
            var button = new Button();
            button.Name = "Начать игру";
            Controls.Add(button);
            button.Click += (sender, args) =>
            {
                game.ChangeState(GameState.SelectionPlayer);
            };
        }
    }
}