using BankAppData.DB;
using BankAppData.Helper;
using BankAppData.Model.Helper;
using BankAppData.Repository.Base;
using BankAppData.UnitOfWork;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace BankAppData.Repository.Login
{
    public class LoginRepository : Repository<LoginDB>, ILoginRepository
    {
        public LoginRepository(IUnitOfWork<BankContext> unitOfWork) 
            : base(unitOfWork) { }

        public override LoginDB Add(LoginDB entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override LoginDB? Get(int id)
        {
            string query = "SELECT Id, Username, Password FROM Customers WHERE Id = @Id";

            List<DbParameter> parameters =
            [
                new SqlParameter("@Id", id)
            ];

            return Context.FromSqlQuery<LoginDB>(query, parameters).FirstOrDefault();
        }

        public override IEnumerable<LoginDB> GetAll()
        {
            throw new NotImplementedException();
        }

        public LoginDB? GetCustomerByUsername(string username)
        {
            string query = "SELECT Id, Username, Password FROM Customers WHERE Username = @Username";

            List<DbParameter> parameters =
            [
                new SqlParameter("@Username", username)
            ];

            return Context.FromSqlQuery<LoginDB>(query, parameters).FirstOrDefault();
        }

        public bool Login(LoginDB loginDB)
        {
            throw new NotImplementedException();
        }

        public override LoginDB Update(LoginDB entity)
        {
            throw new NotImplementedException();
        }
    }
}
