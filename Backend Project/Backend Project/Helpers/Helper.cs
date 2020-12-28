using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// deletes images from folders
        /// </summary>
        /// <param name="root"> root </param>
        /// <param name="folder">the folder where the image you want to delete is located</param>
        /// <param name="sliderSelected"> the object of the image you want to delete </param>
        /// <returns></returns>
        public static bool DeleteImage(string root, string folder, string fileName)
        {
            string path = Path.Combine(root, folder, fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }
}

