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

        [HttpGet("Sample_01")]
        public async Task<IActionResult> GetSample01Async()
        {
            string outputfilename = await _pdfService.Function_01();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        [HttpGet("Sample_02")]
        public async Task<IActionResult> GetSample02Async()
        {
            string outputfilename = await _pdfService.Function_02();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }

        [HttpGet("Sample_03")]
        public async Task<IActionResult> GetSample03Async()
        {
            string outputfilename = await _pdfService.Function_03();

            return Ok($"please check file name \"{outputfilename}\" output folder");
        }
    }
}