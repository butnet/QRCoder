using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QRCoder;

namespace QRCoderDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            renderQRCode();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            renderQRCode();
        }

        private void renderQRCode()
        {


            PayloadGenerator.WiFi wif = new PayloadGenerator.WiFi("Bundesnachrichtendienst", "2059006314870057", PayloadGenerator.WiFi.Authentication.WPA);
            textBoxQRCode.Text = wif.ToString();

            PayloadGenerator.Bookmark bk = new PayloadGenerator.Bookmark("http://code-bude.net", "Bester Blog!");
            textBoxQRCode.Text = bk.ToString();

            PayloadGenerator.Mail mail = new PayloadGenerator.Mail("webmaster@code-bude.net", "Toller, Blog", "Wie findeste den, denn?", PayloadGenerator.Mail.MailEncoding.MATMSG);
            textBoxQRCode.Text = mail.ToString();

            PayloadGenerator.PhoneNumber phone = new PayloadGenerator.PhoneNumber("01738830283");
            textBoxQRCode.Text = phone.ToString();

            PayloadGenerator.SMS sms = new PayloadGenerator.SMS("01738830283", ":Jalo, was geht ba?", PayloadGenerator.SMS.SMSEncoding.SMS);
            textBoxQRCode.Text = sms.ToString();

            PayloadGenerator.MMS mms = new PayloadGenerator.MMS("01738830283", ":Jalo, was geht ba?");
            textBoxQRCode.Text = mms.ToString();

            PayloadGenerator.Geolocation geo = new PayloadGenerator.Geolocation("51.9183534", "10,4302185", PayloadGenerator.Geolocation.GeolocationEncoding.GoogleMaps);
            textBoxQRCode.Text = geo.ToString();


            string level = comboBox1.SelectedItem.ToString();
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(textBoxQRCode.Text, eccLevel);
            pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20);
        }
    }
}
