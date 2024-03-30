using Azure.Core;
using VegeFoods_MVC.DAL;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static VegeFoods_MVC.Utils.Extentions.FileExtention;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VegeFoods_MVC.Utils.Extentions
{
	public static class FileExtention
	{
		public static bool CheckFileType(this IFormFile file, string pattern)
		{
			return file.ContentType.Contains(pattern);
		}

		public static bool CheckFileSize(this IFormFile file, long size)
		{
			return file.Length / 1024 < size;
		}

		public static async Task<string> FileUpload(this IFormFile file, string root, string folder)
		{
			string fileName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(file.FileName);
			string finalPath = Path.Combine(root, folder, fileName);
			using (var fileStream = new FileStream(finalPath, FileMode.Create))
				await file.CopyToAsync(fileStream);

			return fileName;
		}
	}
}
