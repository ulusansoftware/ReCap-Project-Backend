using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        //ADD
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            string path = Environment.CurrentDirectory + @"\wwwroot";
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = NewPath(file);
            File.Move(sourcepath, path + result);
            return result;
        }
        //DELETE
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        //UPDATE
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        //NEWpath
        public static string NewPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = @"\Images"+newPath;
            return result;
        }
    }
}