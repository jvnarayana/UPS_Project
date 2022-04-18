// Important note
// Please be sure to make sure this codes compiles properly in Visual Studio and the code has been tested

using Interview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace Interview
{
    /// <summary>
    /// Given a database context consisting of Users and Transactions, implement the methods in this interface
    /// to act as a repository layer. The DatabaseContext class should be injected via dependency injection.
    /// The User and Transaction classes are defined below.
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Returns all users from the database.
        /// </summary>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Gets the total number of transaction for a given user ID.
        /// </summary>
        int GetTransactionCountByUser(string userId);

        /// <summary>
        /// Gets the total unpaid amount by userID
        /// </summary>
        decimal GetUnpaidAmountByUser(string userId);

        /// <summary>
        /// Returns a user with the given ID.
        /// </summary>
        User GetUserById(string id);

        /// <summary>
        /// Gets users with given first and last name.
        /// </summary>
        IEnumerable<User> GetUsersByFirstAndLastName(string firstName, string lastName);

        /// <summary>
        /// Assuming the mock database is CPU bound,
        /// write code that gets multiple users by Id
        /// in parallel from the database.
        /// </summary>
        List<User> GetUsersByIdInParallel(List<string> ids);

        /// <summary>
        /// Gets users older than given age.
        /// </summary>
        IEnumerable<User> GetUsersOlderThanGivenAge(int age);
    }


    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
    }

    //Table[]
    public class Transaction
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountBilled { get; set; }
        public DateTime? DatePaid { get; set; }
    }

    //public class DatabaseContext
    //{
    //    public List<User> Users { get; set; }
    //    public List<Transaction> Transactions { get; set; }
    //}


}