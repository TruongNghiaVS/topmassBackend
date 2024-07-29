using Microsoft.Extensions.Configuration;
using Topmass.Core.Model;

namespace Topmass.Core.Repository
{
    public class RepositoryBase<TModel> : BaseDataAccess,
        IBaseRepository<TModel> where TModel : BaseModel, new()
    {
        public RepositoryBase(IConfiguration configuration) : base(configuration)
        {

        }
        private async Task<bool> Add(TModel itemModel)
        {
            string[] ignore = { nameof(itemModel.UpdatedBy), nameof(itemModel.Id), nameof(itemModel.UpdateAt), nameof(itemModel.CreateAt),
            nameof(itemModel.Deleted)};
            var columnInsert = "";
            var valueInsert = "";
            var sqlText = " insert into table " + tableName + " (" + columnInsert + ") values (" + valueInsert + ") ";
            var properties = itemModel.GetType().GetProperties();
            foreach (var item in properties)
            {
                var nameProper = item.Name;
                var valueProper = item.GetValue(itemModel);
                if (valueProper == null)
                {
                    continue;
                }
                columnInsert += nameProper + ",";
                valueInsert += valueProper + ",";
            }
            if (columnInsert.EndsWith(","))
            {
                columnInsert.Remove(columnInsert.Length - 1);
            }
            if (valueInsert.EndsWith(","))
            {
                valueInsert.Remove(valueInsert.Length - 1);

            }
            return await ExecuteSQLText(sqlText);
        }
        public async Task<bool> AddOrUPdate(TModel itemModel)
        {
            if (itemModel.Id < 1)
                return await Add(itemModel);
            else
                return await Update(itemModel);

        }
        public async Task<bool> Delete(int id)
        {
            return await DeleteBase(id, tableDelete: tableName);
        }

        public async Task<bool> Delete(TModel itemModel)
        {
            if (itemModel.Id < 1)
            {
                return false;
            }
            return await DeleteBase(itemModel.Id, tableDelete: tableName);
        }

        public async Task<IEnumerable<TModel>> GetAllBase()
        {
            var sqlText = " select top 1000 * from " + tableName + " order by Id desc";
            var result = await ExecuteSQL<TModel>(sqlText, null, System.Data.CommandType.Text);
            return result;
        }
        public async Task<TModel> GetById(int id)
        {
            return await GetByIdBase<TModel>(id);
        }
        private async Task<bool> Update(TModel itemModel)
        {
            return await UpdateBasic(itemModel);
        }
    }
}
