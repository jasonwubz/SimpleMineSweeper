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
    public partial class MineSweeperForm : Form
    {
        private MineLand mineLand;
        private Color defaultSquareColor;

        private const int defaultButtonWidth = 35;
        private const int defaultButtonHeight = 35;
        private const float defaultDifficultyLevel = 0.18f;
        private bool debugMode = false;

        private int previousGameSize;

        private Timer timeElapsed;
        private int secondsElapsed;

        public MineSweeperForm()
        {
            InitializeComponent();
            defaultSquareColor = Color.LightCyan;
            mineLand = new MineLand();
            previousGameSize = 0;
            newGameMiniButton.Text = "\u21BB";
            timeElapsed = new Timer();
            timeElapsed.Interval = 1000;
            timeElapsed.Enabled = true;
            timeElapsed.Tick += TimeElapsed_Tick;
            secondsElapsed = 0;
            timeElapsed.Stop();

        }

        private void ResetTimer()
        {
            timeElapsed.Stop();
            secondsElapsed = 0;
            timeElapsedTextBox.Text = string.Format("{0} sec", secondsElapsed);
        }

        private void TimeElapsed_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            timeElapsedTextBox.Text = string.Format("{0} sec", secondsElapsed);
        }

        public void BeginGame(int gameSize)
        {
            ResetTimer();

            var numRows = gameSize + 6;
            var numCols = gameSize + 6;

            var moduloValueOnRight = numRows - 1;
            
            mineLand.Recreate(numRows, numCols, defaultDifficultyLevel);
                                   
            SetupMainLayout(defaultButtonHeight, defaultButtonWidth, numRows, numCols);
            SetAndCenterGameInfo("", Color.Black);
            SetAndCenterTimeElapsedTextBox();
            SetRemainingFlagsLabel();

            foreach (MineSquare mineSquare in mineLand.GetEachMineSquare())
            {
                var tempPos = mineSquare.GetIndex();
                var button = CreateUntouchedMineSquareButton(mineSquare);
                if (tempPos % numRows == moduloValueOnRight)
                {
                    MineFlowPanel.SetFlowBreak(button, true);
                }
                MineFlowPanel.Controls.Add(button);
            }

            timeElapsed.Start();
        }

        private Button CreateUntouchedMineSquareButton(MineSquare mineSquare)
        {
            Button button = new Button
            {
                Tag = mineSquare,
                Text = String.Empty,
                Margin = new Padding(0),
                Width = defaultButtonWidth,
                Height = defaultButtonHeight,
                BackColor = defaultSquareColor,
                TabIndex = 0,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular)
            };

            button.MouseDown += new MouseEventHandler(MineSquareButton_Click);
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.DarkGray;

            return button;
        }

        private void SetRemainingFlagsLabel()
        {
            var remainingFlags = mineLand.GetTotalMineCount() - mineLand.GetFlaggedCount();
            flagCountLabel.Text = string.Format("{0}", remainingFlags);
        }

        private void SetAndCenterGameInfo(string text, Color color)
        {
            var prevLocation = gameInfoLabel.Location;

            gameInfoLabel.Text = text;
            gameInfoLabel.ForeColor = color;
            
            prevLocation.X = ((Width / 2) - (gameInfoLabel.Width / 2));
            
            gameInfoLabel.Location = prevLocation;
        }

        private void SetAndCenterTimeElapsedTextBox()
        {
            var prevLocation = timeElapsedTextBox.Location;
            
            prevLocation.X = Width - timeElapsedTextBox.Width - 30;

            timeElapsedTextBox.Location = prevLocation;
        }

        private void SetupMainLayout(int rowSize, int colSize, int numRows, int numCols)
        {
            //clearing each component takes hundreds of ms execution time, so disposing entire flowLayoutPanel is better (only a few ms)
            MineFlowPanel.Visible = false;
            
            var prevLocation = MineFlowPanel.Location;
            MineFlowPanel.Dispose();

            var padding = 2;

            MineFlowPanel = new FlowLayoutPanel();
            MineFlowPanel.Location = prevLocation;
            MineFlowPanel.Width = colSize * numCols + padding;
            MineFlowPanel.Height = rowSize * numRows + padding;
            MineFlowPanel.FlowDirection = FlowDirection.LeftToRight;
            MineFlowPanel.BorderStyle = BorderStyle.FixedSingle;
            MineFlowPanel.Margin = new Padding(2);

            Controls.Add(MineFlowPanel);
            Width = MineFlowPanel.Width + (padding * 20);
            Height = MineFlowPanel.Height + prevLocation.Y + 50;

            prevLocation.X = ((Width / 2) - (MineFlowPanel.Width / 2)) / 2;

            MineFlowPanel.Location = prevLocation;

            foreach (Control button in MineFlowPanel.Controls)
            {
                button.MouseDown -= new MouseEventHandler(MineSquareButton_Click);
                button.Dispose();
            }

            MineFlowPanel.Controls.Clear();
            MineFlowPanel.Visible = true;
        }

        private void MineSquareButtonRight_click(Button button, int pos)
        {
            if (mineLand == null || mineLand.HasGameEnded())
            {
                return;
            }

            MineSquare mineSquare = (MineSquare)button.Tag;

            if (mineSquare.GetState() == SquareState.Flagged)
            {
                SetButtonStyleByState(button, 0, SquareState.Questioned);
                mineSquare.ChangeState(SquareState.Questioned);
                SetRemainingFlagsLabel();
                return;
            }

            if (mineSquare.GetState() == SquareState.Questioned)
            {
                SetButtonStyleByState(button, 0, SquareState.Untouched);
                mineSquare.ChangeState(SquareState.Untouched);
                return;
            }

            if (mineSquare.GetState() == SquareState.Untouched)
            {
                SetButtonStyleByState(button, 0, SquareState.Flagged);
                mineSquare.ChangeState(SquareState.Flagged);
                SetRemainingFlagsLabel();
                return;
            }

        }

        private void RevealEntireBoard(int skipPos)
        {
            foreach(Control button in MineFlowPanel.Controls)
            {
                MineSquare mineSquare = (MineSquare) button.Tag;
                var btnPos = mineSquare.GetIndex();
                if (btnPos == skipPos)
                {
                    continue;
                }

                var curBtnState = mineSquare.GetState();
                switch (curBtnState)
                {
                    case SquareState.Flagged:
                        if (mineSquare.HasMine())
                        {
                            SetButtonStyleByState(button, 0, SquareState.Flagged);
                            mineSquare.ChangeState(SquareState.Flagged);
                        } else
                        {
                            SetButtonStyleByState(button, 0, SquareState.WrongGuess);
                            mineSquare.ChangeState(SquareState.WrongGuess);
                        }
                        break;
                    case SquareState.Untouched:
                        if (mineSquare.HasMine())
                        {
                            SetButtonStyleByState(button, 0, SquareState.MineExposed);
                            mineSquare.ChangeState(SquareState.MineExposed);
                        }
                        else
                        {
                            if (debugMode)
                            {
                                var mineCount = InspectAndCountNearbyMines(btnPos, false);
                                if (mineCount > 0)
                                {
                                    SetButtonStyleByState(button, mineCount);
                                }
                                else
                                {
                                    SetButtonStyleByState(button, 0, SquareState.EmptyExposed);
                                }
                                mineLand.GetMineSquare(btnPos).ChangeState(SquareState.EmptyExposed);
                            }

                        }
                        break;
                    case SquareState.Questioned:
                        if (mineSquare.HasMine())
                        {
                            SetButtonStyleByState(button, 0, SquareState.MineExposed);
                            mineSquare.ChangeState(SquareState.MineExposed);
                        }
                        else
                        {
                            if (debugMode)
                            {
                                SetButtonStyleByState(button, 0, SquareState.EmptyExposed);
                            }

                        }
                        
                        break;
                }
                
            }
        }

        protected void MineSquareButton_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs) e;

            Button button = sender as Button;
            MineSquare mine = button.Tag as MineSquare;
            int pos = mine.GetIndex();

            if (me.Button == MouseButtons.Right)
            {
                MineSquareButtonRight_click(button, pos);
                return;
            }
            
            if (mineLand.HasGameEnded())
            {
                return;
            }

            if (mine.GetState() == SquareState.MineExploded || 
                mine.GetState() == SquareState.EmptyExposed ||
                mine.GetState() == SquareState.Flagged)
            {
                return;
            }
                        
            if (mineLand.ProbeForMine(pos, true))
            {
                SetButtonStyleByState(button, 0, SquareState.MineExploded);
                SetAndCenterGameInfo("You Lost!", Color.Red);
                timeElapsed.Stop();
                RevealEntireBoard(pos);
                return;
            }

            mine.ChangeState(SquareState.EmptyExposed);

            var mineCount = InspectAndCountNearbyMines(pos, false);
            SetButtonStyleByState(button, mineCount, SquareState.EmptyExposed);
            if (mineCount == 0)
            {
                InspectAndCountNearbyMines(pos, true);
            }

            if (mineLand.CheckIfAllCleared())
            {
                SetAndCenterGameInfo("All Cleared!", Color.Blue);
                timeElapsed.Stop();
            } 

        }

        private void SetButtonStyleByState(Control button, int mineCount = 0, SquareState state = SquareState.EmptyExposed)
        {
            if (state == SquareState.Questioned)
            {
                button.Text = "?";
                button.ForeColor = Color.Black;
                button.BackColor = defaultSquareColor;
            }
            else if (state == SquareState.Flagged)
            {
                button.Text = "\u2691"; //flag
                button.ForeColor = Color.Maroon;
                button.BackColor = defaultSquareColor;
            }
            else if (state == SquareState.Untouched)
            {
                button.Text = String.Empty;
                button.ForeColor = Color.Black;
                button.BackColor = defaultSquareColor;
            }
            else if (state == SquareState.MineExploded)
            {
                button.Text = "\u2620"; //skull
                button.ForeColor = Color.White;
                button.BackColor = Color.Red;
            }
            else if (state == SquareState.MineExposed)
            {
                button.Text = "\u26AB"; //dark circle
                button.ForeColor = Color.Black;
                button.BackColor = Color.LightGray;
            }
            else if (state == SquareState.WrongGuess)
            {
                button.Text = "\u274C"; //X
                button.ForeColor = Color.Gray;
                button.BackColor = Color.LightGray;
            }
            else if (state == SquareState.EmptyExposed)
            {
                button.BackColor = Color.LightGray;
                button.Text = (mineCount > 0) ? String.Format("{0}", mineCount) : "";
                Button btn = button as Button;
                btn.FlatAppearance.MouseOverBackColor = Color.LightGray;
                switch (mineCount)
                {
                    case 0:
                        button.ForeColor = Color.Gray;
                        break;
                    case 1:
                        button.ForeColor = Color.Blue;
                        break;
                    case 2:
                        button.ForeColor = Color.Green;
                        break;
                    case 3:
                        button.ForeColor = Color.Red;
                        break;
                    case 4:
                        button.ForeColor = Color.Purple;
                        break;
                    case 5:
                        button.ForeColor = Color.Maroon;
                        break;
                    case 6:
                        button.ForeColor = Color.Turquoise;
                        break;
                    case 7:
                        button.ForeColor = Color.Black;
                        break;
                    case 8:
                        button.ForeColor = Color.Gray;
                        break;
                }
            }
        }
        
        private void RevealSingleSquare(int pos)
        {
            mineLand.GetMineSquare(pos).ChangeState(SquareState.EmptyExposed);
            var nearbyMineCount = InspectAndCountNearbyMines(pos, false);
            SetButtonStyleByState(MineFlowPanel.Controls[pos], nearbyMineCount, SquareState.EmptyExposed);
            if (nearbyMineCount == 0)
            {
                InspectAndCountNearbyMines(pos, true);
            }
        }

        private int InspectAndCountNearbyMines(int pos, bool revealNearbySquares = false)
        {   
            int nearbyMineCount = 0;

            if (mineLand == null)
            {
                return nearbyMineCount;
            }

            int actualMineSquaresCount = mineLand.GetTotalSquareCount();

            if (actualMineSquaresCount  > 0 && pos < actualMineSquaresCount)
            {
                var numRows = mineLand.GetRows();
                var numCols = mineLand.GetColumns();
                var moduloValueOnRight = numRows - 1;

                bool checkUp = true;
                bool checkDown = true;
                bool checkLeft = true;
                bool checkRight = true;
                
                if (pos % numRows == moduloValueOnRight)
                {
                    checkRight = false;
                }

                if (pos < numRows)
                {
                    checkUp = false;
                }

                if (pos % numRows == 0)
                {
                    checkLeft = false;
                }

                if (pos >= (numRows * moduloValueOnRight))
                {
                    checkDown = false;
                }

                if (checkUp)
                {
                    var nearbyPos = pos - numRows;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }


                if (checkDown)
                {
                    var nearbyPos = pos + numRows;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }

                if (checkLeft)
                {
                    var nearbyPos = pos - 1;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }

                if (checkRight)
                {
                    var nearbyPos = pos + 1;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }

                if (checkUp && checkLeft)
                {
                    var nearbyPos = pos - numRows - 1;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }

                if (checkUp && checkRight)
                {
                    var nearbyPos = pos - numRows + 1;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }

                if (checkDown && checkLeft)
                {
                    var nearbyPos = pos + numRows - 1;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }

                if (checkDown && checkRight)
                {
                    var nearbyPos = pos + numRows + 1;
                    nearbyMineCount += InspectSingleSquareForMine(nearbyPos, revealNearbySquares) ? 1 : 0;
                }
                
            }

            return nearbyMineCount;
        }

        private bool InspectSingleSquareForMine(int pos, bool alsoRevealSquare = false)
        {
            var result = false;
            if (mineLand.ProbeForMine(pos, false))
            {
                result = true;
            }
            else
            {
                if (mineLand.GetMineSquare(pos).GetState() == SquareState.Untouched && alsoRevealSquare)
                {
                    RevealSingleSquare(pos);
                }
            }

            return result;
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewGamePrompt newGame = new NewGamePrompt())
            {
                newGame.SetGameSizeBar(previousGameSize);
                if (newGame.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    previousGameSize = newGame.gameSize;
                    BeginGame(newGame.gameSize);
                }
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewGameMiniButton_Click(object sender, EventArgs e)
        {
            BeginGame(previousGameSize);
        }
    }
}
