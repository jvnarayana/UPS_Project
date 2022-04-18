using Interview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public readonly UPS_UsersContext _context;
        public UsersController(IUserRepository userRepository, UPS_UsersContext context)
        {
            this._userRepository = userRepository;
            this._context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            // return _userRepository.GetAllUsers();
            return _context.Users.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userRepository.GetUserById(id);
        }

    }
}
