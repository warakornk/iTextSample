using iText.Kernel.Font;
using iTextSample.Enums;

namespace iTextSample.Services.Interface
{
    public interface ILocalFont
    {
        public PdfFont GetFont(RefLocalFont refLocalFont);
    }
}