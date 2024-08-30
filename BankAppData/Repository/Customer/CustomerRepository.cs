using BankAppData.DB;
using BankAppData.Helper;
using BankAppData.Model;
using BankAppData.Repository.Base;
using BankAppData.UnitOfWork;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace BankAppData.Repository.Customer
{
    public class CustomerRepository : Repository<CustomerDB>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork<BankContext> unitOfWork)
            : base(unitOfWork) { }

        public override CustomerDB Add(CustomerDB entity)
        {
            string query = "INSERT INTO Customers(FirstName, LastName, Username, Password, Country, Region, City, Address) " +
                "OUTPUT inserted.Id " +
                "VALUES(@FirstName, @LastName, @Username, @Password, @Country, @Region, @City, @Address)";

            List<DbParameter> parameters = entity.ToSqlParameters();

            entity.Id = Context.FromSqlQuery<CustomerDB>(query, parameters).First().Id;

            return entity;
        }

        public override bool Delete(int id)
        {
            string query = "DELETE FROM Customers WHERE Id = @Id";

            List<DbParameter> parameters =
            [
                new SqlParameter("@Id", id)
            ];

            return Context.ExecuteQuery(query, parameters) > 0;
        }

        public bool ExistsUsername(string username)
        {
            string query = "SELECT COUNT(*) FROM Customers WHERE Username = @Username";

            List<DbParameter> parameters =
            [
                new SqlParameter("@Username", username)
            ];

            return Context.ExecuteScalar(query, parameters) > 0;
        }

        public override CustomerDB? Get(int id)
        {
            string query = "SELECT Id, FirstName, LastName, Username, Password, Country, Region, City, Address FROM Customers WHERE Id = @Id";

            List<DbParameter> parameters =
            [
                new SqlParameter("@Id", id)
            ];

            return Context.FromSqlQuery<CustomerDB>(query, parameters).FirstOrDefault();
        }

        public override IEnumerable<CustomerDB> GetAll()
        {
            throw new NotImplementedException();
        }

        public override CustomerDB Update(CustomerDB entity)
        {
            string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Username = @Username, Password = @Password, " +
                "Country = @Country, Region = @Region, City = @City, Address = @Address WHERE Id = @Id";

            List<DbParameter> parameters = entity.ToSqlParameters();

            Context.ExecuteQuery(query, parameters);

            return entity;
        }
    }
}
