using ApiApplication.Model;
using System.Threading.Tasks;
using System;

namespace ApiApplication
{
    public class Program
    {
        private const string apiUrl = "https://jsonplaceholder.typicode.com";
        private const string endPoint = "users";

        public async void runner()
        {
            var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            Console.WriteLine("Get All Users");
            var result = await apiHandler.GetAllAsync();
            foreach (var data in result)
            {
                Console.WriteLine($"ID: {data.Id}, Name: {data.Name}");
            }
        }
        public static async Task Main(string[] args)
        {
            var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            Console.WriteLine("Get All Users");
            var result = await apiHandler.GetAllAsync();
            foreach (var data in result)
            {
                Console.WriteLine($"ID: {data.Id}, Name: {data.Name}");
            }
        }
    }
}