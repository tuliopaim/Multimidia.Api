using Microsoft.AspNetCore.Http;
using Multimidia.Api.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Multimidia.Api.Core.Services
{
    public class FileService
    {
        public async Task<FileViewModel> FormFileToFileViewModel(IFormFile formFile)
        {
            byte[] fileBytes;

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var filename = formFile.FileName;
            var contentType = formFile.ContentType;
            var base64 = Convert.ToBase64String(fileBytes);

            var fileViewModel = new FileViewModel
            {
                FileName = filename,
                ContentType = contentType,
                Base64 = base64,
                Bytes = fileBytes
            };

            return fileViewModel;
        }

        public FileStream FileViewModelToFileStream(FileViewModel file)
        {
            var bytes = Convert.FromBase64String(file.Base64);

            using FileStream fileStream = new FileStream(file.FileName, FileMode.Create);

            // Write the data to the file, byte by byte.
            for (int i = 0; i < bytes.Length; i++)
            {
                fileStream.WriteByte(bytes[i]);
            }

            // Set the stream position to the beginning of the file.
            fileStream.Seek(0, SeekOrigin.Begin);

            return fileStream;
        }

    }
}
