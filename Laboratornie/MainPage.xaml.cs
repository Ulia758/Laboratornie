using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace Laboratornie
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Spr_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Sprav());
        }

        private void Uch_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Uchet());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Change());
        }

        private void Filtr_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Filtr());
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Poisk());
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Sortirovka());
        }

        private void Vichesl_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Vicheslenia());
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Vt_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workbook = app.Workbooks.Add();
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Ведомость начисления зарплаты";
            sheet.Cells[1, 1] = "Табельный номер";
            sheet.Cells[1, 2] = "Фамилия";
            sheet.Cells[1, 3] = "Имя";
            sheet.Cells[1, 4] = "Отчество";
            sheet.Cells[1, 5] = "Оклад";
            sheet.Cells[1, 6] = "Сумма доплаты";
            sheet.Cells[1, 7] = "Всего начислено";
            var currentRow = 2;
            var s = Connect.context.Uchetnaya.Select(x =>
            new
            {
                Uchetnaya = x,
                Spravochnaya = x.Spravochnaya,
                Tabelnyi_nomer = x.Tabelnyi_nomer,
                Familia = x.Spravochnaya.Familia,
                Name = x.Spravochnaya.Name,
                Otchestvo = x.Spravochnaya.Otchestvo,
                Oklad = x.Oklad,
                Sumdop = x.Procent_oplaty * x.Oklad / 100,
                Summ = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            }).Where(x => x.Uchetnaya.Month == 2).ToList();
            foreach (var item in s)
            {
                sheet.Cells[currentRow, 1] = item.Spravochnaya.Tabelnyi_nomer;
                sheet.Cells[currentRow, 2] = item.Spravochnaya.Familia;
                sheet.Cells[currentRow, 3] = item.Spravochnaya.Name;
                sheet.Cells[currentRow, 4] = item.Spravochnaya.Otchestvo;
                sheet.Cells[currentRow, 5] = item.Uchetnaya.Oklad;
                sheet.Cells[currentRow, 6] = item.Sumdop;
                sheet.Cells[currentRow, 7] = item.Summ;
                currentRow++;
            }
            sheet.Columns[1].ColumnWidth = 10;
            sheet.Columns[2].ColumnWidth = 20;
            sheet.Columns[3].ColumnWidth = 20;
            sheet.Columns[4].ColumnWidth = 20;
            sheet.Columns[5].ColumnWidth = 20;
            sheet.Columns[6].ColumnWidth = 20;
            sheet.Columns[7].ColumnWidth = 20;
            sheet.Cells[currentRow + 1, 5] = "Итого начислено за месяц: ";
            sheet.Cells[currentRow + 1, 7] = "=SUM(G2:G" + (currentRow - 1) + ")";
        }

        private void Perv_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workbook = app.Workbooks.Add();
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Ведомость начисления зарплаты";
            sheet.Cells[1, 1] = "Табельный номер";
            sheet.Cells[1, 2] = "Фамилия";
            sheet.Cells[1, 3] = "Имя";
            sheet.Cells[1, 4] = "Отчество";
            sheet.Cells[1, 5] = "Оклад";
            sheet.Cells[1, 6] = "Сумма доплаты";
            sheet.Cells[1, 7] = "Всего начислено";
            var currentRow = 2;
            var s = Connect.context.Uchetnaya.Select(x =>
            new
            {
                Uchetnaya = x,
                Spravochnaya = x.Spravochnaya,
                Tabelnyi_nomer = x.Tabelnyi_nomer,
                Familia = x.Spravochnaya.Familia,
                Name = x.Spravochnaya.Name,
                Otchestvo = x.Spravochnaya.Otchestvo,
                Oklad = x.Oklad,
                Sumdop = x.Procent_oplaty * x.Oklad / 100,
                Summ = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            }).Where(x=>x.Uchetnaya.Month ==1).ToList();
            foreach (var item in s)
            {
                sheet.Cells[currentRow, 1] = item.Spravochnaya.Tabelnyi_nomer;
                sheet.Cells[currentRow, 2] = item.Spravochnaya.Familia;
                sheet.Cells[currentRow, 3] = item.Spravochnaya.Name;
                sheet.Cells[currentRow, 4] = item.Spravochnaya.Otchestvo;
                sheet.Cells[currentRow, 5] = item.Uchetnaya.Oklad;
                sheet.Cells[currentRow, 6] = item.Sumdop;
                sheet.Cells[currentRow, 7] = item.Summ;
                currentRow++;         
            }
            sheet.Columns[1].ColumnWidth = 10;
            sheet.Columns[2].ColumnWidth = 20;
            sheet.Columns[3].ColumnWidth = 20;
            sheet.Columns[4].ColumnWidth = 20;
            sheet.Columns[5].ColumnWidth = 20;
            sheet.Columns[6].ColumnWidth = 20;
            sheet.Columns[7].ColumnWidth = 20;
            sheet.Cells[currentRow + 1, 5] = "Итого начислено за месяц: ";
            sheet.Cells[currentRow + 1, 7] = "=SUM(G2:G"+(currentRow-1)+")";
        }

        private void Za_vt_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document();
            string fileName = "Ведомость начисления заработной платы за 2 месяц.pdf";
            PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
            doc.Open();
            BaseFont basefont = BaseFont.CreateFont("C:\\Колосова\\ArialRegular.ttf", "CP1251", BaseFont.EMBEDDED);
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            iTextSharp.text.Font font = new iTextSharp.text.Font(basefont, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fonttitle = new iTextSharp.text.Font(basefont, 18, iTextSharp.text.Font.NORMAL);
            Paragraph title = new Paragraph("Ведомость начисления заработной платы за второй месяц", fonttitle);
            doc.Add(title);
            doc.Add(new Paragraph("\n"));
            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 100;
            table.AddCell(new Phrase("Табельный номер", font));
            table.AddCell(new Phrase("Фамилия", font));
            table.AddCell(new Phrase("Имя", font));
            table.AddCell(new Phrase("Отчество", font));
            table.AddCell(new Phrase("Оклад", font));
            table.AddCell(new Phrase("Сумма доплаты", font));
            table.AddCell(new Phrase("Всего начислено", font));
            var s = Connect.context.Uchetnaya.Select(x =>
            new
            {
                Uchetnaya = x,
                Spravochnaya = x.Spravochnaya,
                Tabelnyi_nomer = x.Tabelnyi_nomer,
                Familia = x.Spravochnaya.Familia,
                Name = x.Spravochnaya.Name,
                Otchestvo = x.Spravochnaya.Otchestvo,
                Oklad = x.Oklad,
                Sumdop = x.Procent_oplaty * x.Oklad / 100,
                Summ = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            }).Where(x => x.Uchetnaya.Month == 2).ToList();
            foreach (var user in s)
            {
                table.AddCell(new Phrase($"{user.Tabelnyi_nomer}", font));
                table.AddCell(new Phrase($"{user.Familia}", font));
                table.AddCell(new Phrase($"{user.Name}", font));
                table.AddCell(new Phrase($"{user.Otchestvo}", font));
                table.AddCell(new Phrase($"{user.Oklad}", font));
                table.AddCell(new Phrase($"{user.Sumdop}"));
                table.AddCell(new Phrase($"{user.Summ}", font));
            }
            doc.Add(table);
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Итог: " + s.Sum(x => x.Summ), font));
            doc.Close();
            MessageBox.Show("Данные записаны в файл. Для просмотра перейдите в папку D:\\Моё\\11.01 и 01.01\\Laboratornie\\Laboratornie\\bin\\Debug", "Успешно");
        }
        private void Za_perv_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document();
            string fileName = "Ведомость начисления заработной платы за 1 месяц.pdf";
            PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
            doc.Open();
            BaseFont basefont = BaseFont.CreateFont("C:\\Колосова\\ArialRegular.ttf","CP1251",BaseFont.EMBEDDED);
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            iTextSharp.text.Font font = new iTextSharp.text.Font(basefont, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fonttitle = new iTextSharp.text.Font(basefont, 18, iTextSharp.text.Font.NORMAL);
            Paragraph title = new Paragraph("Ведомость начисления заработной платы за первый месяц", fonttitle);
            doc.Add(title);
            doc.Add(new Paragraph("\n"));
            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 100;
            table.AddCell(new Phrase("Табельный номер", font));
            table.AddCell(new Phrase("Фамилия", font));
            table.AddCell(new Phrase("Имя", font));
            table.AddCell(new Phrase("Отчество", font));
            table.AddCell(new Phrase("Оклад", font));
            table.AddCell(new Phrase("Сумма доплаты", font));
            table.AddCell(new Phrase("Всего начислено", font));
            var s = Connect.context.Uchetnaya.Select(x =>
            new
            {
                Uchetnaya = x,
                Spravochnaya = x.Spravochnaya,
                Tabelnyi_nomer = x.Tabelnyi_nomer,
                Familia = x.Spravochnaya.Familia,
                Name = x.Spravochnaya.Name,
                Otchestvo = x.Spravochnaya.Otchestvo,
                Oklad = x.Oklad,
                Sumdop = x.Procent_oplaty * x.Oklad / 100,
                Summ = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            }).Where(x => x.Uchetnaya.Month == 1).ToList();
            foreach (var user in s)
            {
                table.AddCell(new Phrase($"{user.Tabelnyi_nomer}", font));
                table.AddCell(new Phrase($"{user.Familia}", font));
                table.AddCell(new Phrase($"{user.Name}", font));
                table.AddCell(new Phrase($"{user.Otchestvo}", font));
                table.AddCell(new Phrase($"{user.Oklad}", font));
                table.AddCell(new Phrase($"{user.Sumdop}"));
                table.AddCell(new Phrase($"{user.Summ}", font));
            }
            doc.Add(table);
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Итог: " + s.Sum(x => x.Summ), font));
            doc.Close();
            MessageBox.Show("Данные записаны в файл. Для просмотра перейдите в папку D:\\Моё\\11.01 и 01.01\\Laboratornie\\Laboratornie\\bin\\Debug", "Успешно");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workbook = app.Workbooks.Add();
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Группировка по месяцу";
            sheet.Cells[1, 1] = "Месяц";
            sheet.Cells[1, 2] = "Количество человек";
            var currentRow = 2;
            var s = Connect.context.Uchetnaya.GroupBy(x => x.Month).Select(g => new { Month = g.Key, Count = g.Count() }).ToList();
            foreach (var item in s)
            {
                sheet.Cells[currentRow, 1] = item.Month;
                sheet.Cells[currentRow, 2] = item.Count;
                currentRow++;
            }
            sheet.Columns[1].ColumnWidth = 10;

            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //app.WindowState = XlWindowState.xlMaximized;

            //Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //Worksheet ws = wb.Worksheets[1];
            //DateTime currentDate = DateTime.Now;

            //ws.Range["A1:A3"].Value = "Who is number one? :)";
            //ws.Range["A4"].Value = "vitoshacademy.com";
            //ws.Range["A5"].Value = currentDate;
            //ws.Range["B6"].Value = "Tommorow's date is: =>";
            //ws.Range["C6"].FormulaLocal = "= A5 + 1";
            //ws.Range["A7"].FormulaLocal = "=SUM(D1:D10)";
            //for (int i = 1; i <= 10; i++)
            //ws.Range["D" + i].Value = i * 2;


            //Excel.Application excel = new Excel.Application()
            //{
            //    Visible = true,
            //    SheetsInNewWorkbook = 1
            //};
            //Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            //excel.DisplayAlerts = false;
            //Excel.Worksheet worksheet = null;
            //worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            //worksheet.Name = "Отчёт";
            //worksheet.Cells[1, 1] = "Табельный номер";
            //worksheet.Cells[1, 2] = "Фамилия";
            //worksheet.Cells[1, 3] = "Имя";
            //worksheet.Cells[1, 4] = "Отчество";
            //worksheet.Cells[1, 5] = "Оклад";
            //worksheet.Cells[1, 6] = "Сумма доплаты";
            //worksheet.Cells[1, 7] = "Всего начислено";
            //var currentRow = 4;
            //var s = Connect.context.Uchetnaya.Select(x =>
            //new
            //{
            //    Uchetnaya = x,
            //    Spravochnaya = x.Spravochnaya,
            //    Tabelnyi_nomer = x.Tabelnyi_nomer,
            //    Familia = x.Spravochnaya.Familia,
            //    Name = x.Spravochnaya.Name,
            //    Otchestvo = x.Spravochnaya.Otchestvo,
            //    Oklad = x.Oklad,
            //    Sumdop = x.Procent_oplaty * x.Oklad / 100,
            //    Summ = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            //}).ToList();
            //foreach (var item in s)
            //{
            //    worksheet.Cells[currentRow, 1] = item.Spravochnaya.Tabelnyi_nomer;
            //    worksheet.Cells[currentRow, 2] = item.Spravochnaya.Familia;
            //    worksheet.Cells[currentRow, 3] = item.Spravochnaya.Name;
            //    worksheet.Cells[currentRow, 4] = item.Spravochnaya.Otchestvo;
            //    worksheet.Cells[currentRow, 5] = item.Uchetnaya.Oklad;
            //    worksheet.Cells[currentRow, 6] = item.Sumdop;
            //    worksheet.Cells[currentRow, 7] = item.Summ;
            //    currentRow++;
            //}
            //worksheet.Columns[1].ColumnWidth = 10;
            //worksheet.Columns[2].ColumnWidth = 20;
            //worksheet.Columns[3].ColumnWidth = 20;
            //worksheet.Columns[4].ColumnWidth = 20;
            //worksheet.Columns[5].ColumnWidth = 20;
            //worksheet.Columns[6].ColumnWidth = 20;
            //worksheet.Columns[7].ColumnWidth = 20;
            //worksheet.Cells[currentRow + 1, 5] = "Итого начислено за месяц: ";
            //worksheet.Cells[currentRow + 1, 7] = "=SUM(G2:G" + (currentRow - 1) + ")";
            //Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 7]];
            //headerRange.Font.Bold = true;
            //headerRange.Font.Size = 14;
            //Excel.Range dataRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[currentRow-1, 7]];
            //dataRange.Columns.AutoFit();
            //Excel.Range monthRange = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[currentRow-1, 7]];
            //monthRange.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //workbook.SaveAs("Отчёт.xlsx");
        }
    }
}
