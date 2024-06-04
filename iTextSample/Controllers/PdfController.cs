using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using iTextSample.Services.Interface;
using Org.BouncyCastle.Asn1.Mozilla;
using iTextSample.Models;
using System.Runtime.CompilerServices;

namespace iTextSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService iPdfService)
        {
            _pdfService = iPdfService;
        }

        /// <summary>
        /// Create sample pdf file and add a paragraph. Then save to output folder.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_01")]
        public async Task<IActionResult> GetSample01Async()
        {
            string outputfilename = await _pdfService.Function_01();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Create sample pdf file and add custom font and add a paragraph. Then save to output folder.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_02")]
        public async Task<IActionResult> GetSample02Async()
        {
            string outputfilename = await _pdfService.Function_02();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Create sample pdf file and set font size
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_03")]
        public async Task<IActionResult> GetSample03Async()
        {
            string outputfilename = await _pdfService.Function_03();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Create sample pdf with text alignment
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_04")]
        public async Task<IActionResult> GetSample04Async()
        {
            string outputfilename = await _pdfService.Function_04();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Create sample pdf with indent
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_05")]
        public async Task<IActionResult> GetSample05Async()
        {
            string outputfilename = await _pdfService.Function_05();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample text leading (space between line)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_06")]
        public async Task<IActionResult> GetSample06Async()
        {
            string outputfilename = await _pdfService.Function_06();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample create pdf with list
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_07")]
        public async Task<IActionResult> GetSample07Async()
        {
            string outputfilename = await _pdfService.Function_07();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample create pdf list and custom symbol of list
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_08")]
        public async Task<IActionResult> GetSample08Async()
        {
            string outputfilename = await _pdfService.Function_08();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample create table
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_09")]
        public async Task<IActionResult> GetSample09Async()
        {
            string outputfilename = await _pdfService.Function_09();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample table cell background color
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_10")]
        public async Task<IActionResult> GetSample10Async()
        {
            string outputfilename = await _pdfService.Function_10();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample table border
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_11")]
        public async Task<IActionResult> GetSample11Async()
        {
            string outputfilename = await _pdfService.Function_11();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample Separate line
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_12")]
        public async Task<IActionResult> GetSample12Async()
        {
            string outputfilename = await _pdfService.Function_12();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample font color
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_13")]
        public async Task<IActionResult> GetSample13Async()
        {
            string outputfilename = await _pdfService.Function_13();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample page size
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_14")]
        public async Task<IActionResult> GetSample14Async()
        {
            string outputfilename = await _pdfService.Function_14();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample page size (A4) and rotate
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_15")]
        public async Task<IActionResult> GetSample15Async()
        {
            string outputfilename = await _pdfService.Function_15();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample page number
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_16")]
        public async Task<IActionResult> GetSample16Async()
        {
            string outputfilename = await _pdfService.Function_16();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample set image background or watermark
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_17")]
        public async Task<IActionResult> GetSample17Async()
        {
            string outputfilename = await _pdfService.Function_17();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Sample add image
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_18")]
        public async Task<IActionResult> GetSample18Async()
        {
            string outputfilename = await _pdfService.Function_18();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Split Pdf file
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_19")]
        public async Task<IActionResult> GetSample19Async()
        {
            string outputfilename = await _pdfService.Function_19();

            return Ok($"please check folder \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Merge pdf files
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_20")]
        public async Task<IActionResult> GetSample20Async()
        {
            string outputfilename = await _pdfService.Function_20();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Fill pdf form
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_21")]
        public async Task<IActionResult> GetSample21Async()
        {
            string outputfilename = await _pdfService.Function_21();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        /// <summary>
        /// Export pdf for download (MemoryStream)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_22")]
        public async Task<IActionResult> GetSample22Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_22();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Set round conner table
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_23")]
        public async Task<IActionResult> GetSample23Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_23();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Add watermark from text
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_24")]
        public async Task<IActionResult> GetSample24Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_24();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Add watermark from iamge
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_25")]
        public async Task<IActionResult> GetSample25Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_25();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Get digital signature information 1
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("Sample_26")]
        public async Task<IActionResult> GetSmaple26Async(IFormFile file)
        {
            List<SimpleSignatureInfomation> simpleSignatures = new List<SimpleSignatureInfomation>();

            if (file == null)
            {
                return BadRequest();
            }

            if (file.Length > 0)
            {
                // create temp file
                string filePath = Path.GetTempFileName();
                string fileName = file.FileName;

                if (!fileName.EndsWith(".pdf"))
                {
                    return BadRequest();
                }

                // use stream to save file
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                // get digital signature information
                simpleSignatures = await _pdfService.Function_26(filePath);

                // delete file
                System.IO.File.Delete(filePath);
            }

            return Ok(simpleSignatures);
        }

        /// <summary>
        /// Get digital signature information 2
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("Sample_27")]
        public async Task<IActionResult> GetSample27Async(IFormFile file)
        {
            List<SimpleSignatureInfomation2> simpleSignatures = new List<SimpleSignatureInfomation2>();

            if (file == null)
            {
                return BadRequest();
            }

            if (file.Length > 0)
            {
                // create temp file
                string filePath = Path.GetTempFileName();
                string fileName = file.FileName;

                if (!fileName.EndsWith(".pdf"))
                {
                    return BadRequest();
                }

                // use stream to save file
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                // get digital signature information
                simpleSignatures = await _pdfService.Function_27(filePath);

                // delete file
                System.IO.File.Delete(filePath);
            }

            return Ok(simpleSignatures);
        }

        /// <summary>
        /// Table border style (outer, inner, all)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_28")]
        public async Task<IActionResult> GetSample28Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_28();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Get remaining area after add content
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_29")]
        public async Task<IActionResult> GetSample29Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_29();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Sample barcode and QRCode
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sample_30")]
        public async Task<IActionResult> GetSample30Async()
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                stream = await _pdfService.Function_30();
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Encrypt pdf file with password
        /// </summary>
        /// <param name="UserPassword">User password</param>
        /// <returns></returns>
        [HttpGet("Sample_31")]
        public async Task<IActionResult> GetSample31Async(string UserPassword)
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                // This password use for owner of pdf file
                string ownerPassword = "Own12345";

                stream = await _pdfService.Function_31(ownerPassword, UserPassword);
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }

        /// <summary>
        /// Encrypt exists pdf file with password
        /// </summary>
        /// <param name="UserPassword">User password</param>
        /// <param name="formFile">pdf file</param>
        /// <returns></returns>
        [HttpPost("Sample_32")]
        public async Task<IActionResult> GetSample32Async(string UserPassword, IFormFile formFile)
        {
            try
            {
                // random filename to save
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                MemoryStream stream = new MemoryStream();

                // This password use for owner of pdf file
                string ownerPassword = "Own12345";

                stream = await _pdfService.Function_32(ownerPassword, UserPassword, formFile);
                stream.Position = 0;

                return File(stream, "application/pdf", $"sampleOutput-{fileName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
            }
        }
    }
}