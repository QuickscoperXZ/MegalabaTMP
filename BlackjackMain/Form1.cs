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
        bool[] player1State;
        bool[] player2State;
        private void playButton_Click(object sender, EventArgs e)
        {
            dynamic server = Activator.CreateInstance(objType);
            player1State = server.getPlayerState(0);
            player2State = server.getPlayerState(1);

            this.Hide();
            Player1 pl1 = new Player1(server,0);
            pl1.Show();
            Player1 pl2 = new Player1(server, 1);
            pl2.Show();
            Thread controlsUpdater = new Thread(delegate ()
            {
                while (player1State[0]) { }
                pl2.Invoke((MethodInvoker)delegate () { pl2.isCurrentPlayer = true; });
            });
            controlsUpdater.Start();
            Thread dealerReady = new Thread(() =>
            {
                bool player1Enough = server.getPlayerState(0)[1];
                bool player2Enough = server.getPlayerState(1)[1];
                while (player1Enough == false || player2Enough == false)
                {
                    player1Enough = server.getPlayerState(0)[1];
                    player2Enough = server.getPlayerState(1)[1];
                }
                while (server.getPlayerTotal(2) <= 17)
                {
                    server.playerTakeOne(2);
                }
                pl1.Invoke((MethodInvoker)delegate () { pl1.showDealerCards(); });
                pl2.Invoke((MethodInvoker)delegate () { pl2.showDealerCards(); });

                pl1.endOfRoundStateProperty = server.getEndOfRoundState(0);
                pl2.endOfRoundStateProperty = server.getEndOfRoundState(1);

                pl1.Invoke((MethodInvoker)delegate () { pl1.eorStateMessage.Visible = true; });
                pl2.Invoke((MethodInvoker)delegate () { pl2.eorStateMessage.Visible = true; });
            });
            dealerReady.Start();
        }
    }
}
