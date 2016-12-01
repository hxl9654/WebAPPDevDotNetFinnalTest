using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

public class CAPTCHA
{
    public string CreatRandomString(int lenth = 4)
    {
        char[] CAPTCHA = new char[lenth];
        string BaseString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        for (int i = 0; i < lenth; i++)
            CAPTCHA[i] = BaseString.ToCharArray()[random.Next(0, BaseString.Length)];
        return new string(CAPTCHA);
    }
    public System.IO.MemoryStream CreatCAPTCHAImage(string CAPTCHAString)
    {
        Bitmap image = new Bitmap(CAPTCHAString.Length * 25, 40);
        Graphics graphics = Graphics.FromImage(image);
        Font font = new Font("Arial", 25, FontStyle.Bold);
        Brush brush = new SolidBrush(Color.Black);
        graphics.Clear(Color.White);        

        Pen pen = new Pen(Color.Black, 0);
        Random rand = new Random();
        for (int i = 0; i < 30; i++)
            graphics.DrawLine(pen, rand.Next(0, CAPTCHAString.Length * 25), rand.Next(40), rand.Next(0, CAPTCHAString.Length * 25), rand.Next(40));
        for (int i = 0; i < 5000; i++)
            image.SetPixel(rand.Next(0, CAPTCHAString.Length * 25), rand.Next(40), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255)));
        graphics.DrawString(CAPTCHAString, font, brush, 5, 3);
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms;
    }
}