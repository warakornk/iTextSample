using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iTextSample.Enums;
using iTextSample.Services.Helper;
using iTextSample.Services.Interface;

namespace iTextSample.Services
{
    public class PdfService : IPdfService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILocalFont _localFont;

        public PdfService(IWebHostEnvironment environment, ILocalFont localFont)
        {
            _environment = environment;
            _localFont = localFont;
        }

        /// <summary>
        /// Create sample pdf file and add a paragraph. Then save to output folder.
        /// </summary>
        public Task<string> Function_01()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(dest);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            //Add paragraph to the document
            document.Add(new Paragraph("Hello Pdf World!"));
            //Close document
            document.Close();

            return Task.FromResult(saveFileName);
        }

        /// <summary>
        /// Create sample pdf file and add custom font and add a paragraph. Then save to output folder.
        /// </summary>
        public Task<string> Function_02()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Set local font to document level
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            // Add content -----------------------------------------------------
            document.Add(new Paragraph("Hello Pdf World! ข้อความนี้เป็นส่วนที่แสดงผลภาษาไทย จาก font Th SarabunPSK"));

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }

        /// <summary>
        /// Create sample pdf file and set font size
        /// </summary>
        /// <returns></returns>
        public Task<string> Function_03()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            // Set font size must use float number
            // This set at document level
            document.SetFontSize((float)RefFontSize.Normal);

            // Add content -----------------------------------------------------
            document.Add(new Paragraph("Hello Pdf World! ข้อความนี้เป็นส่วนที่แสดงผลภาษาไทย จาก font Th SarabunPSK และกำหนดขนาดของตัวอักษร ที่ 16 point จากการกำหนดระดับเอกสาร"));

            // Set font size at paragraph
            document.Add(new Paragraph("This is bigger font and set at this text only. นี่เป็นข้อความที่กำหนดขนาดตัวอักษรใหญ่ขึ้น และมีผลกับข้อความนี้เท่านั้น")
                                        .SetFontSize((float)RefFontSize.Header2));

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }
    }
}