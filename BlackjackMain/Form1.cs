using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace BlackjackMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Deck newDeck = new Deck();
            Round startRound = new Round(newDeck);
            this.Hide();
            Player1 pl1 = new Player1(ref startRound,0);
            pl1.Show();
            Player1 pl2 = new Player1(ref startRound, 1);
            pl2.Show();
            Thread controlsUpdater = new Thread(delegate ()
            {
                while (pl1.isCurrentPlayer) { }
                pl2.Invoke((MethodInvoker)delegate () { pl2.isCurrentPlayer = true; });
            });
            controlsUpdater.Start();
            Thread dealearReady = new Thread(delegate ()
            {
                while (startRound.players[0].isEnough == false || startRound.players[1].isEnough == false)
                { }
                while (startRound.players[2].total <= 17)
                {
                    startRound.players[2].takeCard(ref startRound.currentDeck);    
                }
                pl1.Invoke((MethodInvoker)delegate () { pl1.showDealerCards(); });
                pl2.Invoke((MethodInvoker)delegate () { pl2.showDealerCards(); });
            });
            dealearReady.Start();
        }
    }
}
