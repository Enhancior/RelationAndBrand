using ApiToExcel.Models;
using System.Collections.Generic;

namespace ApiToExcel.Repositories
{
    interface IFileRepository
    {
        void CreateExcelFile(IEnumerable<Customer> customers, string filePath, string fileName);
    }
}
