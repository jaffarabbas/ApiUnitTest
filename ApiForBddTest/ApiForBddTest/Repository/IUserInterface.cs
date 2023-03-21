using ApiForBddTest.Models;

namespace ApiForBddTest.Repository
{
    public interface IUserInterface
    {
        public IEnumerable<Users> GetAll();
        public Users GetById(int id);
        public Users PostUser(Users user);
        public Users PutUser(Users users, int id);
        public Users DeleteUser(int id);
    }
}
