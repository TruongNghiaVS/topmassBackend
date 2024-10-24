using System.Data;
using Topmass.Core.Repository;

namespace Topmass.Campagn.Repository
{
    public interface IAdminRepository
    {
        public IEmployeeeRepository EmployeeRepository { get; set; }
        public ICompanyInfoRepository CompanyInfoRepository { get; set; }


        public Task<TmodelGet> FindOneByStatementSql<TmodelGet>(string sqlText,
           object param) where TmodelGet : class, new();
        public Task<List<TmodelGet>> GetAllByStatementSql<TmodelGet>(string sqlText,
            object param) where TmodelGet : class, new();
        public Task<List<TIndexModel>> ExecuteSqlProcerduceToList<TIndexModel>
            (string sql = "",
           object parameter = null,
           CommandType commandType = CommandType.StoredProcedure);
        public Task<T> ExecuteSqlProcedure<T>(string sql = "",
            object parameter = null)
            where T : class, new();
        public Task<bool> ExecuteStatementSql(string sql = "",
        object parameter = null);

    }
}
