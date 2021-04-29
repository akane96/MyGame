using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Form1 : Form
    {
        private Game game;
        private StartControl startControl;
        private PlayerSelectionControl playerSelectionControl;
        private BattleControl battleControl;
        private FinishControl finishControl;
        public Form1()
        {
            InitializeComponent();
            var map = new Map(
                new Cell[,]
                {
                    {Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty, Cell.Wall, Cell.Wall, Cell.Empty},
                    {Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty, Cell.Empty}
                }
            );
            startControl = new StartControl();
            playerSelectionControl = new PlayerSelectionControl();
            battleControl = new BattleControl();
            finishControl = new FinishControl();
            Controls.Add(startControl);
            Controls.Add(playerSelectionControl);
            Controls.Add(battleControl);
            Controls.Add(finishControl);
            playerSelectionControl.Hide();
            battleControl.Hide();
            finishControl.Hide();
            game = new Game(map, new Monster[] {new Monster(new Point(0, 0))});
            game.ChangedState += state =>
            {
                HideScreens();
                switch (state)
                {
                    case GameState.Start : startControl.Show();
                        break;
                    case GameState.SelectionPlayer: playerSelectionControl.Show();
                        break;
                    case GameState.Battle : battleControl.Show();
                        break;
                    case GameState.Result : finishControl.Show();
                        break;
                }
            };
            startControl.Configure(game);
            playerSelectionControl.Configure(game);
            battleControl.Configure(game);
            finishControl.Configure(game);
        }

        private void HideScreens()
        {
            startControl.Hide();
            playerSelectionControl.Hide();
            battleControl.Hide();
            finishControl.Hide();
        }
    }
}