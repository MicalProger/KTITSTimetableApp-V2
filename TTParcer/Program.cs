using KTITSTimetableApp;
using Microsoft.Office.Interop.Excel;
using System.Text;
using System.Text.Json;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace TTParcer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application excelApp = new Application();
            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\Mimm\Projects\VIsualStudioProjects\KTITSTimetableApp\TTParcer\rasp1k2022-2023 с 12.01.2023.xlsx");
            _Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            //if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
            List<Lesson[]> week = new List<Lesson[]>();
            int dayId = 0;
            int lsId = 0;
            for (int i = 0; i < rows - 8; i++)
            {
                var curLs = new Lesson();
                curLs.LessonName = excelRange.Cells[i + 7, 9];
            }
            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            Console.ReadLine();
            //var tt = File.ReadAllLines("122tt.txt", Encoding.UTF8);
            //List<Lesson[]> week = new List<Lesson[]>();
            //int dayId = 0;
            //int lsId = 0;
            //bool addToLast = false;
            //foreach (var lesson in tt)
            //{
            //    if (addToLast)
            //    {
            //        week[dayId][lsId].LessonName += "|" + lesson;
            //        addToLast = false;
            //    }
            //    else
            //    {
            //        if (lsId == 0)
            //        {
            //            week.Add(new Lesson[6]);
            //        }
            //        if (lesson != "\t")
            //        {
            //            var curLs = new Lesson();
            //            curLs.ClassNo = lesson.Substring(0, lesson.IndexOf('\t'));
            //            var lsName = lesson.Substring(lesson.IndexOf('\t') + 1);
            //            if (lsName.EndsWith("_"))
            //            {
            //                lsName = lsName.Replace("_", "");
            //                addToLast = true;
            //            }
            //            curLs.LessonName = lsName;
            //            week[dayId][lsId] = curLs;
            //            if (addToLast)
            //                continue;
            //        }
            //    }

            //    if (!addToLast)
            //        lsId++;
            //    if (lsId == 6) { lsId = 0; dayId++; }
            //}
            //File.WriteAllText("saved.txt", JsonSerializer.Serialize(week, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }
}