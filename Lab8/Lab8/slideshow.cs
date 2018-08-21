using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class slideshow : Form
    {
        public int timerCount;
        public ArrayList importedPictures;
        public int interval;

        public void updatePcitures(ArrayList inArray, int inInterval)
        {
            importedPictures = inArray;
            interval = inInterval;
        }

        public slideshow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if (timerCount == importedPictures.Count)
            {
                timer1.Enabled = false;
                DialogResult = DialogResult.OK;
            }
            else
            {
                Invalidate();
            }
        }

        private void slideshow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)//exit slideshow by pressing escape key
                this.DialogResult = DialogResult.OK;
        }

        private void slideshow_Paint(object sender, PaintEventArgs e)
        {
            Image[] pictureArray = new Image[importedPictures.Count];
            for (int i = 0; i < importedPictures.Count; i++)
            {
                pictureArray[i] = (Image)importedPictures[i];
            }

            try //fit images to screen
            {
                int width = pictureArray[timerCount].Width;
                int height = pictureArray[timerCount].Height;
                SizeF client = base.ClientSize;
                float space = Math.Min(client.Height / (float)height, client.Width / (float)width);

                e.Graphics.DrawImage(pictureArray[timerCount], (client.Width - (float)width * space) / 2f,
                                                               (client.Height - (float)height * space) / 2f,
                                                               (float)width * space, (float)height * space);
            }
            catch //display error message in place of photo when file is not of correct extension
            {
                e.Graphics.DrawString("Not an image file!", new Font("Arial", 30), Brushes.Red, 25, 25);
            }
        }

        private void slideshow_Activated(object sender, EventArgs e)
        {
            timerCount = 0;
            timer1.Interval = 1000 * interval;
            timer1.Enabled = true;
        }
    }
}
