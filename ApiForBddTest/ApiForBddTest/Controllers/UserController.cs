using ApiForBddTest.Models;
using ApiForBddTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForBddTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userInterface.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userInterface.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostUser(Users user)
        {
            var result = _userInterface.PostUser(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(Users usersData, int id)
        {
            var result = _userInterface.PutUser(usersData, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userInterface.DeleteUser(id);
            return Ok(result);
        }
    }
}
