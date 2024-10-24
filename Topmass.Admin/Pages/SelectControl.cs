namespace Topmass.Admin.Pages

{
    public class SelectControl : ControlItem
    {
        public List<dynamic> DataSource { get; set; }
        public SelectControl()
        {
            Type = 7;
            DataSource = new List<dynamic>();
        }

    }



}