using iText.Bouncycastle.X509;
using iText.Commons.Bouncycastle.Cert;
using iText.Forms;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Layer;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Utils;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Signatures;
using iTextSample.Enums;
using iTextSample.Models;
using iTextSample.Services.Helper;
using iTextSample.Services.Interface;
using Microsoft.AspNetCore.Hosting;

using System.Drawing;
using System.Linq.Expressions;

namespace iTextSample.Services
{
	public class PdfService : IPdfService
	{
		private readonly IWebHostEnvironment _environment;
		private readonly ILocalFont _localFont;
		private readonly IHelper _helper;

		public PdfService(IWebHostEnvironment environment, ILocalFont localFont, IHelper helper)
		{
			_environment = environment;
			_localFont = localFont;
			_helper = helper;
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
		/// Create sample pdf with indent
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

		/// <summary>
		/// Sample text leading (space between line)
		/// </summary>
		/// <returns></returns>
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

			// Text leading
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
		/// Sample create pdf with list
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

		/// <summary>
		/// Sample table cell background color
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_10()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample table with set back gound color from iText color and custom color. นี่เป็นตัวอย่างตารางที่มีการกำหนดสีพื้นหลัง จากสีของ iText และสีที่กำหนดเอง"));

			// Prepair custom color
			iText.Kernel.Colors.Color tableBgColor = new DeviceRgb(230, 230, 230);

			// Create table from basic 3 column
			float[] pointColumnWidths = { 150F, 150F, 150F };
			Table table1 = new Table(pointColumnWidths);

			// Header cells with iText Background Color
			Cell cell1_1 = new Cell().Add(new Paragraph("Name").SetBold()).SetBackgroundColor(ColorConstants.RED);
			Cell cell1_2 = new Cell().Add(new Paragraph("Surname").SetBold()).SetBackgroundColor(ColorConstants.BLUE);
			Cell cell1_3 = new Cell().Add(new Paragraph("Age").SetBold()).SetBackgroundColor(ColorConstants.CYAN);

			table1.AddHeaderCell(cell1_1);
			table1.AddHeaderCell(cell1_2);
			table1.AddHeaderCell(cell1_3);

			// Row 1 with custom color
			Cell cell2_1 = new Cell().Add(new Paragraph("John")).SetBackgroundColor(tableBgColor);
			Cell cell2_2 = new Cell().Add(new Paragraph("Freeman")).SetBackgroundColor(tableBgColor);
			Cell cell2_3 = new Cell().Add(new Paragraph("23")).SetBackgroundColor(tableBgColor);

			table1.AddCell(cell2_1);
			table1.AddCell(cell2_2);
			table1.AddCell(cell2_3);

			// Row 2
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

		/// <summary>
		/// Sample table border
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_11()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample table border set on cell. ตัวอย่างเส้นขอบตารางกำหนดที่แต่ละช่อง"));

			// Prepair border
			Border borderDashedRed = new DashedBorder(ColorConstants.RED, 4f);
			Border borderSolidGreen = new SolidBorder(ColorConstants.GREEN, 1f);

			// Create table from basic 3 column
			float[] pointColumnWidths = { 150F, 150F, 150F };
			Table table1 = new Table(pointColumnWidths);

			// Header with no border
			Cell cell1_1 = new Cell().Add(new Paragraph("Name").SetBold()).SetBorder(Border.NO_BORDER);
			Cell cell1_2 = new Cell().Add(new Paragraph("Surname").SetBold()).SetBorder(Border.NO_BORDER);
			Cell cell1_3 = new Cell().Add(new Paragraph("Age").SetBold()).SetBorder(Border.NO_BORDER);

			table1.AddHeaderCell(cell1_1);
			table1.AddHeaderCell(cell1_2);
			table1.AddHeaderCell(cell1_3);

			// Data cells row 1 with dash border and width 4f
			Cell cell2_1 = new Cell().Add(new Paragraph("John")).SetBorder(borderDashedRed);
			Cell cell2_2 = new Cell().Add(new Paragraph("Freeman")).SetBorder(borderDashedRed);
			Cell cell2_3 = new Cell().Add(new Paragraph("23")).SetBorder(borderDashedRed);

			table1.AddCell(cell2_1);
			table1.AddCell(cell2_2);
			table1.AddCell(cell2_3);

			// Data cells row 2
			Cell cell3_1 = new Cell().Add(new Paragraph("Mata")).SetBorder(borderSolidGreen);
			Cell cell3_2 = new Cell().Add(new Paragraph("Smith")).SetBorder(borderSolidGreen);
			Cell cell3_3 = new Cell().Add(new Paragraph("20")).SetBorder(borderSolidGreen);

			table1.AddCell(cell3_1);
			table1.AddCell(cell3_2);
			table1.AddCell(cell3_3);

			document.Add(table1);

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample Separate line
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_12()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample separate line. ตัวอย่างเส้นแบ่ง"));

			// Prepair separate line
			SolidLine solidLine = new SolidLine(2f);
			DashedLine dashedLine = new DashedLine(1f);
			SolidLine solidLine1 = new SolidLine();

			solidLine.SetColor(ColorConstants.RED);
			dashedLine.SetColor(ColorConstants.GREEN);
			solidLine1.SetColor(ColorConstants.BLUE);

			LineSeparator lineSeparator1 = new LineSeparator(solidLine);
			LineSeparator lineSeparator2 = new LineSeparator(dashedLine);
			LineSeparator lineSeparator3 = new LineSeparator(solidLine1);

			// set separator width to 100 point
			lineSeparator1.SetWidth(100);

			document.Add(new Paragraph("This is solid line"));
			document.Add(lineSeparator1);
			document.Add(new Paragraph("This is dashed line"));
			document.Add(lineSeparator2);
			document.Add(new Paragraph("This is solid line with set color only"));
			document.Add(lineSeparator3);

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample Font color
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_13()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample font color. นี่เป็นตัวอย่างการกำหนดสีให้กับข้อความ"));
			// --------------------------------------------------------------------------------------------
			string sampleText = "This is sample text to set justified alignment. You can use a lot of sample text to view this justified. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. และส่วนนี้เป็นการจัดชิดขอบซ้ายขวาในข้อความภาษาไทย ธุหร่ำโมเดลวาไรตี้สัมนา แพนงเชิญฮัลโลวีนซัพพลายแอร์แจ๊กพอต โฟล์ค สป็อตโปรเจกเตอร์ธุหร่ำขั้นตอนเอสเพรสโซ วีซ่า ไฮไลท์คาร์วัจนะมั้ง เปียโนเซ็กซี่โปรเจ็กเตอร์โลชั่น ป่าไม้ยูโรแจ๊กพอตพลาซ่า เรตอุด้ง เกรย์แมชชีนบาลานซ์ไบโออึ๋ม ออสซี่ควิกโปรเจ็คเซ็กส์หลวงพี่ สะเด่าสังโฆ เจลแม่ค้า สปาอพาร์ตเมนต์โปสเตอร์แดนซ์ แตงโมนินจาแอร์ธัมโมเพลย์บอย สแตนเลสบร็อคโคลีแทงโก้จึ๊กเบอร์เกอร์\r\nเพรียวบางไฮเทค สตรอเบอรี ต่อยอด เอเซียไฮเอนด์ รุมบ้าแคปเทรลเลอร์น้องใหม่รีสอร์ต มิลค์ออสซี่ไอเดียเซ็กส์มาราธอน ศิลปวัฒนธรรม ฮองเฮาโปรดักชั่นเอ็กซ์โปสแตนเลส พอเพียงเทียมทานคอนเซปต์ ออดิชั่นตัวเอง ออสซี่ มายาคติแชมเปญรีพอร์ทรีโมตซูชิ แทกติคแลนด์โหงวเฮ้ง ตัวเองเยลลี่ มินท์เดชานุภาพ ยากูซ่า\r\nสเกตช์เวิร์กช็อปเลกเชอร์แอดมิชชั่น ซานตาคลอสพาสตาเช็งเม้งละตินบึม คอนแท็คม้านั่งแตงโมหมวยซีอีโอ ราเมนออยล์เพียบแปร้เวิร์กช็อป มอนสเตอร์ลอจิสติกส์โปรแรลลี่ บอร์ดทีวีตังค์ วาซาบิแต๋วแคทวอล์คอันตรกิริยาสเปค บูติกบาร์บีคิวเบลอเบิร์นสหัสวรรษ โก๊ะเวณิกาลาตินคอมพ์ โครนาบู๊แฟรนไชส์ว้าวฟรุต จิ๊กโก๋ปิโตรเคมี ปิยมิตรล็อบบี้แมกกาซีน เช็งเม้งช็อป สตรอว์เบอร์รี ถูกต้องสเตชัน มาร์ชอวอร์ดซัพพลายเก๋ากี้\r\nฮาโลวีนเลคเชอร์เมเปิลเมาท์ ยูวีก่อนหน้าสตีลวาทกรรม แพตเทิร์นม็อบ แบดวโรกาสแม็กกาซีนบัสลิมิต ไวกิ้งซูเปอร์โดมิโนแอ็กชั่น เที่ยงวันเรซิ่นวอลล์พันธุวิศวกรรม แชมเปญมอยส์เจอไรเซอร์เวณิกา คาร์สันทนาการ ซาตานโลโก้รากหญ้าเซอร์วิสเจ็ต อัลบัมพอเพียงเฟรชมาร์กปอดแหก แต๋วอันเดอร์ฮัมไบโอ พริตตี้นู้ด เจ๊ อาข่าไอเดียไทม์จอหงวน บูติคเคอร์ฟิว อึ้มลอร์ดบอดี้สะบึม\r\nมิวสิคฟยอร์ดแตงโมแฟ็กซ์ คอนโดมิเนียมนพมาศฟินิกซ์ศากยบุตร เวเฟอร์ไกด์ มาร์ชผลไม้ วิลล์พุทธศตวรรษบาลานซ์ จีดีพีอาข่า มายองเนสสารขัณฑ์ ภควัมบดีโพลารอยด์ยะเยือกโซน พาร์แอปพริคอทอาร์ติสต์เวิร์คเพนตากอน แกสโซฮอล์ฮัมเจ็ต ซัมเมอร์ ยาวีจึ๊กอิเลียดมาม่า พรีเซ็นเตอร์ โรแมนติค จังโก้หลวงพี่ หมวยฟลุทเปโซ\r\n";

			// Prepair  custom color
			iText.Kernel.Colors.Color fontColor = new DeviceRgb(50, 150, 200);
			iText.Kernel.Colors.Color fontColor1 = new DeviceRgb(20, 10, 150);

			// set color all paragraph by iText color
			// font color set at paragraph
			document.Add(new Paragraph(sampleText).SetFontColor(ColorConstants.BLUE));
			document.Add(new Paragraph("------------------------------------------------------------------"));
			// Set color all paragraph by custom color
			document.Add(new Paragraph(sampleText).SetFontColor(fontColor));
			document.Add(new Paragraph("------------------------------------------------------------------"));
			// set many color in one paragraph by setpatrate to each text
			document.Add(new Paragraph()
					.Add(new Text("This is text 1 with color 1. ").SetFontColor(fontColor))
					.Add(new Text("This is text 2 with color 2.").SetFontColor(fontColor1))
				);

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample page size
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_14()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);

