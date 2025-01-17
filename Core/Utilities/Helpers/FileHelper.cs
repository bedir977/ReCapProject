﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\images\";
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var path1 = newPath(file);
            var result = path + path1;
            File.Move(sourcepath, result);
            return "/images/" + path1;
            //var result = newPath(file);
            //try
            //{
            //    var sourcepath = Path.GetTempFileName();
            //    if (file.Length > 0)
            //        using (var stream = new FileStream(sourcepath, FileMode.Create))
            //            file.CopyTo(stream);

            //    File.Move(sourcepath, result.newPath);
            //}
            //catch (Exception exception)
            //{

            //    return exception.Message;
            //}

            //return result.Path2;
        }

        //public static string Update(string sourcePath, IFormFile file)
        //{
        //    var result = newPath(file);

        //    try
        //    {


        //        if (sourcePath.Length > 0)
        //        {
        //            using (var stream = new FileStream(result.newPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //        }

        //        File.Delete(sourcePath);
        //    }
        //    catch (Exception excepiton)
        //    {
        //        return excepiton.Message;
        //    }

        //    return result.Path2;
        //}

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

        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var newImagePath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            //string result = $@"{path}\{newPath}";
            return newImagePath;

            //var creatingUniqueFilename = Guid.NewGuid().ToString()
            //   + fileExtension;


            //string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            //string result = $@"{path}\{creatingUniqueFilename}";

            //return (result, $"\\Images\\{creatingUniqueFilename}");
        }
    }
}
