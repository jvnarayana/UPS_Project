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
        
        public UsersController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        
        }

        // GET: api/Get
        [HttpGet]
        [Route("Get")]
        public IEnumerable<User> Get()
        {


             return _userRepository.GetAllUsers();
          
        }


        [HttpGet("{id}")]
        [Route("GetTransactionCountByUser")]
        public int GetTransactionCountByUser(string userId)
        {
            return _userRepository.GetTransactionCountByUser(userId);
        }

        [HttpGet("{id}")]
        [Route("GetUnpaidAmountByUser")]
        public decimal GetUnpaidAmountByUser(string userId)
        {
            return _userRepository.GetUnpaidAmountByUser(userId);
        }


        [HttpGet("{id}")]
        [Route("GetUserById")]
        public User GetUserById(string id)
        {
            return _userRepository.GetUserById(id);
        }

        [HttpGet]
        [Route("GetUsersByFirstAndLastName")]
        public IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName)
        {
            return _userRepository.GetUsersByFirstAndLastName(firstName, lastName);
        }


        [HttpGet]
        [Route("GetUsersByIdInParallel")]
        public List<User> GetUsersByIdInParallel(List<string> ids)
        {
            return _userRepository.GetUsersByIdInParallel(ids);
        }


        [HttpGet]
        [Route("GetUsersOlderThanGivenAge")]
        public IEnumerable<User> GetUsersOlderThanGivenAge(int age)
        {
            return _userRepository.GetUsersOlderThanGivenAge(age);

        }

    }
}
