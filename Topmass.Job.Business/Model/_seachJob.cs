namespace Topmass.Job.Business.Model
{
    public class GetAllBestJobOptimizationRequest
    {
        public int? Limit { get; set; }
        public int? Page { get; set; }
        public string? OrderBy { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? ValueType { get; set; }
        public string? TypeSearch { get; set; }

        public int? UserId { get; set; }

        public GetAllBestJobOptimizationRequest()
        {
            UserId = 0;
        }

    }

    public class GetSuitableJobRequest
    {
        public string LocationSearch { get; set; }

        public int UserId { get; set; }
        public GetSuitableJobRequest()
        {
            UserId = 0;
        }
    }

    public class SearchJobRequest
    {
        public string? KeyWord { get; set; }

        public int? TypeOfWork { get; set; }

        public int? RankLevel { get; set; }

        public int? Location { get; set; }

        public int? Field { get; set; }

        public int? ModeGet { get; set; }

        public int UserId { get; set; }

        public SearchJobRequest()
        {
            UserId = 0;
        }




    }

    public class GetAttractiveJobs : GetSuitableJobRequest
    {
        public int? UserId { get; set; }
        public GetAttractiveJobs()
        {
            UserId = -1;
        }
    }



    public class GetAllBestJobOptimizationReponse
    {

        public List<BestJobOptimizationDisplayItemData> Data { get; set; }

        public GetAllBestJobOptimizationReponse()
        {
            Data = new List<BestJobOptimizationDisplayItemData>();
        }


    }


}
