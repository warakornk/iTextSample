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
                case RefLocalFont.CordiaNew:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "cordia.ttc"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.MaterialSymbolsRounded:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "MaterialSymbolsRounded.woff2"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.THCharmonman:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "TH Charmonman.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.THCharmonmanBold:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "TH Charmonman Bold.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.THSarabun:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.THSarabunItalic:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun Italic.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.THSarabunBold:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun Bold.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.THSarabunBoldItalic:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun Bold Italic.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.Webdings:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "webdings.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.Wingding:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "wingding.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.Wingdng2:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "WINGDNG2.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                case RefLocalFont.Wingdng3:
                    pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "WINGDNG3.ttf"), PdfEncodings.IDENTITY_H);
                    break;

                default:
                    //pdfFont = PdfFontFactory.CreateFont(System.IO.Path.Combine(fontPath, "THSarabun.ttf"), PdfEncodings.IDENTITY_H);
                    break;
            }

            return pdfFont;
        }
    }
}