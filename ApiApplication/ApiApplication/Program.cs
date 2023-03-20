using ApiApplication.Model;
using System.Threading.Tasks;
using System;

namespace ApiApplication
{
    public class Program
    {
        private const string apiUrl = "https://jsonplaceholder.typicode.com";
        private const string endPoint = "users";
        private List<User> result;
        public async Task<List<User>> runner()
        {
            var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            result = await apiHandler.GetAllAsync();
            return result;
        }
        
        public async Task<User> getUserById(int id)
        {
            var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var result = await apiHandler.GetByIdAsync(id);
            return result;
        }

        public static async Task Main(string[] args)
        {
            Program obj = new Program();
            await obj.runner();
            var o = await obj.getUserById(1);
            Console.WriteLine(o.Name);
        }
    }
}