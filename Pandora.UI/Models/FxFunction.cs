using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandora.UI.Models
{
    public enum FolderPath
    {
        product=1,
        user
    }

    public static class FxFunction
    {
        public static string ImageUpload(HttpPostedFileBase pic, FolderPath folderPath, out bool isCompleted)
        {
            string errorMessage = null;

            if (pic != null && pic.ContentLength <= 2097152 && pic.ContentType.Contains("image"))
            {
                string uploadPath = $"{folderPath.ToString()}/{Guid.NewGuid().ToString().Replace('-', '_').ToLower()}.{pic.ContentType.Split('/')[1]}";

                pic.SaveAs(HttpContext.Current.Server.MapPath("~/Content/uploads/" + uploadPath));
                isCompleted = true;
                return uploadPath;
            }
            else
            {
                errorMessage = "Please make sure that you have an image file less than 2MB.";
            }

            isCompleted = false;
            return errorMessage;
        }

    }
}