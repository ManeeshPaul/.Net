using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Kernel.Exceptions;

namespace Part1_PDFManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Defining the output PDF file path and the image file path
            string outputPath = "SalesReport.pdf";
            string imagePath = "C:\\images\\sales_chart.png"; 

            try
            {
                // Creating a PdfWriter instance to write to the output file
                PdfWriter pdfWriter = new PdfWriter(outputPath);
                // Creating a PdfDocument instance
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                // Creating a Document object to add elements
                Document document = new Document(pdfDocument);

                // Adding Title to the PDF
                document.Add(new Paragraph("Monthly Sales Report")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(24)
                    .SetBold());

                // Adding Sales Info
                document.Add(new Paragraph("Total Sales: $10,000")
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.LEFT));

                // Attempt to add the image
                try
                {
                    // Creating an Image instance from the image path
                    Image img = new Image(iText.IO.Image.ImageDataFactory.Create(imagePath));
                    img.SetAutoScale(true); // Scale the image to fit
                    img.SetTextAlignment(TextAlignment.CENTER); // Center the image
                    document.Add(img); // Adding the image to the document
                }
                catch (iText.IO.Exceptions.IOException ioEx)
                {
                    Console.WriteLine($"I/O error while adding image.: {ioEx.Message}");
                }

                // Closing the Document and the PDF resources
                document.Close();
                pdfDocument.Close();
                pdfWriter.Close();

                Console.WriteLine("PDF generated successfully: " + outputPath);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.GetType()}: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
