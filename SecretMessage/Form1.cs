using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Collections;
using System.Security.Cryptography;
using System.Collections;

namespace SecretMessage
{
    public partial class Form1 : Form
    {
        delegate void UpdateFormDelegate(object function, object data);
        UpdateFormDelegate updateFormDelegate;
        Thread workThread;
        string path;
        string type;
        string _eof = "011812b5b3894bab9d87943545ad6aac";
        string _eot = "356b17d134074f5589303771002e5f8e";
        string outDir;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateFormDelegate = new UpdateFormDelegate(updateForm);
        }

        private byte[] stringToUnicodeByteArray(string text)
        {
            Encoding unicode = Encoding.Unicode;
            return unicode.GetBytes(text);
        }

        private void updateForm(object function, object data)
        {
            switch ((int)function)
            {
                case -1:
                    //txtResult.Text = "";
                    break;
                case 0:
                    // setControlsEnabled((bool)data);
                    progressBar.Value = (int)data;
                    break;
                case 1:
                    txtMessage.Text = (string)data;
                    break;
            }
        }

        private void crossThreadUpdate(object function, object data)
        {
            try
            {
                this.Invoke(updateFormDelegate, new object[] { function, data });
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.png;";
            openFileDialog1.Title = "Select an image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
            else
                return;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (workThread != null && workThread.IsAlive == true)
            {
                System.Windows.Forms.MessageBox.Show("I am busy. Try again in a moment.");
                return;
            }
            if (!File.Exists(txtFile.Text))
            {
                System.Windows.Forms.MessageBox.Show("I can't open that file.");
                return;
            }
            if (cbUseEncryption.Checked && String.IsNullOrEmpty(txtEncryption.Text))
            {
                System.Windows.Forms.MessageBox.Show("Provide an encryption key or uncheck use encryption.");
                return;
            }
            FileInfo fileInfo = new FileInfo(txtFile.Text);
            path = fileInfo.DirectoryName;
            type = fileInfo.Extension;
            if (type != ".png")
            {
                System.Windows.Forms.MessageBox.Show("Only .png files are supported.");
                return;
            }

            outDir = fileInfo.Directory.FullName;

            if (rbEncode.Checked)
                runEncode();
            else
                runDecode();
        }

        private void runEncode()
        {
            if (rbMessage.Checked)
            {
                if (txtMessage.Text.Length == 0)
                {
                    System.Windows.Forms.MessageBox.Show("There is no message.");
                    return;
                }
            }
            else
            {
                if (!File.Exists(txtEmbedFile.Text))
                {
                    System.Windows.Forms.MessageBox.Show("There is no file to embed.");
                    return;
                }
            }

            workThread = new Thread(new ThreadStart(encode));
            workThread.IsBackground = true;
            workThread.Start();
        }

        private void runDecode()
        {
            txtMessage.Text = "processing...";
            workThread = new Thread(new ThreadStart(decode));
            workThread.IsBackground = true;
            workThread.Start();
        }

        private void updatePB(int value)
        {
            value = value < 0 ? 0 : value;
            value = value > 100 ? 100 : value;
            crossThreadUpdate(0, value);
        }

        private int getAvailableBytes(int imageHeight, int imageWidth)
        {
            return Convert.ToInt32(Math.Floor((double)imageHeight * imageWidth * 3 / 8));
        }

        private bool sizeCheck(string text, int imageHeight, int imageWidth)
        {
            int availableBytes = getAvailableBytes(imageHeight, imageWidth);
            int usedBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(text);
            return sizeCheck(availableBytes, usedBytes);
        }

        private bool sizeCheck(int availableBytes, int usedBytes)
        {
            bool willFit = availableBytes > usedBytes;
            if (willFit)
                return true;
            System.Windows.Forms.MessageBox.Show("Your message is too big. The picture can fit " + availableBytes + " bytes but your message is " + usedBytes + " bytes.");
            return false;
        }

        private int getLeastSignificantDigit(int value)
        {
            while (value >= 100)
                value -= 100;
            while (value >= 10)
                value -= 10;
            return value;
        }

        private int convertPixel(int color, bool bit)
        {
            int origColor = color;
            color = getLeastSignificantDigit(color);
            if ((!bit && color % 2 != 0) || (bit && color % 2 == 0))
                origColor = origColor != 255 ? origColor + 1 : origColor - 1;
            return origColor;
        }

        private bool getPixelBit(int color)
        {
            color = getLeastSignificantDigit(color);
            return color % 2 == 0 ? false : true;
        }

        private void encode()
        {
            try
            {
                Bitmap image;
                bool doSave = true;
                using (FileStream stream = new FileStream(txtFile.Text, FileMode.Open, FileAccess.ReadWrite))
                {
                    image = new Bitmap(stream);
                    int h = image.Height;
                    int w = image.Width;
                    string eof = cbUseEncryption.Checked ? txtEncryption.Text : _eof;
                    string text;
                    BitArray bitArray;
                    bool run = true;
                    if (rbMessage.Checked)
                    {
                        text = Crypto.EncryptStringAES(txtMessage.Text, eof);
                        bitArray = new BitArray(stringToUnicodeByteArray(text + eof));
                        if (!sizeCheck(text, h, w))
                            run = false;
                    }
                    else
                    {
                        List<byte> _bytes = new List<byte>();

                        byte[] fileBytes = File.ReadAllBytes(txtEmbedFile.Text);
                        _bytes.AddRange(stringToUnicodeByteArray((new FileInfo(txtEmbedFile.Text)).Extension + "." + fileBytes.Length + "." + _eot));
                        _bytes.AddRange(fileBytes);
                        _bytes.AddRange(stringToUnicodeByteArray(eof));
                        bitArray = new BitArray(_bytes.ToArray());
                        int usedBytes = bitArray.Length * 8;
                        if (!sizeCheck(getAvailableBytes(h, w), usedBytes))
                            return;
                    }

                    if (run)
                    {
                        int pos = 0;
                        bool end = false;
                        double numDone = 0;

                        double tot = bitArray.Length;
                        for (int row = 0; row < h; row++)
                        {
                            for (int col = 0; col < w; col++)
                            {
                                Color c = image.GetPixel(col, row);
                                int r = 0;
                                int g = 0;
                                int b = 0;

                                numDone += 3;
                                updatePB(Convert.ToInt32(numDone / tot * 100));
                                //bool doBreak = false;
                                if (pos < bitArray.Length)
                                    r = convertPixel(c.R, bitArray.Get(pos++));
                                if (pos < bitArray.Length)
                                    g = convertPixel(c.G, bitArray.Get(pos++));
                                if (pos < bitArray.Length)
                                    b = convertPixel(c.B, bitArray.Get(pos++));
                                else
                                    //doBreak = true;
                                    end = true;

                                image.SetPixel(col, row, Color.FromArgb(c.A, r, g, b));
                                //image.SetPixel(col, row, Color.FromArgb(c.A, 255, 0,0));

                                if (end)
                                    break;
                            }
                            if (end)
                                break;
                            Thread.Sleep(1);
                        }
                    }
                    else
                        doSave = false;
                }
                if (doSave)
                {
                    image.Save(outDir +  "/encoded" + type);
                    updatePB(100);
                    Thread.Sleep(750);
                }
                crossThreadUpdate(1, "ENCODE COMPLETE!");
                updatePB(0);
            }
            catch (Exception ex)
            {
                updatePB(0);
                crossThreadUpdate(1, "ERROR: " + ex.Message);
            }
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        private void decode()
        {
            try
            {
                bool wasDecodeMessage = rbMessage.Checked;
                using (FileStream stream = new FileStream(txtFile.Text, FileMode.Open, FileAccess.ReadWrite))
                {
                    Bitmap image = new Bitmap(stream);
                    string eof = cbUseEncryption.Checked ? txtEncryption.Text : _eof;
                    int h = image.Height;
                    int w = image.Width;
                    int pos = 0;
                    BitArray bits = new BitArray(image.Height * image.Width * 3);
                    double tot = h * w;
                    double numDone = 0;
                    for (int row = 0; row < h; row++)
                    {
                        for (int col = 0; col < w; col++)
                        {
                            numDone++;
                            updatePB(Convert.ToInt32(numDone / tot * 100));
                            Color c = image.GetPixel(col, row);
                            bits.Set(pos++, getPixelBit(c.R));
                            bits.Set(pos++, getPixelBit(c.G));
                            bits.Set(pos++, getPixelBit(c.B));
                        }
                    }

                    byte[] bytes = BitArrayToByteArray(bits);
                    string message = System.Text.Encoding.Unicode.GetString(bytes);
                    if (wasDecodeMessage)
                    {
                        int size = message.Length;
                        int trim = message.Length - message.IndexOf(eof);
                        message = message.Substring(0, size - trim);
                        message = Crypto.DecryptStringAES(message, eof);
                        crossThreadUpdate(1, message);
                    }
                    else
                    {
                        string fileInfoTag = message.Substring(0, message.IndexOf(_eot) + _eot.Length);
                        int fileInfoTagLength = stringToUnicodeByteArray(fileInfoTag).Length;
                        string[] fileInfo = fileInfoTag.Split('.');
                        int origFileLength = Convert.ToInt32(fileInfo[2]);
                        Byte[] origFile = new Byte[origFileLength];
                        Buffer.BlockCopy(bytes, fileInfoTagLength, origFile, 0, origFileLength);
                        File.WriteAllBytes(outDir + @"/decoded." + fileInfo[1], origFile);

                        crossThreadUpdate(1, "DECODE COMPLETE!");
                    }
                    updatePB(100);

                    Thread.Sleep(750);
                    updatePB(0);
                }
            }
            catch (Exception ex)
            {
                updatePB(0);
                crossThreadUpdate(1, "ERROR: " + ex.Message);
            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void setType()
        {
            if (rbFile.Checked)
            {
                txtMessage.Enabled = false;
                txtEmbedFile.Enabled = true;
                btnSearchEmbedFile.Enabled = true;
            }
            else
            {
                txtMessage.Enabled = true;
                txtEmbedFile.Enabled = false;
                btnSearchEmbedFile.Enabled = false;
            }
        }

        private void rbMessage_CheckedChanged(object sender, EventArgs e)
        {
            setType();
        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            setType();
        }

        private void cbUseEncryption_CheckedChanged(object sender, EventArgs e)
        {
            txtEncryption.Enabled = cbUseEncryption.Checked;
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchEmbedFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtEmbedFile.Text = openFileDialog1.FileName;
            }
            else
                return;
        }

        private void rbDecode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDecode.Checked)
            {
                txtEmbedFile.Enabled = false;
                btnSearchEmbedFile.Enabled = false;
                rbFile.Enabled = false;
                rbMessage.Enabled = false;
            }
            else
            {
                rbFile.Enabled = true;
                rbMessage.Enabled = true;
                if (!rbMessage.Checked)
                {
                    txtEmbedFile.Enabled = true;
                    btnSearchEmbedFile.Enabled = true;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
