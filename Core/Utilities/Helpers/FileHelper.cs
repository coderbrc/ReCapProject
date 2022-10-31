using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static string currentFileDirectory = Environment.CurrentDirectory + "\\wwwroot\\images\\";
        public void Delete(string filePath)
        {
            FileInfo TheFile = new FileInfo(filePath);
            if (TheFile.Exists)
            {
                File.Delete(filePath);
            }
        }
        public IResult Update(IFormFile file, string filePath)
        {
            //var fileName = Path.GetFileName(file.FileName);
            //var fileExtension = Path.GetExtension(fileName);
            //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file);
        }
        public IResult Upload(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
            try
            {
                fileName = currentFileDirectory + newFileName;
                if (file.Length > 0)
                {
                    using (var filestream = File.Create(fileName))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                    }
                }
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            return new SuccessResult(fileName);
        }
        public string DefaultImage()
        {
            var filename = currentFileDirectory + "Default.jpg";
            return filename;
        }
    }
}
