namespace ConsoleApp1
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UpdatedBy { get; set; }
        public int Status { get; set; }
        public bool Deleted { get; set; }
        public BaseModel()
        {
            Id = -1;
        }
    }
}
