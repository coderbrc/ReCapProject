using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        public  IResult Upload(IFormFile files);
        public  IResult Update(IFormFile file, string filePath);
        public  void Delete(string filepath);
        public string DefaultImage();
    }
}
