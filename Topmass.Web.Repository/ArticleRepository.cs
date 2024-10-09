using Microsoft.Extensions.Configuration;
using Topmass.Core.Model;
using Topmass.Core.Repository;
using Topmass.Web.Repository.Model;

namespace Topmass.Web.Repository
{
    public class ArticleRepository : RepositoryBase<ArticleModel>, IArticleRepository
    {
        public ArticleRepository(IConfiguration configuration)
            : base(configuration)
        {
            tableName = "Articles";
        }

        public async Task<GetAllArticleReponse> GetAll(ArticleFilter request)
        {
            var reponse = new GetAllArticleReponse();
            var allData = await this.ExecutePro<ArticleIndexModel>("ArticleGetAll", request);
            reponse.Data = allData;
            return reponse;
        }
        public async Task<GetAllArticleReponse> GetAllShort(ArticleFilter request)
        {
            var reponse = new GetAllArticleReponse();
            var allData = await this.ExecutePro<ArticleIndexModel>("ArticleGetAll", request);
            reponse.Data = allData;
            return reponse;
        }
        public async Task<GetAllByCategoryReponse> GetAllCategory()
        {
            var reponse = new GetAllByCategoryReponse();
            var allData = await this.GetAllByStatementSql<CategoryAritcleIndexModel>("select * from CategoryArticle ", new { });
            reponse.Data = allData;
            return reponse;
        }
    }
}
