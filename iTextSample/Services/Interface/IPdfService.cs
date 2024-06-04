using iTextSample.Models;
using Microsoft.AspNetCore.Http;

namespace iTextSample.Services.Interface
{
    public interface IPdfService
    {
        public Task<string> Function_01();

        public Task<string> Function_02();

        public Task<string> Function_03();

        public Task<string> Function_04();

        public Task<string> Function_05();

        public Task<string> Function_06();

        public Task<string> Function_07();

        public Task<string> Function_08();

        public Task<string> Function_09();

        public Task<string> Function_10();

        public Task<string> Function_11();

        public Task<string> Function_12();

        public Task<string> Function_13();

        public Task<string> Function_14();

        public Task<string> Function_15();

        public Task<string> Function_16();

        public Task<string> Function_17();

        public Task<string> Function_18();

        public Task<string> Function_19();

        public Task<string> Function_20();

        public Task<string> Function_21();

        public Task<MemoryStream> Function_22();

        public Task<MemoryStream> Function_23();

        public Task<MemoryStream> Function_24();

        public Task<MemoryStream> Function_25();

        public Task<List<SimpleSignatureInfomation>> Function_26(string filePath);

        public Task<List<SimpleSignatureInfomation2>> Function_27(string filePath);

        public Task<MemoryStream> Function_28();

        public Task<MemoryStream> Function_29();

        public Task<MemoryStream> Function_30();

        public Task<MemoryStream> Function_31(string ownerPassword, string userPassword);

        public Task<MemoryStream> Function_32(string ownerPassowrd, string userPassword, IFormFile formFile);
    }
}