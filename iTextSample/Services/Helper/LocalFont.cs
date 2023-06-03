using iText.IO.Font;
using iText.Kernel.Font;
using iTextSample.Enums;
using iTextSample.Services.Interface;

namespace iTextSample.Services.Helper
{
    public class LocalFont : ILocalFont
    {
        private readonly IWebHostEnvironment _environment;

        public LocalFont(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public PdfFont GetFont(RefLocalFont refLocalFont)
        {
            string fontPath = System.IO.Path.Combine(_environment.ContentRootPath, "Assets/Fonts");
            PdfFont pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun.ttf"), PdfEncodings.IDENTITY_H);

            switch (refLocalFont)
            {
                case RefLocalFont.THSarabun:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                default:
                    // pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun.ttf"), PdfEncodings.IDENTITY_H);
                    break;
            }

            return pdfFont;
        }
    }
}