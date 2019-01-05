using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMineSweeper
{
    public partial class NewGamePrompt : Form
    {
        public int gameSize { get; set; }

        public void SetGameSizeBar(int size)
        {
            gameSizeBar.Value = size;
        }

        public NewGamePrompt()
        {
            InitializeComponent();
        }

        private void BeginGameButton_Click(object sender, EventArgs e)
        {
            gameSize = int.Parse(gameSizeBar.Value.ToString());
        }
    }
}
