// Put comment here
namespace program4
{
    public partial class IslandGameForm : Form
    {
        NavigationSystem navigationSystem;
        public IslandGameForm()
        {
            InitializeComponent();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string text = "To start the game, enter the dimensions of the " +
                "map.\nThe map cannot be 0 x 0 or smaller, nor " +
                "greater than 10 x 10.\n\nOnce the size is entered,";
            string caption = "How to Play Find the Tropical Island";
            
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}