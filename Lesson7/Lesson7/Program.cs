﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace Lesson7
{
    class fDouble: Form
    {
        private Button bPlus, bMulti, bReset, bCancel;
        private Label lblCurrent, lblCount;
        private TextBox tbMax;
        private MenuStrip menuStrip;
        private ToolStripMenuItem tsmiNew, tsmiNewGame, tsmiExit;

        Doubler doubler;

        public fDouble()
        {
            InitializeComponent();
            doubler = new Doubler();
            UpdateInfo();
        }

        private void InitializeComponent()
        {
            this.bPlus = new Button();
            this.bMulti = new Button();
            this.bReset = new Button();
            this.bCancel = new Button();
            this.lblCurrent = new Label();
            this.tbMax = new TextBox();
            this.lblCount = new Label();
            this.menuStrip = new MenuStrip();
            this.tsmiNew = new ToolStripMenuItem();
            this.tsmiNewGame = new ToolStripMenuItem();
            this.tsmiExit = new ToolStripMenuItem();            

            this.SuspendLayout();
            this.menuStrip.SuspendLayout();
            //
            // bPlus
            //
            this.bPlus.Name = "bPlus";
            this.bPlus.Text = "+1";
            this.bPlus.Location = new Point(10, 30);
            this.bPlus.Click += BPlus_Click;
            //
            // bMulti
            //
            this.bMulti.Name = "bMulti";
            this.bMulti.Text = "x2";
            this.bMulti.Location = new Point(10, 70);
            this.bMulti.Click += BMulti_Click;
            //
            // bReset
            //
            this.bReset.Name = "bReset";
            this.bReset.Text = "Сброс";
            this.bReset.Location = new Point(10, 150);
            this.bReset.Click += BReset_Click;
            //
            // bCancel
            //
            this.bCancel.Name = "bCancel";
            this.bCancel.Text = "Отменить";
            this.bCancel.Location = new Point(10, 110);
            this.bCancel.Click += BCancel_Click;
            //
            // lblCurrent
            //
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Text = "1";
            this.lblCurrent.Location = new Point(120, 34);
            //
            // tbMax
            //
            this.tbMax.Name = "tbMax";
            this.tbMax.Text = "";
            this.tbMax.Location = new Point(120, 70);
            this.tbMax.ReadOnly = true;
            //
            // lblCount
            //
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "0";
            this.lblCount.Location = new Point(120, 114);
            //
            // menuStrip
            //
            this.menuStrip.Items.Add(tsmiNew);
            this.menuStrip.Name = "menuStrip";
            //
            // tsmiNew
            //
            this.tsmiNew.Text = "New";
            this.tsmiNew.DropDownItems.AddRange(new ToolStripItem[] { tsmiNewGame,
                tsmiExit });
            //
            // tsmiNewGame
            //
            this.tsmiNewGame.Text = "New Game";
            this.tsmiNewGame.Click += TsmiNewGame_Click;
            //
            // tsmiExit
            //
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += TsmiExit_Click;
            // 
            // fDouble
            // 
            this.ClientSize = new System.Drawing.Size(233, 188);
            this.Controls.AddRange(new Control[] { bPlus, bMulti, bReset, bCancel,
                lblCurrent, tbMax, lblCount, menuStrip });
            this.MainMenuStrip = this.menuStrip;
            this.Text = "Удвоитель";
            this.Name = "fDouble";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            //Отмена хода
            doubler.Cancel();
            UpdateInfo();
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            //Выход из программы
            this.Close();
        }

        private void TsmiNewGame_Click(object sender, EventArgs e)
        {
            //Начать новую игру
            doubler = new Doubler();
            UpdateInfo();
        }

        private void BReset_Click(object sender, EventArgs e)
        {
            //Начать игру заново
            doubler.Reset();
            UpdateInfo();
        }

        private void BMulti_Click(object sender, EventArgs e)
        {
            //Умножить текущее значение на 2
            doubler.Multi();
            UpdateInfo();
        }

        private void BPlus_Click(object sender, EventArgs e)
        {
            //Прибавить к текущему значению 1
            doubler.Plus();
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            //Обновить информацию на форме
            this.lblCurrent.Text = doubler.Current.ToString();
            this.lblCount.Text = $"Шаг: {doubler.Count.ToString()} из {doubler.MinimumStep}";
            tbMax.Text = doubler.Max.ToString();
            bPlus.Enabled = bMulti.Enabled = (doubler.Count != doubler.MinimumStep);
            bReset.Enabled = bCancel.Enabled = (doubler.Count != 0);
            if (doubler.Current == doubler.Max)
            {
                MessageBox.Show("Вы выиграли!", "Поздравляем!");
                doubler = new Doubler();
                tbMax.Text = doubler.Max.ToString();
                UpdateInfo();
            }

        }
    }

    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fDouble());
        }
    }
}
