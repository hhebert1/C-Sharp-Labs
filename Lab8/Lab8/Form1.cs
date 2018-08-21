using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        public string fileName;
        public int interval;
        public ArrayList pictures = new ArrayList();
        public slideshow mySlideshow = new slideshow();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "JPEG Files (.jpg, .png, .bmp, .gif)|*.jpg;*.gif;*.png;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (String file in open.FileNames)
                    {
                        currentFileListBox.Items.Add(file);
                        Image newImage = Image.FromFile(Path.GetFullPath(file));
                        pictures.Add(newImage);
                    }
                }
                catch
                {
                    MessageBox.Show("Not a valid file.");
                    foreach (String file in open.FileNames)
                    {
                        currentFileListBox.Items.Remove(file);
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < currentFileListBox.Items.Count; i++)
            {
                if (currentFileListBox.GetSelected(i) && (currentFileListBox.SelectedItems.Count != currentFileListBox.Items.Count))
                {
                    currentFileListBox.Items.RemoveAt(i);
                    pictures.RemoveAt(i);
                }
            }

            if (currentFileListBox.SelectedItems.Count == currentFileListBox.Items.Count)
            {
                currentFileListBox.Items.Clear();
                pictures.Clear();
            }

            pictures.TrimToSize();
        }

        private void openCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = " | *.pix";
            openFileDlg.FilterIndex = 1;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {           
                this.currentFileListBox.Items.Clear();
                pictures.Clear();

                this.fileName = openFileDlg.FileName;
                StreamReader myStreamReader = new StreamReader(openFileDlg.OpenFile());
                while (true)
                {
                    string line = myStreamReader.ReadLine();
                    string s = line;
                    if (line == null)
                        break;

                    this.currentFileListBox.Items.Add(s);
                    Image buildImage = Image.FromFile(Path.GetFullPath(s));
                    pictures.Add(buildImage);
                }

                myStreamReader.Close();
            }
        }

        private void saveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = " | *.pix";
            saveFileDlg.DefaultExt = "pix";

            if (this.currentFileListBox.Items.Count == 0)
            {
                MessageBox.Show("No file names to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.fileName == null)
                saveFileDlg.FileName = null;
            else
                saveFileDlg.FileName = this.fileName;

            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter myStreamWriter = new StreamWriter(saveFileDlg.OpenFile());

                foreach (string file in this.currentFileListBox.Items)
                {
                    myStreamWriter.WriteLine(file);
                }

                myStreamWriter.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            interval = Int32.Parse(IntervaltextBox.Text);
            mySlideshow.updatePcitures(pictures, interval);
            if (pictures.Count >= 1 && mySlideshow.interval > 0)
            {
                mySlideshow.ShowDialog();
            }
            else if (pictures.Count == 0)
            {
                MessageBox.Show("No images to show.");
            }
            else if (mySlideshow.interval <= 0)
            {
                MessageBox.Show("Please enter a integer time interval > 0");
            }
        }

        private void IntervaltextBox_TextChanged(object sender, EventArgs e)
        {
            interval = Int32.Parse(IntervaltextBox.Text);
            this.Invalidate();
        }

    }
}
