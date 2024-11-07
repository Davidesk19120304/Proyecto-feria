﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class simondice : Form
    {
        int blocksX = 160;
        int blocksY = 80;
        int score = 0;
        int level = 3;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> chosenBoxes = new List<PictureBox>();
        Random rnd = new Random();
        Color temp;
        int index = 0;
        int tries = 0;
        int timerLimit = 0;
        bool selectingColours = false;
        string correctOrder = string.Empty;
        string playerOrder = string.Empty;
        public simondice()
        {
            InitializeComponent();
            SetUpBlock();

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);





        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (selectingColours)
            {
                timerLimit++;
                switch (timerLimit)
                {
                    case 10:
                        temp = chosenBoxes[index].BackColor;
                        chosenBoxes[index].BackColor = Color.White;
                        break;
                    case 20:
                        chosenBoxes[index].BackColor = temp;
                        break;
                    case 30:
                        chosenBoxes[index].BackColor = Color.White;
                        break;
                    case 40:
                        chosenBoxes[index].BackColor = temp;
                        break;
                    case 50:
                        if (index < chosenBoxes.Count - 1)
                        {
                            index++;
                            timerLimit = 0;
                        }
                        else
                        {
                            selectingColours = false;
                        }
                        break;
                }
            }
            if (tries >= level)
            {
                if (correctOrder == playerOrder)
                {
                    tries = 0;
                    GameTimer.Stop();
                    DialogResult result = mensajebox.Show("Bien hecho, lo hiciste muy bien.", "MOO Says: ");
                    score++;
                }
                else
                {
                    tries = 0;
                    GameTimer.Stop();
                    DialogResult result = mensajebox.Show("Te has equivocado, vuelve a intentarlo.");
                }
            }
            lblInfo.Text = "Haz click en " + level + " con la misma secuencia..";

        }

        private void ButtonClickEvent(object sender, EventArgs e)
        {
            if (score == 3 && level < 7)
            {
                level++;
                score = 0;
            }
            correctOrder = string.Empty;
            playerOrder = string.Empty;
            chosenBoxes.Clear();
            chosenBoxes = pictureBoxes.OrderBy(x => rnd.Next()).Take(level).ToList();
            for (int i = 0; i < chosenBoxes.Count; i++)
            {
                correctOrder += chosenBoxes[i].Name + " ";
            }
            foreach (PictureBox x in pictureBoxes)
            {
                x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
            Debug.WriteLine(correctOrder);
            index = 0;
            timerLimit = 0;
            selectingColours = true;
            GameTimer.Start();

        }
        private void SetUpBlock()
        {
            for (int i = 1; i < 17; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Name = "pic_" + i;
                newPic.Height = 60;
                newPic.Width = 60;
                newPic.BackColor = Color.Black;
                newPic.Left = blocksX;
                newPic.Top = blocksY;
                newPic.Click += ClickOnPictureBox;
                if (i == 4 || i == 8 || i == 12)
                {
                    blocksY += 65;
                    blocksX = 160;
                }
                else
                {
                    blocksX += 65;
                }
                this.Controls.Add(newPic);
                pictureBoxes.Add(newPic);
            }

        }

        private void ClickOnPictureBox(object sender, EventArgs e)
        {
            if (!selectingColours && chosenBoxes.Count > 1)
            {
                PictureBox temp = sender as PictureBox;
                temp.BackColor = Color.Black;
                playerOrder += temp.Name + " ";
                Debug.WriteLine(playerOrder);
                tries++;
            }
            else
            {
                return;
            }
        }

        private void simondice_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void simondice_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
    }
}
