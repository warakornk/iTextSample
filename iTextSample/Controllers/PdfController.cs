using iTextSample.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        /// Create sample pdf with Indent
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
    }
}