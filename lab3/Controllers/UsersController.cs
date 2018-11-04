using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.model;
using web_api.Service;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService = new UserService();

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.findAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.find(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Unable to find user with id: " + id);
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return _userService.save(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            var savedUser = _userService.unpdate(id, user);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Unable to update user with id: " + id);
            }

            return savedUser;
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var deletedUser = _userService.delete(id);
            if (deletedUser == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Unable to delete user with id: " + id);
            }

            return deletedUser;
        }
    }
}