			pdf.SetDefaultPageSize(PageSize.A9);            // Set Page size on this line

			Document document = new Document(pdf);
			// Or
			//Document document = new Document(pdf, PageSize.A9);

			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			// Sample Text
			document.Add(new Paragraph("Page size set at code at Pdfdocument. กำหนดขนาดหน้ากระดาษที่ Pdfdocument"));

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample page size (A4) and rotate
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_15()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);

			pdf.SetDefaultPageSize(PageSize.A4.Rotate());            // Set Page size A4 and rotate

			Document document = new Document(pdf);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			// Sample Text
			document.Add(new Paragraph("Page size set at code at Pdfdocument. กำหนดขนาดหน้ากระดาษที่ Pdfdocument"));

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample add page number
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_16()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf, PageSize.A4, false);      // This line must set immediateFlush to false

			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is text in start page"));
			// Sample text for 10 page we should start conting from 10
			for (int i = 1; i <= 5; i++)
			{
				document.Add(new Paragraph($"This is sample text on Page {i}"));
				document.Add(new AreaBreak());  // This is page break
			}
			document.Add(new Paragraph("This is text in last page after page break"));

			// Add page number each page at position x:570, y: 790
			// you must set immediateFlush to false when create Document to prevent error when use ShowTextAligned
			int pageCount = pdf.GetNumberOfPages();
			for (int i = 1; i <= pageCount; i++)
			{
				document.ShowTextAligned(new Paragraph($"page {i} of {pageCount}"), 570, 790, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
			}

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample set image background or watermark
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_17()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);

			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample Text at front"));

			// Prepair background Image
			// The better bacjground shound be .png file
			// If image is .jpg. you should set Opacity
			string imagePath = System.IO.Path.Combine(_environment.ContentRootPath, "Assets/Images/Background/wall_01.png");
			Image bgImage = new Image(ImageDataFactory.Create(imagePath));

			// bgImage.SetWidth(pdf.GetDefaultPageSize().GetWidth());
			// bgImage.SetHeight(pdf.GetDefaultPageSize().GetHeight());
			// bgImage.SetOpacity(0.2f);
			bgImage.SetFixedPosition(0, 0);
			document.Add(bgImage);

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		/// <summary>
		/// Sample add image
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_18()
		{
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");
			string saveFileName = $"{System.IO.Path.GetRandomFileName().Replace(".", "")}.pdf";
			string dest = System.IO.Path.Combine(destinationPath, saveFileName);

			PdfWriter writer = new PdfWriter(dest);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);

			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);

			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample add image. นี่เป้นการเพิ่มรูภาพ"));
			document.Add(new Paragraph("Image 1 will stay in document paragraph."));
			// Prepair logo 1
			string logoPath1 = System.IO.Path.Combine(_environment.ContentRootPath, "Assets/Images/Icons/choco-balls.png");
			Image logo1 = new Image(ImageDataFactory.Create(logoPath1));

			// set image size
			logo1.SetWidth(50f);
			document.Add(logo1);

			document.Add(new Paragraph()
						.Add(new Text("This is sample to add image in same paragraph with text"))
						.Add(logo1)
						.Add(new Text(" and this is text after image"))
						);

			// Prepaire logo 2
			string logoPath2 = System.IO.Path.Combine(_environment.ContentRootPath, "Assets/Images/Icons/lollipop.png");
			Image logo2 = new Image(ImageDataFactory.Create(logoPath2));

			logo2.SetWidth(80);
			// Fix position at x:100 point, y:300 point
			// Start coordinate from bottom left conner. at SetFixedPosition function you can set page number to add image.
			logo2.SetFixedPosition(100, 300);
			document.Add(logo2);

			// -----------------------------------------------------
			document.Close();

			return Task.FromResult(saveFileName);
		}

		// start spliter ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Split Pdf file
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_19()
		{
			string sourceFile = System.IO.Path.Combine(_environment.ContentRootPath, "Input/separate.pdf");
			string destinationPath = System.IO.Path.Combine(_environment.ContentRootPath, "Output");

			// Call split function
			ManipulatePdf(sourceFile, destinationPath);
			return Task.FromResult("check folder output");
		}

		private void ManipulatePdf(string sourceFilePath, string destinationPath)
		{
			// Read source file
			PdfDocument pdfDocument = new PdfDocument(new PdfReader(sourceFilePath));
			// How to split
			//IList<PdfDocument> splitDocuments = new CustomPdfSplitter(pdfDocument, destinationFilePath).SplitBySize(200000);
			//IList<PdfDocument> splitDocuments = new CustomPdfSplitter(pdfDocument, destinationFilePath).SplitByPageCount(1);

			// This command split at page number (list of page number to split)
			IList<PdfDocument> splitDocuments = new CustomPdfSplitter(pdfDocument, destinationPath).SplitByPageNumbers(new List<int>() { 2 });

			foreach (PdfDocument doc in splitDocuments)
			{
				doc.Close();
			}

			pdfDocument.Close();
		}

		private class CustomPdfSplitter : PdfSplitter
		{
			private string _destinationFilePath;
			private int partNumber = 1;

			public CustomPdfSplitter(PdfDocument pdfDocument, String dest) : base(pdfDocument)
			{
				this._destinationFilePath = dest;
			}

			protected override PdfWriter GetNextPdfWriter(PageRange documentPageRange)
			{
				string saveFilePath = System.IO.Path.Combine(_destinationFilePath, $"splt_{partNumber}.pdf");

				partNumber = partNumber + 1;
				return new PdfWriter(saveFilePath);
			}
		}

		// end spliter ---------------------------------------------------------------------------------------------

		/// <summary>
		/// Merge pdf files
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_20()
		{
			string sourceFile1 = System.IO.Path.Combine(_environment.ContentRootPath, "Input/file_1.pdf");
			string sourceFile2 = System.IO.Path.Combine(_environment.ContentRootPath, "Input/file_2.pdf");
			string destinationFile = System.IO.Path.Combine(_environment.ContentRootPath, "Output/mergefile.pdf");

			// Read file 1 and save as target then read file 2 and merge to target
			PdfDocument pdfDocument = new PdfDocument(new PdfReader(sourceFile1), new PdfWriter(destinationFile));
			PdfDocument pdfDocument2 = new PdfDocument(new PdfReader(sourceFile2));

			// Merge file
			PdfMerger merger = new PdfMerger(pdfDocument);

			merger.Merge(pdfDocument2, 1, pdfDocument2.GetNumberOfPages());

			pdfDocument2.Close();
			pdfDocument.Close();

			return Task.FromResult("mergefile.pdf");
		}

		/// <summary>
		/// Fill Pdf form
		/// </summary>
		/// <returns></returns>
		public Task<string> Function_21()
		{
			// You can create pdf form by create on word then save to pdf file
			// You must have adobe license and acrobat to set pdf form
			// Every input you can use input name with space.
			// When you get value from input, you can use GetField like code below

			string sourceFile = System.IO.Path.Combine(_environment.ContentRootPath, "Input/form_file.pdf");
			string destinationFile = System.IO.Path.Combine(_environment.ContentRootPath, "Output/filled_form.pdf");

			PdfDocument pdfDocument = new PdfDocument(new PdfReader(sourceFile), new PdfWriter(destinationFile));
			PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, true);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);
			float fontSize = 14f;

			form.SetGenerateAppearance(true);

			form.GetField("ID").SetValue("ID123456", thaiFont, fontSize);
			form.GetField("Name").SetValue("สมศรี มีเงืน", thaiFont, fontSize);
			form.GetField("Form Value 3").SetValue("\u04e7 สวัสดี", thaiFont, fontSize);
			form.GetField("Form Value 4").SetValue("1.0", "100%");
			form.GetField("Val 51").SetValue("true");
			form.GetField("Val 52").SetValue("1");

			pdfDocument.Close();

			return Task.FromResult("filled_form.pdf");
		}

		/// <summary>
		/// Export pdf for download
		/// </summary>
		/// <returns></returns>
		public Task<MemoryStream> Function_22()
		{
			MemoryStream stream = new MemoryStream();
			PdfWriter pdfWriter = new PdfWriter(stream);

			pdfWriter.SetCloseStream(false);        // must use when export MemoryStream

			PdfDocument pdf = new PdfDocument(pdfWriter);
			PdfFont thaiFont = _localFont.GetFont(RefLocalFont.THSarabun);
			Document document = new Document(pdf);
			document.SetFont(thaiFont);

			document.Add(new Paragraph("This is sample text for create pdf"));

			// Close document and return
			document.Close();

			// response stream content
			return Task.FromResult(stream);
		}

		/// <summary>
		/// Set round conner table
		/// </summary>
		/// <returns></returns>
		public Task<MemoryStream> Function_23()
		{
			MemoryStream stream = new MemoryStream();
			PdfWriter writer = new PdfWriter(stream);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);

			writer.SetCloseStream(false);

			document.Add(new Paragraph("This is sample of round conner of table."));

			// Add round table
			// -------------------------------------------------------
			Table table = new Table(3);
			table.SetWidth(UnitValue.CreatePercentValue(100));
			table.SetBorder(new SolidBorder(ColorConstants.BLACK, 1));
			table.SetBorderCollapse(BorderCollapsePropertyValue.SEPARATE);    // This is important
			table.SetBorderRadius(new BorderRadius(5));                 // This is important
			table.SetMarginTop(10);
			table.SetMarginBottom(10);
			table.SetMarginLeft(10);
			table.SetMarginRight(10);

			table.AddCell(new Cell().Add(new Paragraph("Cell 1")));
			table.AddCell(new Cell().Add(new Paragraph("Cell 2")));
			table.AddCell(new Cell().Add(new Paragraph("Cell 3")));

			document.Add(table);

			// -------------------------------------------------------
			document.Close();

			return Task.FromResult(stream);
		}

		/// <summary>
		/// Add watermark from text
		/// </summary>
		/// <returns></returns>
		public Task<MemoryStream> Function_24()
		{
			MemoryStream stream = new MemoryStream();
			PdfWriter writer = new PdfWriter(stream);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf, PageSize.A4, false); // must set immediateFlush to false
			string sampleText = "Lorem Ipsum\r\n\"Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\"\r\n\"There is no one who loves pain itself, who seeks after it and wants to have it, simply because it is pain...\"\r\nWhat is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\nWhy do we use it?\r\nIt is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).\r\n\r\n\r\nWhere does it come from?\r\nContrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.\r\n\r\nWhere can I get some?\r\nThere are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.\r\n\r\n5\r\n\tparagraphs\r\n\twords\r\n\tbytes\r\n\tlists\r\n\tStart with 'Lorem\r\nipsum dolor sit amet...'\r\n\r\nTranslations: Can you help translate this site into a foreign language ? Please email us with details if you can help.\r\nThere is a set of mock banners available here in three colours and in a range of standard banner sizes:\r\nBannersBannersBanners\r\nDonate: If you use this site regularly and would like to help keep the site on the Internet, please consider donating a small sum to help pay for the hosting and bandwidth bill. There is no minimum donation, any sum is appreciated - click here to donate using PayPal. Thank you for your support.\r\nDonate Bitcoin: 16UQLq1HZ3CNwhvgrarV6pMoA2CDjb4tyF\r\nNodeJS Python Interface GTK Lipsum Rails .NET Groovy\r\nThe standard Lorem Ipsum passage, used since the 1500s\r\n\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"\r\n\r\nSection 1.10.32 of \"de Finibus Bonorum et Malorum\", written by Cicero in 45 BC\r\n\"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?\"\r\n\r\n1914 translation by H. Rackham\r\n\"But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?\"\r\n\r\nSection 1.10.33 of \"de Finibus Bonorum et Malorum\", written by Cicero in 45 BC\r\n\"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.\"\r\n\r\n1914 translation by H. Rackham\r\n\"On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.\"";

			PageSize ps = pdf.GetDefaultPageSize();
			writer.SetCloseStream(false);
			document.Add(new Paragraph(sampleText));

			int pageCount = pdf.GetNumberOfPages();

			// Add watermark text every page
			for (int i = 1; i <= pageCount; i++)
			{
				PdfPage page = pdf.GetPage(i);
				PdfLayer layer = new PdfLayer("watermark", pdf);
				var canvas = new PdfCanvas(page);
				var pageSize = page.GetPageSize();
				var paragraph = new Paragraph("This is water mark text").SetFontSize(60);

				paragraph.SetFontColor(ColorConstants.BLACK, 0.2f);

				Canvas canvasModel;
				canvas.BeginLayer(layer);
				canvasModel = new Canvas(canvas, ps);
				canvasModel.ShowTextAligned(paragraph, pageSize.GetWidth() / 2, pageSize.GetHeight() / 2, pdf.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, 45);
				canvasModel.SetFontColor(ColorConstants.GREEN, 0.2f);
				canvas.EndLayer();
			}

			document.Close();
			return Task.FromResult(stream);
		}

		/// <summary>
		/// Add watermark from image
		/// </summary>
		/// <returns></returns>
		public Task<MemoryStream> Function_25()
		{
			MemoryStream stream = new MemoryStream();
			PdfWriter writer = new PdfWriter(stream);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf, PageSize.A4, false);      // must set immediateFlush to false
			string sampleText = "Lorem Ipsum\r\n\"Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\"\r\n\"There is no one who loves pain itself, who seeks after it and wants to have it, simply because it is pain...\"\r\nWhat is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\nWhy do we use it?\r\nIt is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).\r\n\r\n\r\nWhere does it come from?\r\nContrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.\r\n\r\nWhere can I get some?\r\nThere are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.\r\n\r\n5\r\n\tparagraphs\r\n\twords\r\n\tbytes\r\n\tlists\r\n\tStart with 'Lorem\r\nipsum dolor sit amet...'\r\n\r\nTranslations: Can you help translate this site into a foreign language ? Please email us with details if you can help.\r\nThere is a set of mock banners available here in three colours and in a range of standard banner sizes:\r\nBannersBannersBanners\r\nDonate: If you use this site regularly and would like to help keep the site on the Internet, please consider donating a small sum to help pay for the hosting and bandwidth bill. There is no minimum donation, any sum is appreciated - click here to donate using PayPal. Thank you for your support.\r\nDonate Bitcoin: 16UQLq1HZ3CNwhvgrarV6pMoA2CDjb4tyF\r\nNodeJS Python Interface GTK Lipsum Rails .NET Groovy\r\nThe standard Lorem Ipsum passage, used since the 1500s\r\n\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"\r\n\r\nSection 1.10.32 of \"de Finibus Bonorum et Malorum\", written by Cicero in 45 BC\r\n\"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?\"\r\n\r\n1914 translation by H. Rackham\r\n\"But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?\"\r\n\r\nSection 1.10.33 of \"de Finibus Bonorum et Malorum\", written by Cicero in 45 BC\r\n\"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.\"\r\n\r\n1914 translation by H. Rackham\r\n\"On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.\"";
			string watermarkPath = System.IO.Path.Combine(_environment.ContentRootPath, "Assets", "Images", "Watermark", "Samplewatermark.png");
			Image watermarkImage = new Image(ImageDataFactory.Create(watermarkPath));
			PageSize ps = pdf.GetDefaultPageSize();

			writer.SetCloseStream(false);

			document.Add(new Paragraph(sampleText));

			int pageCount = pdf.GetNumberOfPages();

			// Add watermark text every page
			for (int i = 1; i <= pageCount; i++)
			{
				PdfPage page = pdf.GetPage(i);
				PdfLayer layer = new PdfLayer("watermark", pdf);
				var canvas = new PdfCanvas(page);
				var pageSize = page.GetPageSize();

				Canvas canvasModel;

				canvas.BeginLayer(layer);
				canvasModel = new Canvas(canvas, ps);
				canvasModel.Add(watermarkImage);
				canvas.EndLayer();
			}

			document.Close();
			return Task.FromResult(stream);
		}

		/// <summary>
		/// Get digital signature information 1
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public Task<List<SimpleSignatureInfomation>> Function_26(string filePath)
		{
			List<SimpleSignatureInfomation> simpleSignatures = new List<SimpleSignatureInfomation>();
			PdfReader pdfReader = new PdfReader(filePath);
			PdfDocument pdfDocument = new PdfDocument(pdfReader);

			// Start get digital signature
			SignatureUtil signatureUtil = new SignatureUtil(pdfDocument);

			// Get all signature information
			foreach (string signName in signatureUtil.GetSignatureNames())
			{
				PdfSignature pdfSignature = signatureUtil.GetSignature(signName);
				SimpleSignatureInfomation simpleSignature = new SimpleSignatureInfomation();

				// Get signdate
				string signDateStr = pdfSignature.GetDate().ToString().Replace("D:", "").Replace("+00'00'", "");
				DateTime signDate = DateTime.ParseExact(signDateStr, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

				simpleSignature.SignName = signName;
				simpleSignature.SignLocation = pdfSignature.GetLocation();
				simpleSignature.SignReason = pdfSignature.GetReason();
				simpleSignature.SignDate = signDate;

				simpleSignatures.Add(simpleSignature);
			}

			pdfDocument.Close();
			pdfReader.Close();

			return Task.FromResult(simpleSignatures);
		}

		/// <summary>
		/// Get digital signature information 2
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public Task<List<SimpleSignatureInfomation2>> Function_27(string filePath)
		{
			List<SimpleSignatureInfomation2> simpleSignatures = new List<SimpleSignatureInfomation2>();
			PdfReader pdfReader = new PdfReader(filePath);
			PdfDocument pdfDocument = new PdfDocument(pdfReader);

			// Start get digital signature
			SignatureUtil signatureUtil = new SignatureUtil(pdfDocument);

			// Get all signature information
			foreach (string signName in signatureUtil.GetSignatureNames())
			{
				PdfSignature pdfSignature = signatureUtil.GetSignature(signName);
				PdfPKCS7 pdfPKCS7 = signatureUtil.ReadSignatureData(signName);
				SimpleSignatureInfomation2 simpleSignature = new SimpleSignatureInfomation2();
				List<IssuerDNChain> issuerDNChains = new List<IssuerDNChain>();

				IX509Certificate certificate = pdfPKCS7.GetSigningCertificate();

				// Prepair issuer DN chain
				int i = 0;
				foreach (IX509Certificate cert in pdfPKCS7.GetCertificates())
				{
					IssuerDNChain issuerDNChain = new IssuerDNChain();
					var IssuerDNs = ((X509CertificateBC)cert).GetCertificate().IssuerDN.GetValueList();

					// Get IssuerCN
					string IssueCN = cert.GetIssuerDN().ToString();
					string[] arrIssueCN = IssueCN.Split(',');
					string[] arrIssueCN2 = arrIssueCN[2].Split('=');
					string IssueCN2 = arrIssueCN2[1];

					string endDateStr = cert.GetEndDateTime();
					DateTime? endDate = null;
					if (endDateStr.Contains("GMT"))
					{
						endDate = DateTime.ParseExact(endDateStr, "yyyyMMddHHmmss'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
					}
					else if (endDateStr.Contains("Z"))
					{
						endDate = DateTime.ParseExact(cert.GetEndDateTime(), "yyyyMMddHHmmss'Z'", System.Globalization.CultureInfo.InvariantCulture);
					}

					issuerDNChain.Index = i;
					issuerDNChain.Issuer = IssueCN2;
					issuerDNChain.IssuerDN = cert.GetIssuerDN().ToString();
					issuerDNChain.SubjectDN = cert.GetSubjectDN().ToString();
					issuerDNChain.SerialNumber = cert.GetSerialNumber().ToString();
					issuerDNChain.NotBefore = cert.GetNotBefore().ToLocalTime();
					issuerDNChain.EndDateTime = endDate;
					issuerDNChains.Add(issuerDNChain);
					i = i + 1;
				}

				simpleSignature.Name = iText.Signatures.CertificateInfo.GetSubjectFields(certificate).GetField("CN");
				simpleSignature.SignName = signName;
				simpleSignature.SignLocation = pdfSignature.GetLocation();
				simpleSignature.SignReason = pdfSignature.GetReason() ?? "";
				//simpleSignature.SignDate = pdfPKCS7.GetSignDate().ToLocalTime();
				simpleSignature.Revision = signatureUtil.GetRevision(signName);
				simpleSignature.SignatureCoversWholeDocument = signatureUtil.SignatureCoversWholeDocument(signName);
				simpleSignature.VerifySignatureIntegrityAndAuthenticity = pdfPKCS7.VerifySignatureIntegrityAndAuthenticity();
				simpleSignature.DigestAlgorithm = pdfPKCS7.GetDigestAlgorithmName();
				simpleSignature.EncryptionAlgorithm = pdfPKCS7.GetSignatureAlgorithmName();

				simpleSignature.IssuerDNChains = issuerDNChains;

				simpleSignatures.Add(simpleSignature);
			}

			pdfDocument.Close();
			pdfReader.Close();

			return Task.FromResult(simpleSignatures);
		}

		/// <summary>
		/// Table border style (outer, inner, all)
		/// </summary>
		/// <returns></returns>
		public async Task<MemoryStream> Function_28()
		{
			MemoryStream stream = new MemoryStream();
			PdfWriter writer = new PdfWriter(stream);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf, PageSize.A4, false);

			writer.SetCloseStream(false);

			// Prepair border style
			Border border = new SolidBorder(ColorConstants.GREEN, 0.8f);

			Table table1 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();

			// Add cell to table by loops
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					table1.AddCell(new Cell().Add(new Paragraph($"Table 1 Cell {i}, {j}")));
				}
			}
			// add normal table to document
			document.Add(new Paragraph("This is sample of table normal border style."));
			document.Add(table1);

			// Set all border style
			Table table2 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();

			// Add cell to table by loops
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					table2.AddCell(new Cell().Add(new Paragraph($"Table 2 Cell {i}, {j}")));
				}
			}
			table2 = await _helper.SetTableAllBorder(table2, border, true);
			document.Add(new Paragraph("This is sample of table all border style."));
			document.Add(table2);

			// Set outer border style

			Table table3 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
			// Add cell to table by loops
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					table3.AddCell(new Cell().Add(new Paragraph($"Table 3 Cell {i}, {j}")));
				}
			}
			table3 = await _helper.SetTableOuterBorder(table3, border, true);
			document.Add(new Paragraph("This is sample of table outer border style."));
			document.Add(table3);

			// Set inner border style
			Table table4 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
			// Add cell to table by loops
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					table4.AddCell(new Cell().Add(new Paragraph($"Table 4 Cell {i}, {j}")));
				}
			}
			table4 = await _helper.SetTableInnerBorder(table4, border, true);
			document.Add(element: new Paragraph("This is sample of table inner border style."));
			document.Add(table4);

			document.Close();
			return await Task.FromResult(stream);
		}
	}
}