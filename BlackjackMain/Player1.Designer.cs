namespace BlackjackMain
{
    partial class Player1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerTotal = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.moreButton = new System.Windows.Forms.Button();
            this.enoughButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dealerTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // playerTotal
            // 
            this.playerTotal.Location = new System.Drawing.Point(198, 286);
            this.playerTotal.Name = "playerTotal";
            this.playerTotal.ReadOnly = true;
            this.playerTotal.Size = new System.Drawing.Size(100, 22);
            this.playerTotal.TabIndex = 0;
            this.playerTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerTotal.TextChanged += new System.EventHandler(this.playerTotal_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(195, 318);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // moreButton
            // 
            this.moreButton.Location = new System.Drawing.Point(12, 429);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(85, 44);
            this.moreButton.TabIndex = 2;
            this.moreButton.Text = "Ещё";
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // enoughButton
            // 
            this.enoughButton.Location = new System.Drawing.Point(12, 384);
            this.enoughButton.Name = "enoughButton";
            this.enoughButton.Size = new System.Drawing.Size(85, 44);
            this.enoughButton.TabIndex = 3;
            this.enoughButton.Text = "Хватит";
            this.enoughButton.UseVisualStyleBackColor = true;
            this.enoughButton.Click += new System.EventHandler(this.enoughButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(198, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // dealerTotal
            // 
            this.dealerTotal.Location = new System.Drawing.Point(198, 168);
            this.dealerTotal.Name = "dealerTotal";
            this.dealerTotal.ReadOnly = true;
            this.dealerTotal.Size = new System.Drawing.Size(100, 22);
            this.dealerTotal.TabIndex = 4;
            this.dealerTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 485);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dealerTotal);
            this.Controls.Add(this.enoughButton);
            this.Controls.Add(this.moreButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.playerTotal);
            this.Name = "Player1";
            this.Text = "Player1";
            this.Load += new System.EventHandler(this.Player1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox playerTotal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.Button enoughButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox dealerTotal;
    }
}