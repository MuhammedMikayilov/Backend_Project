using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Eduhome.Extentions
{
    public static class Extention
    {
        /// <summary>
        /// check for pictures
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public static bool IsImage(this IFormFile photo)
        {
            return photo.ContentType.Contains("image/");
        }

        /// <summary>
        /// to check the dimensions of the images
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="kb"></param>
        /// <returns></returns>
        public static bool MaxSize(this IFormFile photo, int kb)
        {
            return photo.Length / 1024 <= kb;
        }

        /// <summary>
        /// to add pictures to a folder.
        /// return Task.
        /// </summary>
        /// <param name="photo">photo IFormFile type</param>
        /// <param name="root">string root</param>
        /// <param name="folder">only one folder name</param>
        /// <returns></returns>
        public async static Task<string> SaveImageAsync(this IFormFile photo, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + photo.FileName;
            string path = Path.Combine(root, folder, fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }

    public enum Roles
    {
        Admin,
        CourseModerator,
        TeacherModerator,
        EventModerator,
        BlogsWriter,
        Member
    }
}
