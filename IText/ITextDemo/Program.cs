using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Text;

namespace ITextDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = "sampleDemo.pdf";

            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //initalize a pdfwriter with encription
                WriterProperties writerProps = new WriterProperties()
                    .SetStandardEncryption(
                        Encoding.UTF8.GetBytes("user123"),
                        Encoding.UTF8.GetBytes("owner123"),
                        EncryptionConstants.ALLOW_PRINTING,
                        EncryptionConstants.ENCRYPTION_AES_256
                    );

                //Intilize a new pdf document
                PdfWriter writer = new PdfWriter(fs, writerProps);
                PdfDocument pdfDocument = new PdfDocument(writer);

                //Intilize a document for layout
                Document document = new Document(pdfDocument);

                //Add a sample paragraph
                // Add a sample paragraph
                document.Add(new Paragraph("Encripted Document").SetFontSize(18).SetBold());
                document.Add(new Paragraph("This is a pdf document"));
                document.Add(new Paragraph("Content Section").SetFontSize(14).SetBold());
                document.Add(new Paragraph("you can copy and print this document"));
                //Adding a grid format in pdf

                Table table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();// 3 columns with equal width

                //table.AddHeaderCell("ID").SetBackgroundColor(ColorConstants.YELLOW);
                table.AddHeaderCell(new Cell().Add(new Paragraph("ID").SetBackgroundColor(ColorConstants.YELLOW)));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Employee Name").SetBackgroundColor(ColorConstants.YELLOW)));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Salary").SetBackgroundColor(ColorConstants.YELLOW)));


                table.AddCell("1");
                table.AddCell("Maneesh Paul");
                table.AddCell("1000");

                table.AddCell("2");
                table.AddCell("Virat Kholi");
                table.AddCell("2000");

                table.AddCell("3");
                table.AddCell("Arun");
                table.AddCell("3000");

                document.Add(table);


                //adding image
                Image img = new Image(ImageDataFactory.Create("free-nature-images.jpg"));
                img.SetMaxWidth(200);
                img.SetMaxHeight(200);
                document.Add(img);


                document.Close();

            }
            Console.WriteLine("pdf is created !!");
        }
    }
}