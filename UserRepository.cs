using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly UPS_UsersContext _userDBContext;
        private bool disposedValue;

        public UserRepository(UPS_UsersContext databaseContext)
        {
            this._userDBContext = databaseContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDBContext.Users.ToList();
            
        } 

        public int GetTransactionCountByUser(string userId)
        {
            int count = 0;
            var userList = _userDBContext.Users.FindAll(x => x.Id == userId);
            foreach (var user in userList)
            {
                count++;
            }
            return count;

        }

        public decimal GetUnpaidAmountByUser(string userId)
        {
            
            decimal dueAmount = 0;
            var UnPaidAmountUser = _userDBContext.Transactions.Where(X => X.UserId.ToString() == userId).FirstOrDefault();
            if (UnPaidAmountUser.UserId != "0" && UnPaidAmountUser.AmountBilled > 0)
            {

                dueAmount = (decimal)(UnPaidAmountUser.AmountBilled - 0);
                if (dueAmount > 0)
                {
                    Console.WriteLine("UnPaid Amount is :" +dueAmount);
                }
               
            }
            return dueAmount;
        }

        public User GetUserById(string id)
        {
            
            var userDetails = _userDBContext.Users.Where(x=> x.Id== id).FirstOrDefault();
            return userDetails;
            
        }

        public IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName)
        {
            var _user = _userDBContext.Users.Where(x => x.FirstName == firstName && x.LastName == lastName);
            return _user;
        }

        public List<User> GetUsersByIdInParallel(List<string> ids)
        {
            List<User> users = new List<User>();
            Parallel.ForEach(ids, id =>
            {
                 
                users.Add(GetUserById(id));
            });
            return users;
        }

        public IEnumerable<User> GetUsersOlderThanGivenAge(int age)
        {
            string currentYear = DateTime.Now.Year.ToString();
            List<User> userList = new List<User>();
            foreach (var user in _userDBContext.Users)
            {
                var olderAge = user.DateofBirth.Year - Convert.ToInt32(currentYear);
                if (olderAge > 0)
                {
                    userList.Add(user);
                }


            }
            return userList;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _userDBContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
        
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
