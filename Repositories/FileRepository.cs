using ApiToExcel.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace ApiToExcel.Repositories
{
    class FileRepository : IFileRepository
    {
        public void CreateExcelFile(IEnumerable<Customer> customers, string filePath, string fileName)
        {
            try
            {
                var workBook = new XLWorkbook();
                var workSheet = workBook.Worksheets.Add("Currently subscribed customers");
                var currentRow = 1;
                workSheet.Cell(currentRow, 1).Value = "Id";
                workSheet.Cell(currentRow, 1).Style.Font.Bold = true;
                workSheet.Cell(currentRow, 2).Value = "First Name";
                workSheet.Cell(currentRow, 2).Style.Font.Bold = true;
                workSheet.Cell(currentRow, 3).Value = "Last Name";
                workSheet.Cell(currentRow, 3).Style.Font.Bold = true;
                workSheet.Cell(currentRow, 4).Value = "Email";
                workSheet.Cell(currentRow, 4).Style.Font.Bold = true;
                workSheet.Cell(currentRow, 5).Value = "Mobile";
                workSheet.Cell(currentRow, 5).Style.Font.Bold = true;

                foreach (var customer in customers)
                {
                    currentRow++;
                    workSheet.Cell(currentRow, 1).Value = customer.Id;
                    workSheet.Cell(currentRow, 2).Value = customer.Firstname;
                    workSheet.Cell(currentRow, 3).Value = customer.Lastname;
                    workSheet.Cell(currentRow, 4).Value = customer.Email;
                    workSheet.Cell(currentRow, 5).Value = customer.Mobile;
                }

                workBook.SaveAs($"{filePath}{fileName}");

                Console.WriteLine($"File successfully saved at {filePath}{fileName}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e} at BuildExcel.");
            }
        }
    }
}
