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
            throw new NotImplementedException();
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
            User u = new User();
            var userDetails = _userDBContext.Users.Where(x=> x.Id== id).FirstOrDefault();
            return userDetails;
            
        }

        public IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName)
        {
            var _user = _userDBContext.Users.Where(x => x.FirstName == firstName && x.LastName == lastName);
            return (IEnumerable<User>)_user.ToList();
        }

        public List<User> GetUsersByIdInParallel(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersOlderThanGivenAge(int age)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _userDBContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
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
