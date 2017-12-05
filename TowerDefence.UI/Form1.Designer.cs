﻿namespace TowerDefence.UI
{
    partial class Form1
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
            this.pause = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLife = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNextWave = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.surrender = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(15, 343);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(93, 23);
            this.pause.TabIndex = 0;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Restart";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 284);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Send next wave";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Money:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Life:";
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(218, 417);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(12, 13);
            this.lblLife.TabIndex = 5;
            this.lblLife.Text = "x";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(165, 417);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(12, 13);
            this.lblMoney.TabIndex = 6;
            this.lblMoney.Text = "x";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(286, 417);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(12, 13);
            this.lblPoints.TabIndex = 8;
            this.lblPoints.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Points:";
            // 
            // lblNextWave
            // 
            this.lblNextWave.AutoSize = true;
            this.lblNextWave.Location = new System.Drawing.Point(81, 251);
            this.lblNextWave.Name = "lblNextWave";
            this.lblNextWave.Size = new System.Drawing.Size(12, 13);
            this.lblNextWave.TabIndex = 10;
            this.lblNextWave.Text = "x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Next wave in:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "drag affordable tower to map";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 313);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(90, 24);
            this.start.TabIndex = 12;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // surrender
            // 
            this.surrender.Location = new System.Drawing.Point(12, 372);
            this.surrender.Name = "surrender";
            this.surrender.Size = new System.Drawing.Size(90, 28);
            this.surrender.TabIndex = 13;
            this.surrender.Text = "Surrender";
            this.surrender.UseVisualStyleBackColor = true;
            this.surrender.Click += new System.EventHandler(this.surrender_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Game state:";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(72, 264);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(12, 13);
            this.labelState.TabIndex = 15;
            this.labelState.Text = "x";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 473);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.surrender);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNextWave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pause);
            this.Name = "Form1";
            this.Text = "Static Defence v0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNextWave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button surrender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelState;
    }
}

