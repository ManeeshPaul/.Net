﻿using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using System.Text;

namespace DemoITextModification
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            string inputpdfPath = "SampleDemo.pdf";
            string outputpdfPath = "outputSampleDemo.pdf";
            

            //PdfReader pdfReader = new PdfReader(inputpdfPath);        //withou encryption password
            PdfReader pdfReader = new PdfReader(inputpdfPath, new ReaderProperties().SetPassword(Encoding.UTF8.GetBytes("owner123")));
            PdfWriter pdfWriter = new PdfWriter(outputpdfPath);
            PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter);

            int numberOfPages = pdfDocument.GetNumberOfPages();

            for (int i = 1; i <= numberOfPages; i++)
            {
                PdfPage page = pdfDocument.GetPage(i);
                Rectangle pageSize = page.GetPageSize();

                PdfCanvas canvas = new PdfCanvas(page);
                string text = "Modified Sample Added by Maneesh";
                float x = pageSize.GetWidth() / 2;
                float y = pageSize.GetHeight() / 2;

                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 12).
                    MoveText(x, y).ShowText(text).EndText();

            }
            pdfDocument.Close();
        }
    }
}