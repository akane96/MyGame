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
            game = new Game();
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
        }
    }
}