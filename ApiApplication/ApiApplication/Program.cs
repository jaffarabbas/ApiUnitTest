using ApiApplication.Model;
using System.Threading.Tasks;
using System;

namespace ApiApplication
{
    public class Program
    {
        private const string apiUrl = "https://localhost:7295/api";
        private const string endPoint = "user";
        private List<User> result;
        public async Task<List<User>> runner()
        {
            var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            result = await apiHandler.GetAllAsync();
            return result;
        }

        public async Task AddUser(User user)
        {
            var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            User data = await apiHandler.CreateAsync(user);
            Console.Out.WriteLine("ID : "+data.Id);
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
            //var o = await obj.getUserById(1);
            //Console.WriteLine(o.Name);

            await obj.AddUser(new User()
            {
                Id = 4,
                Name = "tasdasd",
                Email = "dasdas"
            });
        }
    }
}