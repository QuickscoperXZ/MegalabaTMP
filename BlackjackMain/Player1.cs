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
        List<Card> dealerHand;
        List<PictureBox> showableCards = new List<PictureBox>();
        List<PictureBox> showableCardsDealer = new List<PictureBox>();

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
            dealerHand = currentRound.players[2].playingHand;
            //this.playerID = playerID;
        }
        private void Player1_Load(object sender, EventArgs e)
        {
            currentRound.players[0].takeCard(ref currentRound.currentDeck);
            currentRound.players[0].takeCard(ref currentRound.currentDeck);

            playerTotal.Text = Convert.ToString(currentRound.players[0].total);
            showPlayerCards();
            showDealerCards();
        }

        private void playerTotal_TextChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(playerTotal.Text) >= 21)
            {
                currentRound.players[0].isEnough = true;
                enoughButton.Enabled = false;
                moreButton.Enabled = false;
            }
        }
        void updateTotal()
        {
            playerTotal.Text = Convert.ToString(currentRound.players[0].total);
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
            playerTotal.Text = Convert.ToString(currentRound.players[0].total);
        }
        void updateControlsDealer()
        {
            showableCardsDealer.Clear();
            for (int i = 0; i <= dealerHand.Count - 1; i++)
            {
                showableCardsDealer.Add(new Func<PictureBox>(() =>
                {
                    PictureBox returnableValue = new PictureBox();
                    returnableValue.Size = new Size(86, 113);
                    returnableValue.SizeMode = PictureBoxSizeMode.StretchImage;
                    returnableValue.Location = new Point(pictureBox2.Location.X + 34 * i, pictureBox2.Location.Y);
                    returnableValue.Image = new Bitmap(dealerHand[i].pathTo);
                    returnableValue.Name = dealerHand[i].pathTo.Substring(dealerHand[i].pathTo.Length - 5);
                    return returnableValue;
                })());
            }
            dealerTotal.Text = Convert.ToString(currentRound.players[2].total);
        }

        void showPlayerCards()
        {
            updateControls();
            foreach (var item in showableCards)
            {
                Controls.Add(item);
                item.Visible = true;
                item.BringToFront();
            }
        }
        void showDealerCards()
        {
            updateControlsDealer();
            foreach (var item in showableCardsDealer)
            {
                Controls.Add(item);
                item.Visible = true;
                item.BringToFront();
            }
        }

        private void moreButton_Click(object sender, EventArgs e)
        {
            currentRound.players[0].takeCard(ref currentRound.currentDeck);
            updateControls();
            showPlayerCards();
        }

        private void enoughButton_Click(object sender, EventArgs e)
        {
            currentRound.players[0].isEnough = true;
            moreButton.Enabled = false;
            enoughButton.Enabled = false;
        }
    }
}
