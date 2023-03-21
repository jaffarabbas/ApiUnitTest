using ApiForBddTest.Models;

namespace ApiForBddTest.Repository
{
    public class UserInterface : IUserInterface
    {
        private List<Users> userList = new() {
            new Users()
            {
                Id = 1,
                Name = "John",
                Email = "asd@sd.com"
            },
            new Users()
            {
                Id = 2,
                Name = "John",
                Email = "asasd@asd.com"
            },
            new Users()
            {
                Id = 3,
                Name = "John",
                Email = "asasd@asd.com"
            },
        };
        public IEnumerable<Users> GetAll()
        {
            return userList;
        }

        public Users GetById(int id)
        {
            var result = userList.Find(x => x.Id == id);
            return result;
        }

        public Users PostUser(Users user)
        {
            //var data = new Users()
            //{
            //    Id = user.Id,
            //    Name = user.Name,
            //    Email = user.Email,
            //};
            userList.Add(user);
            return user;
        }

        public Users PutUser(Users usersData, int id)
        {
            var user = userList.Find(x => x.Id == id);
            user.Name = usersData.Name;
            user.Email = usersData.Email;
            return user;
        }
        public Users DeleteUser(int id)
        {
            var user = userList.Find(x => x.Id == id);
            userList.Remove(user);
            return user;
        }
    }
}
