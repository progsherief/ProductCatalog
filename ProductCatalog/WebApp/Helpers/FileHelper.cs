public static class FileHelper
{
    public static bool ValidateImage(IFormFile file,out string error)
    {
        error = string.Empty;
        var allowedExtensions = new[] { ".jpg",".jpeg",".png" };
        var extension = Path.GetExtension(file.FileName).ToLower();

        if(!allowedExtensions.Contains(extension))
        {
            error = "Allowed formats are JPG, JPEG, and PNG.";
            return false;
        }

        if(file.Length > 1 * 1024 * 1024)
        {
            error = "Maximum allowed file size is 1MB.";
            return false;
        }

        return true;
    }
}
