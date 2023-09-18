namespace ProjectStomatology.Repository
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using ProjectStomatology.Models;
    using Excel = Microsoft.Office.Interop.Excel;

    public class ExcelParsingService
    {

        public async Task<Profile> ParsingService(string path)
        {
            path = @"D:\Прайс ЦМСиН c 01.11.2020 на печать.xlsx";
            Excel.Application ObjWorkExcel = new(); //открыть эксель
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(@path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл

            Profile profile = new();
            await TitulPage(ObjWorkBook, profile);

            ClearAndExitExcel(ObjWorkBook, ObjWorkExcel);

            return profile;
        }


        //[HttpGet("parse")]
        //public async Task<IActionResult> ParseFile(string path)
        //{
        //    // Декодируйте путь из URL-совместимого формата
        //    string decodedPath = System.Web.HttpUtility.UrlDecode(path);

        //    // Теперь вы можете использовать decodedPath для доступа к файлу
        //    // Например, вызвать вашу функцию ParsingService(decodedPath)

        //    // Вернуть результат в представление, передав данные через модель или ViewBag
        //    var profile = await ParsingService(decodedPath);
        //    return View(); // Замените "ViewName" на имя вашего представления
        //}


        private async Task TitulPage(Excel.Workbook ObjWorkBook, Profile profile)
        {
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1 лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//1 ячейку
            string[,] list = new string[lastCell.Column, lastCell.Row]; // массив значений с листа равен по размеру листу

            for (int i = 0; i < lastCell.Column; i++) //по всем колонкам
                for (int j = 0; j < lastCell.Row; j++) // по всем строкам

                    list[i, j] = ObjWorkSheet.Cells[j + 1, i + 1].ToString();//считываем текст в строку
        }


        private static void ClearAndExitExcel(Excel.Workbook ObjWorkBook, Excel.Application ObjWorkExcel)
        {
            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из экселя
            GC.Collect(); // убрать за собой
        }
    }
}
