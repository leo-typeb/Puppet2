﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet2
{
    public partial class ConfigForm : Form
    {
        private void SetEvents()
        {
            this.FormClosed += new FormClosedEventHandler(Form_Closed);
            numericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            trackBar1.ValueChanged += new EventHandler(TrackBar1_ValueChanged);
            trackBar2.ValueChanged += new EventHandler(TrackBar2_ValueChanged);
            comboBox1.SelectedValueChanged += new EventHandler(ComboBox1_SelectedValueChanged);
            trackBar3.ValueChanged += new EventHandler(TrackBar3_ValueChanged);
            button1.MouseClick += new MouseEventHandler(Button1_MouseClick);
            checkBox2.CheckedChanged += new EventHandler(CheckBox2_CheckedChanged);
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                mascotForm.TransparencyKey = Properties.Settings.Default.MascotBackColor;
                Properties.Settings.Default.Transparency = true;
            }
            else
            {
                mascotForm.TransparencyKey = System.Drawing.Color.Empty;
                Properties.Settings.Default.Transparency = false;
            }
        }

        private void Button1_MouseClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.MascotBackColor = colorDialog1.Color;
                if (checkBox2.Checked)
                {
                    mascotForm.TransparencyKey = colorDialog1.Color;
                }
            }
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {            
            if (microphone.WaveInEvent != null)
            {
                microphone.Stop();
                microphone.Dispose();
                microphone.DeviceNumber = comboBox1.SelectedIndex;
                microphone.WaveInEvent.DeviceNumber = comboBox1.SelectedIndex;
                microphone.Setup();
                microphone.Start();
            }
            
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            MascotForm.ResetTimer(trackBar1.Value);
        }

        private void TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            MascotForm.ResetFrequency(trackBar2.Value);
        }

        private void TrackBar3_ValueChanged(object sender, EventArgs e)
        {
            microphone.VolumeLevelThreshold = trackBar3.Value;
        }

        private void NumericUpDown1_ValueChanged(Object sender, EventArgs e)
        {
            MascotForm.ResizePictureBoxes((int)numericUpDown1.Value);
        }

        private void Form_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Dispose();
        }
    }
}
