﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet2
{
    public partial class MascotForm : Form
    {
        public MascotForm()
        {
            InitializeComponent();
            Preprocess();
            Motion();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog(this);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Close();
        }
        
        public static void ResizePictureBoxes(int scale)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                ResizePictureBox(pictureBox, scale);
            }
        }

        private static void ResizePictureBox(PictureBox pictureBox, int scaleVal)
        {
            float scale = scaleVal / 100.0f;
            int width = pictureBox.Image.Width;
            int height = pictureBox.Image.Height;
            pictureBox.Size = new Size((int)(width * scale), (int)(height * scale));
        }

        public static void ResetTimer(int interval)
        {
            timer.Stop();
            timer.Interval = interval;
            timer.Start();
        }

        public static void ResetFrequency(int frequency)
        {
            blinkFrequency = frequency;
        }
    }
}