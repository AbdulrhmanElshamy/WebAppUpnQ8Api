namespace WebAppUpnQ8Api.ViewModels.PlanViewModels
{
    public class PlanSubscripModel
    {
        public int Plan_Subscripe_ID { get; set; }
        public string Customer_ID { get; set; }
        public Nullable<double> Subscription_Price { get; set; }
        public int Plan_ID { get; set; }
        public Nullable<int> Discount_ID { get; set; }
        public Nullable<System.DateTime> Subscription_Start_Date { get; set; }
        public Nullable<System.DateTime> Subscription_End_Date { get; set; }
        public Nullable<int> DurationInMonth { get; set; }
        public string Id { get; set; }
        public string Subscripe_Code { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Plan_Title { get; set; }
        public string Plan_Description { get; set; }
        public string Plan_Title_Ar { get; set; }
        public string Plan_Description_Ar { get; set; }

        public Nullable<double> Discount_Percent { get; set; }

        public Nullable<double> Price_6m { get; set; }
        public Nullable<double> Price_1y { get; set; }
        public Nullable<double> Price_2y { get; set; }
        public Nullable<double> Price_1m { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }

        public Nullable<double> Final_Price { get; set; }
        public bool status { get; set; }


        public List<PlaneSubscripContentModel> planeSubscripContents { get; set; }
    }
}
