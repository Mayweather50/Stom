using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using ProjectStomatology.Models;

namespace ProjectStomatology.Controllers
{
    public class ServicesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExcelData()
        {
            var model = new List<Profile>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Установите контекст лицензии

            var file = new FileInfo(@"D:\Прайс ЦМСиН c 01.11.2020 на печать.xlsx");
            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 1; row <= rowCount; row++)
                {

                    var myModel = new Profile
                    {
                        Code = worksheet.Cells[row, 1].Value?.ToString(),
                        Name = worksheet.Cells[row, 2].Value?.ToString(),



                    };

                    model.Add(myModel);
                }
            }

            return View(model);
        }



        //[HttpPost]
        //public async Task<IActionResult> UploadExcel()
        //{
        //    var uploadedFile = HttpContext.Request.Form.Files[0]; // Получаем загруженный файл

        //    if (uploadedFile != null && uploadedFile.Length > 0)
        //    {
        //        // Создаем список для хранения данных из Excel
        //        var excelDataList = new List<Profile>();

        //        using (var stream = new MemoryStream())
        //        {
        //            await uploadedFile.CopyToAsync(stream);

        //            using (var package = new ExcelPackage(stream))
        //            {
        //                var worksheet = package.Workbook.Worksheets[0]; // Получаем первый лист Excel

        //                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
        //                {
        //                    excelDataList.Add(new Profile
        //                    {
        //                        Code = worksheet.Cells[row, 1].Value.ToString(),
        //                        Name = worksheet.Cells[row, 2].Value.ToString(),
        //                        Price = decimal.Parse(worksheet.Cells[row, 3].Value.ToString())
        //                    });
        //                }
        //            }
        //        }

        //        // Передаем данные в представление
        //        return View("Index", excelDataList);
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
