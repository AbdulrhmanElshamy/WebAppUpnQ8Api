using SixLabors.ImageSharp.Formats.Webp;

namespace WebAppUpnQ8Api.Helper
{
    public static class FileHelper
    {
        public static async Task<string> SaveFileAsync(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = Guid.NewGuid() + ".webp";
            var fullPath = Path.Combine(folderPath, fileName);

            Directory.CreateDirectory(folderPath);

            using (var image = await Image.LoadAsync(file.OpenReadStream()))
            {
                var encoder = new WebpEncoder
                {
                    Quality = 75 // You can adjust quality (0–100)
                };

                await image.SaveAsync(fullPath, encoder);
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
