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
        int playerID;
        dynamic server;
        string endOfRoundState;
        public string endOfRoundStateProperty
        {
            get { return endOfRoundState; }
            set
            {
                eorStateMessage.Text = value;
            }
        }
        List<PictureBox> showableCards = new List<PictureBox>();
        List<PictureBox> showableCardsDealer = new List<PictureBox>();
        public bool isCurrentPlayer
        {
            get { return server.getPlayerState(playerID); }
            set
            {
                server.setPlayerState(playerID,value);
                if (value == false)
                {
                    moreButton.Enabled = false;
                    enoughButton.Enabled = false;
                }
                else 
                { moreButton.Enabled = true; enoughButton.Enabled = true; }
            }
        }
        public Player1(dynamic srv,int playerID)
        {
            InitializeComponent();
            server = srv;
            this.playerID = playerID;
        }
        private void Player1_Load(object sender, EventArgs e)
        {
            server.playerTakeOne(playerID);
            server.playerTakeOne(playerID);

            playerTotal.Text = Convert.ToString(server.getPlayerTotal(playerID));
            showPlayerCards();
            showDealerCards();
        }

        private void playerTotal_TextChanged(object sender, EventArgs e)
        {
            if (server.getPlayerTotal(playerID) >= 21)
            {
                server.setPlayerState(playerID, false);
                enoughButton.Enabled = false;
                moreButton.Enabled = false;
            }
        }
        void updateControls()
        {
            showableCards.Clear();
            List<string> playerHand = server.getPlayerHand(playerID);
            for (int i = 0; i <= playerHand.Count-1; i++)
            {
                showableCards.Add(new Func<PictureBox>(() =>
                {
                    PictureBox returnableValue = new PictureBox();
                    returnableValue.Size= new Size(86,113);
                    returnableValue.SizeMode = PictureBoxSizeMode.StretchImage;
                    returnableValue.Location = new Point(pictureBox1.Location.X + 34 * i, pictureBox1.Location.Y);
                    returnableValue.Image = new Bitmap(playerHand[i]);
                    returnableValue.Name = playerHand[i].Substring(playerHand[i].Length-5);
                    return returnableValue;
                })());
            }
            playerTotal.Text = Convert.ToString(server.getPlayerTotal(playerID));
        }
        void updateControlsDealer()
        {
            showableCardsDealer.Clear();
            List<string> dealerHand = server.getPlayerHand(2);
            for (int i = 0; i <= dealerHand.Count - 1; i++)
            {
                showableCardsDealer.Add(new Func<PictureBox>(() =>
                {
                    PictureBox returnableValue = new PictureBox();
                    returnableValue.Size = new Size(86, 113);
                    returnableValue.SizeMode = PictureBoxSizeMode.StretchImage;
                    returnableValue.Location = new Point(pictureBox2.Location.X + 34 * i, pictureBox2.Location.Y);
                    returnableValue.Image = new Bitmap(dealerHand[i]);
                    returnableValue.Name = dealerHand[i].Substring(dealerHand[i].Length - 5);
                    return returnableValue;
                })());
            }
            dealerTotal.Text = Convert.ToString(server.getPlayerTotal(2));
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
        public void showDealerCards()
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
            server.playerTakeOne(playerID);
            updateControls();
            showPlayerCards();
        }

        private void enoughButton_Click(object sender, EventArgs e)
        {
            server.setPlayerState(playerID, server.getPlayerState(playerID)[0], true);
            isCurrentPlayer = false;
        }

        private void Player1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
