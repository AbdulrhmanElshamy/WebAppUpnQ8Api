namespace WebAppUpnQ8Api.ViewModels.HomeViewModels
{
    public class GetPlanModel
    {
        public int Plan_ID { get; set; }
        public string Plan_Title { get; set; }
        public string Plan_Description { get; set; }
        public Nullable<double> Price_6m { get; set; }
        public Nullable<double> Price_1y { get; set; }
        public Nullable<double> Price_2y { get; set; }
        public Nullable<double> Price_1m { get; set; }

        public List<GetPlanContentModel> Plan_Contents { get; set; }
    }
}
