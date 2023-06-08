using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
            PdfFont thaiFont2 = _localFont.GetFont(RefLocalFont.THCharmonman);

            document.SetFont(thaiFont);

            // Add content -----------------------------------------------------
            document.Add(new Paragraph("Hello Pdf World! ข้อความนี้เป็นส่วนที่แสดงผลภาษาไทย จาก font Th SarabunPSK"));
            // Add content with other font -------------------------------------
            document.Add(new Paragraph("This paragraph set to other font ข้อความนี้กำหนดฟอร์นที่ต่างออกไป")
                                    .SetFont(thaiFont2));

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

        /// <summary>
        /// Create sample pdf with text alignment
        /// </summary>
        /// <returns></returns>
        public Task<string> Function_04()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            // Be careful alignment will confuse between SetHorizontalAlignment and SetTextAlignment
            // Default Alignment or Left
            document.Add(new Paragraph("This is default alignment นี่คือการจัดชิดขอบปกติ"));
            // Set alignment to left
            document.Add(new Paragraph("This is left alignment นี่คือการจัดชิดขอบซ้าย").SetTextAlignment(TextAlignment.LEFT));
            // Set alignment to center
            document.Add(new Paragraph("This is center alignment นี่คือการจัดตรงกลาง").SetTextAlignment(TextAlignment.CENTER));
            // Set alignment to right
            document.Add(new Paragraph("This is right alignment นี่คือการจัดชิดขอบขวา").SetTextAlignment(TextAlignment.RIGHT));
            // Set alignment to justified
            string sampleText = "This is sample text to set justified alignment. You can use a lot of sample text to view this justified. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. และส่วนนี้เป็นการจัดชิดขอบซ้ายขวาในข้อความภาษาไทย ธุหร่ำโมเดลวาไรตี้สัมนา แพนงเชิญฮัลโลวีนซัพพลายแอร์แจ๊กพอต โฟล์ค สป็อตโปรเจกเตอร์ธุหร่ำขั้นตอนเอสเพรสโซ วีซ่า ไฮไลท์คาร์วัจนะมั้ง เปียโนเซ็กซี่โปรเจ็กเตอร์โลชั่น ป่าไม้ยูโรแจ๊กพอตพลาซ่า เรตอุด้ง เกรย์แมชชีนบาลานซ์ไบโออึ๋ม ออสซี่ควิกโปรเจ็คเซ็กส์หลวงพี่ สะเด่าสังโฆ เจลแม่ค้า สปาอพาร์ตเมนต์โปสเตอร์แดนซ์ แตงโมนินจาแอร์ธัมโมเพลย์บอย สแตนเลสบร็อคโคลีแทงโก้จึ๊กเบอร์เกอร์\r\nเพรียวบางไฮเทค สตรอเบอรี ต่อยอด เอเซียไฮเอนด์ รุมบ้าแคปเทรลเลอร์น้องใหม่รีสอร์ต มิลค์ออสซี่ไอเดียเซ็กส์มาราธอน ศิลปวัฒนธรรม ฮองเฮาโปรดักชั่นเอ็กซ์โปสแตนเลส พอเพียงเทียมทานคอนเซปต์ ออดิชั่นตัวเอง ออสซี่ มายาคติแชมเปญรีพอร์ทรีโมตซูชิ แทกติคแลนด์โหงวเฮ้ง ตัวเองเยลลี่ มินท์เดชานุภาพ ยากูซ่า\r\nสเกตช์เวิร์กช็อปเลกเชอร์แอดมิชชั่น ซานตาคลอสพาสตาเช็งเม้งละตินบึม คอนแท็คม้านั่งแตงโมหมวยซีอีโอ ราเมนออยล์เพียบแปร้เวิร์กช็อป มอนสเตอร์ลอจิสติกส์โปรแรลลี่ บอร์ดทีวีตังค์ วาซาบิแต๋วแคทวอล์คอันตรกิริยาสเปค บูติกบาร์บีคิวเบลอเบิร์นสหัสวรรษ โก๊ะเวณิกาลาตินคอมพ์ โครนาบู๊แฟรนไชส์ว้าวฟรุต จิ๊กโก๋ปิโตรเคมี ปิยมิตรล็อบบี้แมกกาซีน เช็งเม้งช็อป สตรอว์เบอร์รี ถูกต้องสเตชัน มาร์ชอวอร์ดซัพพลายเก๋ากี้\r\nฮาโลวีนเลคเชอร์เมเปิลเมาท์ ยูวีก่อนหน้าสตีลวาทกรรม แพตเทิร์นม็อบ แบดวโรกาสแม็กกาซีนบัสลิมิต ไวกิ้งซูเปอร์โดมิโนแอ็กชั่น เที่ยงวันเรซิ่นวอลล์พันธุวิศวกรรม แชมเปญมอยส์เจอไรเซอร์เวณิกา คาร์สันทนาการ ซาตานโลโก้รากหญ้าเซอร์วิสเจ็ต อัลบัมพอเพียงเฟรชมาร์กปอดแหก แต๋วอันเดอร์ฮัมไบโอ พริตตี้นู้ด เจ๊ อาข่าไอเดียไทม์จอหงวน บูติคเคอร์ฟิว อึ้มลอร์ดบอดี้สะบึม\r\nมิวสิคฟยอร์ดแตงโมแฟ็กซ์ คอนโดมิเนียมนพมาศฟินิกซ์ศากยบุตร เวเฟอร์ไกด์ มาร์ชผลไม้ วิลล์พุทธศตวรรษบาลานซ์ จีดีพีอาข่า มายองเนสสารขัณฑ์ ภควัมบดีโพลารอยด์ยะเยือกโซน พาร์แอปพริคอทอาร์ติสต์เวิร์คเพนตากอน แกสโซฮอล์ฮัมเจ็ต ซัมเมอร์ ยาวีจึ๊กอิเลียดมาม่า พรีเซ็นเตอร์ โรแมนติค จังโก้หลวงพี่ หมวยฟลุทเปโซ\r\n";

            document.Add(new Paragraph(sampleText).SetTextAlignment(TextAlignment.JUSTIFIED));
            document.Add(new Paragraph("----------------------------------------------------------------------------------------------------------"));
            document.Add(new Paragraph(sampleText).SetTextAlignment(TextAlignment.JUSTIFIED_ALL));

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }

        /// <summary>
        /// Create sample pdf with Indent
        /// </summary>
        /// <returns></returns>
        public Task<string> Function_05()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            // Set indent at first line
            string sampleText = "This is sample text to set Indent. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            float indentValue = 30;
            document.Add(new Paragraph(sampleText)
                                .SetFirstLineIndent(indentValue));

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }

        public Task<string> Function_06()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            //
            string sampleText = "This is sample text to set Leading. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            float fixLeadingValue = 30;
            float fixLeadingValue2 = 10;
            float multipliedLeading = (float)1.5;
            float multipliedLeading2 = (float)0.5;

            document.Add(new Paragraph(" 1 ----------------------------------------------------------------------------------------------------------"));
            document.Add(new Paragraph(sampleText).SetFixedLeading(fixLeadingValue));
            document.Add(new Paragraph(" 2 ----------------------------------------------------------------------------------------------------------"));
            document.Add(new Paragraph(sampleText).SetFixedLeading(fixLeadingValue2));
            document.Add(new Paragraph(" 3 ----------------------------------------------------------------------------------------------------------"));
            document.Add(new Paragraph(sampleText).SetMultipliedLeading(multipliedLeading));
            document.Add(new Paragraph(" 4 ----------------------------------------------------------------------------------------------------------"));
            document.Add(new Paragraph(sampleText).SetMultipliedLeading(multipliedLeading2));

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }

        /// <summary>
        ///  Sample create pdf with list
        /// </summary>
        /// <returns></returns>
        public Task<string> Function_07()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            // Set list
            document.Add(new Paragraph("This part will set list to pdf ส่วนต่อไปนี้เป็นการเพิ่ม list เข้าในไฟล์ pdf"));
            // create a list
            List list = new List();

            list.Add("JavaScript");
            list.Add("C#");
            list.Add("Java");
            list.Add("Python");
            list.Add("Vue");

            document.Add(list);

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }

        /// <summary>
        ///  Sample create pdf list and custom symbol of list
        /// </summary>
        /// <returns></returns>
        public Task<string> Function_08()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            // Set list
            document.Add(new Paragraph("This part will set list to pdf and set custom symbol ส่วนต่อไปนี้เป็นการเพิ่ม list เข้าในไฟล์ pdf พร้อมกำหนดสัญลักษณ์ที่กำหนด"));
            // create a list with custom symbol
            // List shoud add new Text with hexa value and set font of that text then add to SetListSymbol function
            // Symbol code can see value in MS Word by add symbol
            PdfFont symbolFont = _localFont.GetFont(RefLocalFont.Webdings);
            List list = new List().SetListSymbol(new Text("\u0034").SetFont(symbolFont));

            list.Add("JavaScript");
            list.Add("C#");
            list.Add("Java");
            list.Add("Python");
            list.Add("Vue");

            document.Add(list);

            // Custom symbol from Google Material symbol Rounded
            // Reference: https://fonts.google.com/icons?selected=Material+Symbols+Rounded:network_intelligence_history:FILL@0;wght@400;GRAD@0;opsz@48&query=Symbol&icon.style=Rounded&icon.platform=web
            document.Add(new Paragraph("This is google font with download to project and use code point from web ส่วนนี้เป็นการใช้ google font โดย download เข้ามาในโปรเจค และใช้ code poit ในหน้าเว็บ"));
            PdfFont symbolFont2 = _localFont.GetFont(RefLocalFont.MaterialSymbolsRounded);

            List list2 = new List().SetListSymbol(new Text("\xe3e7").SetFont(symbolFont2));

            list2.Add("JavaScript");
            list2.Add("C#");
            list2.Add("Java");
            list2.Add("Python");
            list2.Add("Vue");

            document.Add(list2);

            // Add indent to list
            document.Add(new Paragraph("This is set space from symbol to text"));
            List list3 = new List().SetListSymbol(new Text("\xe3e7").SetFont(symbolFont2)).SetSymbolIndent(20);

            list3.Add("JavaScript");
            list3.Add("C#");
            list3.Add("Java");
            list3.Add("Python");
            list3.Add("Vue");

            document.Add(list3);

            // Add ordered list
            document.Add(new Paragraph("This is set orderd"));
            List list4 = new List(ListNumberingType.DECIMAL);

            list4.Add("JavaScript");
            list4.Add("C#");
            list4.Add("Java");
            list4.Add("Python");
            list4.Add("Vue");

            document.Add(list4);

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }

        /// <summary>
        /// Sample create table
        /// </summary>
        /// <returns></returns>
        public Task<string> Function_09()
        {
            string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
            string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
            string dest = System.IO.Path.Combine(destinationPath, saveFileName);

            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

            document.SetFont(thaiFont);

            document.Add(new Paragraph("This is sample table with 3 column and fix width. นี่เป็นตัวอย่างตารางที่กำหนด 3 คอลัมน์และกำหนดความกว้างตายตัว"));

            // Create table from basic 3 column
            float[] pointColumnWidths = { 150F, 150F, 150F };
            Table table1 = new Table(pointColumnWidths);

            // Header cells this row will replete every page
            Cell cell1_1 = new Cell().Add(new Paragraph("Name").SetBold());
            Cell cell1_2 = new Cell().Add(new Paragraph("Surname").SetBold());
            Cell cell1_3 = new Cell().Add(new Paragraph("Age").SetBold());

            table1.AddHeaderCell(cell1_1);
            table1.AddHeaderCell(cell1_2);
            table1.AddHeaderCell(cell1_3);

            // Data cells row 1
            Cell cell2_1 = new Cell().Add(new Paragraph("John"));
            Cell cell2_2 = new Cell().Add(new Paragraph("Freeman"));
            Cell cell2_3 = new Cell().Add(new Paragraph("23"));

            table1.AddCell(cell2_1);
            table1.AddCell(cell2_2);
            table1.AddCell(cell2_3);

            // Data cells row 2
            Cell cell3_1 = new Cell().Add(new Paragraph("Mata"));
            Cell cell3_2 = new Cell().Add(new Paragraph("Smith"));
            Cell cell3_3 = new Cell().Add(new Paragraph("20"));

            table1.AddCell(cell3_1);
            table1.AddCell(cell3_2);
            table1.AddCell(cell3_3);

            document.Add(table1);

            // -----------------------------------------------------
            document.Close();

            return Task.FromResult(saveFileName);
        }
    }
}