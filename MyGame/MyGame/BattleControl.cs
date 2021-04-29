using System.Windows.Forms;

namespace MyGame
{
    public partial class BattleControl : UserControl
    {
        private Timer timer;
        public BattleControl()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 5;
        }

        public void Configure(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}