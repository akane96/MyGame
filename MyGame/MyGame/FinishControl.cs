using System.Windows.Forms;

namespace MyGame
{
    public partial class FinishControl : UserControl
    {
        private Game _game;
        public FinishControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
            MessageBox.Show(
                "Игра закончена");
        }
    }
}