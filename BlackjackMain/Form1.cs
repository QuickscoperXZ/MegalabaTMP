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
using System.Runtime.InteropServices;

namespace BlackjackMain
{
    public partial class Form1 : Form
    {
        static Guid COMID = Guid.Parse("A01782F2-377E-45B8-82F0-090CACB12FBB");
        static Type objType = Type.GetTypeFromProgID("COMegalab");
        public Form1()
        {
            InitializeComponent();
        }
        bool player1State;
        bool player2State;
        private void playButton_Click(object sender, EventArgs e)
        {
            dynamic server = Activator.CreateInstance(objType);
            player1State = server.getPlayerState(0);
            player2State = server.getPlayerState(1);

            //Deck newDeck = new Deck();
            //Round startRound = new Round(newDeck);
            this.Hide();
            Player1 pl1 = new Player1(ref startRound, 0);
            pl1.Show();
            Player1 pl2 = new Player1(ref startRound, 1);
            pl2.Show();
            Thread controlsUpdater = new Thread(delegate ()
            {
                while (player1State) { }
                pl2.Invoke((MethodInvoker)delegate () { pl2.isCurrentPlayer = true; });
            });
            controlsUpdater.Start();
            //Thread dealearReady = new Thread(delegate ()
            //{
            //    while (startRound.players[0].isEnough == false || startRound.players[1].isEnough == false)
            //    { }
            //    while (startRound.players[2].total <= 17)
            //    {
            //        startRound.players[2].takeCard(ref startRound.currentDeck);    
            //    }
            //    pl1.Invoke((MethodInvoker)delegate () { pl1.showDealerCards(); });
            //    pl2.Invoke((MethodInvoker)delegate () { pl2.showDealerCards(); });

            //    dynamic handler = Activator.CreateInstance(objType);

            //    startRound.players[0].endOfRoundCode = handler.handlePlayerState(startRound.players[0].total, startRound.players[2].total);
            //    startRound.players[1].endOfRoundCode = handler.handlePlayerState(startRound.players[1].total, startRound.players[2].total);

            //    if (startRound.players[0].endOfRoundCode == 0)
            //    {
            //        pl1.eorStateMessage.Text = "          Вы выйграли";
            //        pl1.eorStateMessage.ForeColor = Color.Green;
            //    }
            //    if (startRound.players[0].endOfRoundCode == 1)
            //    {
            //        pl1.eorStateMessage.Text = "          Вы проиграли";
            //        pl1.eorStateMessage.ForeColor = Color.Red;
            //    }
            //    if (startRound.players[0].endOfRoundCode == 2)
            //    {
            //        pl1.eorStateMessage.Text = "          Ничья";
            //        pl1.eorStateMessage.ForeColor = Color.Gray;
            //    }
            //    if (startRound.players[1].endOfRoundCode == 0)
            //    {
            //        pl1.eorStateMessage.Text = "          Вы выйграли";
            //        pl1.eorStateMessage.ForeColor = Color.Green;
            //    }
            //    if (startRound.players[1].endOfRoundCode == 1)
            //    {
            //        pl1.eorStateMessage.Text = "          Вы проиграли";
            //        pl1.eorStateMessage.ForeColor = Color.Red;
            //    }
            //    if (startRound.players[1].endOfRoundCode == 2)
            //    {
            //        pl1.eorStateMessage.Text = "          Ничья";
            //        pl1.eorStateMessage.ForeColor = Color.Gray;
            //    }
            //});
            //dealearReady.Start();
        }
    }
}
