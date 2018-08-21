using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public byte[] keyVal = new byte[8];

        public Form1()
        {
            InitializeComponent();
        }

        private void fileBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            //if user presses "OK", fill in text box with chosen file
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.fileNameTextBox.Text = openFile.FileName;
            }

        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            //check for valid string in key text box
            if (this.keyTextBox.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check for valid string in file text box
            if (fileNameTextBox.Text == "")
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else //encrypt file
            {
                //set key value from text box
                int  index = 0;
                for (int i = 0; i < keyTextBox.Text.Length; i++)
                {
                    keyVal[index] = (byte)(keyVal[index] + (byte)this.keyTextBox.Text[i]);
                    index = ((index + 1) % 8);
                }

                string checkFile = string.Concat(fileNameTextBox.Text, ".des");
                if(File.Exists(checkFile))//see if you will be overwriting a file
                {
                    if (MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }
                
                encryptFile(fileNameTextBox.Text, checkFile, keyVal, keyVal);
            }
            
        }

        public void encryptFile(string inFile, string outFile, byte[] destKey, byte[] desIV)
        {
            FileStream inStream = null;
            FileStream outStream = null;

            try
            {
                //create file streams for encryption
                inStream = new FileStream(inFile, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(outFile, FileMode.OpenOrCreate, FileAccess.Write);
                outStream.SetLength((long)0);
            }
            catch
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //close streams when error/necessary
                if (inStream != null)
                {
                    inStream.Close();
                }
                if (outStream != null)
                {
                    outStream.Close();
                }
                return;
            }

            //read/write vairables (based on example from https://msdn.microsoft.com/en-us/library/system.security.cryptography.descryptoserviceprovider(v=vs.110).aspx)
            byte[] dataArray = new byte[100];
            long readBytes = (long)0;
            long sizeBytes = inStream.Length;

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(outStream, des.CreateEncryptor(keyVal, keyVal), CryptoStreamMode.Write);

            //encrypt file
            while (readBytes < sizeBytes)
            {
                int writeBytes = inStream.Read(dataArray, 0, 100);
                encStream.Write(dataArray, 0, (int)writeBytes);
                readBytes = readBytes + writeBytes;
            }

            //close all streams
            encStream.Close();
            inStream.Close();
            outStream.Close();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        { 
            //check for valid string in key text box
            if (this.keyTextBox.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check for valid string in file text box
            if (fileNameTextBox.Text == "" || (!fileNameTextBox.Text.EndsWith(".des")))
            {
                MessageBox.Show("Not a .des file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else //encrypt file
            {
                //set key value from text box
                int index = 0;
                for (int i = 0; i < keyTextBox.Text.Length; i++)
                {
                    keyVal[index] = (byte)(keyVal[index] + (byte)this.keyTextBox.Text[i]);
                    index = ((index + 1) % 8);
                }

                string checkFile = fileNameTextBox.Text.Remove(fileNameTextBox.Text.Length - 3);
                if (File.Exists(checkFile))//see if you will be overwriting a file
                {
                    if (MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }

                decryptFile(fileNameTextBox.Text, checkFile, keyVal, keyVal);
            }

        }

        private void decryptFile(string inFile, string outFile, byte[] destKey, byte[] desIV)
        {
            FileStream inStream = null;
            FileStream outStream = null;

            try
            {
                //create file streams for decryption
                inStream = new FileStream(inFile, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(outFile, FileMode.OpenOrCreate, FileAccess.Write);
                outStream.SetLength((long)0);
            }
            catch
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //close streams when error/necessary
                if (inStream != null)
                {
                    inStream.Close();
                }
                if (outStream != null)
                {
                    outStream.Close();
                }
                return;
            }

            //read/write vairables (based on example from https://msdn.microsoft.com/en-us/library/system.security.cryptography.descryptoserviceprovider(v=vs.110).aspx)
            byte[] dataArray = new byte[100];
            long readBytes = (long)0;
            long sizeBytes = inStream.Length;

            DES des = new DESCryptoServiceProvider();
            CryptoStream decStream = new CryptoStream(outStream, des.CreateDecryptor(keyVal, keyVal), CryptoStreamMode.Write);

            //decrypt file
            try
            {
                while (readBytes < sizeBytes)
                {
                    int writeBytes = inStream.Read(dataArray, 0, 100);
                    decStream.Write(dataArray, 0, (int)writeBytes);
                    readBytes = readBytes + writeBytes;
                }
                decStream.Close();
            }

            //error if can not decrypt
            catch
            {
                MessageBox.Show("Bad key or file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                File.Delete(outFile); //delete failed decryption file

                //close streams
                inStream.Close();
                outStream.Close();
                return;
            }

        }
    }

}
