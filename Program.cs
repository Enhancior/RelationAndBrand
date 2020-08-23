using ApiToExcel.Repositories;
using ApiToExcel.Services;
using System.Net.Http;

namespace ApiToExcel
{
    class Program
    {
        private const string filePath = "z:\\";
        private const string fileName = "CurrentlySubscribedCustomers.xlsx";
        private static readonly HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            FileRepository repo = new FileRepository();
            CustomerService service = new CustomerService(_client);
            repo.CreateExcelFile(service.CompareCustomers(), filePath, fileName);
        }
    }
}
