using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackMain
{
    internal partial class Player1 : Form
    {
        Round currentRound;
        int playerID;
        List<Card> playingHand;
        List<PictureBox> showableCards = new List<PictureBox>();

        public Player1(Round round,int playerID)
        {
            InitializeComponent();
            currentRound = round;
            this.playerID = playerID;
            
        }
        public Player1(ref Round round)//, int playerID)
        {
            InitializeComponent();
            currentRound = round;
            playingHand = currentRound.players[0].playingHand;
            //this.playerID = playerID;
        }
        private void Player1_Load(object sender, EventArgs e)
        {
            currentRound.players[0].takeCard(ref currentRound.currentDeck);
            currentRound.players[0].takeCard(ref currentRound.currentDeck);

            playerTotal.Text = Convert.ToString(currentRound.players[0].total);
            showCards();
        }

        private void playerTotal_TextChanged(object sender, EventArgs e)
        {
            
        }
        void updateControls()
        {
            showableCards.Clear();
            for (int i = 0; i <= playingHand.Count-1; i++)
            {
                showableCards.Add(new Func<PictureBox>(() =>
                {
                    PictureBox returnableValue = new PictureBox();
                    returnableValue.Size= new Size(86,113);
                    returnableValue.SizeMode = PictureBoxSizeMode.StretchImage;
                    returnableValue.Location = new Point(pictureBox1.Location.X + 34 * i, pictureBox1.Location.Y);
                    returnableValue.Image = new Bitmap(playingHand[i].pathTo);
                    returnableValue.Name = playingHand[i].pathTo.Substring(playingHand[i].pathTo.Length-5);
                    return returnableValue;
                })());
            }
        }
        void showCards()
        {
            updateControls();
            foreach (var item in showableCards)
            {
                Controls.Add(item);
                item.Visible = true;
                item.BringToFront();
            }
        }
    }
}
