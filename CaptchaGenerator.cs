using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

/// <summary>
/// Summary description for CaptchaGenerator
/// </summary>
public class CaptchaGenerator
{
    Random r = new Random();
	public CaptchaGenerator()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string GetRandomCode()
    {
        string code;
        char c1 = Convert.ToChar(r.Next(65, 72));
        char c2 = Convert.ToChar(r.Next(66, 80));
        char c3 = Convert.ToChar(r.Next(49, 57));
        char c4 = Convert.ToChar(r.Next(65, 85));
        char c5 = Convert.ToChar(r.Next(66, 90));
        char c6 = Convert.ToChar(r.Next(55, 57));
        char c7 = Convert.ToChar(r.Next(65, 75));
        // Generating the random Length of Code
        int CodeLength = r.Next(4,8);
        if(CodeLength==4)
        code = "" + c1 + c2 + c3 + c6;
        else if(CodeLength==5)
            code = "" + c1 + c2 + c3 + c5 + c6;
        else if(CodeLength==6)
            code = "" + c2 + c3 + c4 + c5 + c6 + c7;
        else
            code = "" + c1 + c2 + c4 + c5 + c6 + c4 + c7;
        return code;
    }

   
    private Bitmap CreateImage(string ImageText, int ImageWidth, int ImageHeight)
    {
        Bitmap bm = new Bitmap(ImageWidth,ImageHeight);
        // Genereting Random Font Family
        string[] FontFamily = new string[] { "Dotum", "Arial", "Times New Roman", "Verdana", "Forte" };
        int FontNo=r.Next(0,4);
        Font f = new Font(FontFamily[FontNo],(ImageWidth/6) , FontStyle.Regular, GraphicsUnit.Pixel);
        Graphics g = Graphics.FromImage(bm);
        g.Clear(Color.Silver);
        Pen GoldenPen = new Pen(Color.FromArgb(150, 10, 10), 6);
      //  g.DrawRectangle(GoldenPen, 0, 0,ImageWidth,ImageHeight);
        Pen BlackPen = new Pen(Color.FromArgb(0, 0,0), 1);
        int[] h = new int[] { 15,17,22,7,15,37,16,20,25,27,31,20,10,25,5};
        int[] w = new int[] {15,17,25,40,40,65,100,101,130,132,140,143,140,135,150};
        Point[] pt = new Point[h.Length];
        for(int i=0;i<h.Length;i++)
        {
            int j = r.Next(0, h.Length);
            pt[i]=new Point(w[i],h[j]);
        };
        g.DrawCurve(BlackPen, pt);
        int ind = 0, YPosition=0 ;
        for (int i = 21; i <= ImageText.Length*21; i+=19)
        { 
            if(i<=ImageText.Length*10)
                YPosition = (ind * 2) + 2;
            else
                YPosition = YPosition - 2;
            g.DrawString(ImageText[ind].ToString(), f, new SolidBrush(System.Drawing.Color.Navy), i, YPosition, StringFormat.GenericDefault);
            ind++;
        } 
        g.Flush();
        return bm;
    }
 public string[]  GenerateCaptchaImage(string FolderNameWithPath,int ImageWidth,int ImageHeight)
    {
        string mycaptchacode = GetRandomCode();
        Bitmap b = CreateImage(mycaptchacode,ImageWidth,ImageHeight);
        string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".jpg";
     if(!Directory .Exists(HttpContext.Current.Server.MapPath(FolderNameWithPath )))
     {
         Directory .CreateDirectory (HttpContext.Current.Server.MapPath(FolderNameWithPath ));
     }
     b.Save(HttpContext.Current.Server.MapPath(FolderNameWithPath)+"/" + fileName, ImageFormat.Jpeg);
     string FileNameWithPath = FolderNameWithPath + "/" + fileName;
     string[] FileNameAndCaptchaCode = new string [2];
     FileNameAndCaptchaCode[0] = FileNameWithPath;
     FileNameAndCaptchaCode[1] = mycaptchacode;
     return FileNameAndCaptchaCode;
    }
}