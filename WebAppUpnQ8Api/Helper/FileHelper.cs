namespace WebAppUpnQ8Api.Helper
{
    public static class FileHelper
    {
        public static async Task<string> SaveFileAsync(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(folderPath, fileName);

            Directory.CreateDirectory(folderPath); 

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderPath)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            var fullPath = Path.Combine(folderPath, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }

}
