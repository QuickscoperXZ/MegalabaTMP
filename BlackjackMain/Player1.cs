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
        
        public Player1(Round round,int playerID)
        {
            InitializeComponent();
            currentRound = round;
            this.playerID = playerID;
        }
        public Player1(Round round)//, int playerID)
        {
            InitializeComponent();
            currentRound = round;
            //this.playerID = playerID;
        }

        private void Player1_Load(object sender, EventArgs e)
        {
            currentRound.players[0].takeCard(ref currentRound.currentDeck);
            currentRound.players[0].takeCard(ref currentRound.currentDeck);

            playerTotal = currentRound.players[0].
        }

        private void playerTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
