using BankAppData.DB;
using BankAppData.Helper;
using BankAppData.Model;
using BankAppData.Repository.Base;
using BankAppData.UnitOfWork;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace BankAppData.Repository.Account
{
    public class AccountRepository : Repository<AccountDB>, IAccountRepository
    {
        public AccountRepository(IUnitOfWork<BankContext> unitOfWork)
            : base(unitOfWork) { }

        public override AccountDB Add(AccountDB entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override AccountDB Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<AccountDB> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDB> GetAll(int customerId)
        {
            string query = "SELECT AccountNumber, Description, CustomerId FROM Accounts WHERE CustomerId = @CustomerId";

            List<DbParameter> parameters =
            [
                new SqlParameter("@CustomerId", customerId)
            ];

            return Context.FromSqlQuery<AccountDB>(query, parameters);
        }

        public override AccountDB Update(AccountDB entity)
        {
            throw new NotImplementedException();
        }
    }
}
