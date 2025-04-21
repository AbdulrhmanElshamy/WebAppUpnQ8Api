using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class HomePageTbl
    {
        [Key]
        public int Home_ID { get; set; }
        public Nullable<int> Happy_Client_Num { get; set; }
        public Nullable<int> Projects_Done_Num { get; set; }
        public Nullable<int> Win_Awards_Num { get; set; }
        public string Title_AboutUS_Ar { get; set; }
        public string Title_AboutUS { get; set; }
        public string Description_AboutUS_Ar { get; set; }
        public string Description_AboutUS { get; set; }
        public string AboutUS_Feature_1_Ar { get; set; }
        public string AboutUS_Feature_1 { get; set; }
        public string AboutUS_Feature_2_Ar { get; set; }
        public string AboutUS_Feature_2 { get; set; }
        public string AboutUS_Feature_3_Ar { get; set; }
        public string AboutUS_Feature_3 { get; set; }
        public string AboutUS_Feature_4_Ar { get; set; }
        public string AboutUS_Feature_4 { get; set; }
        public string Title_WhyChooseUS_Ar { get; set; }
        public string Title_WhyChooseUS { get; set; }
        public string Sub_Title_WhyChooseUs_1_Ar { get; set; }
        public string Sub_Title_WhyChooseUs_1 { get; set; }
        public string Sub_Title_WhyChooseUs_2_Ar { get; set; }
        public string Sub_Title_WhyChooseUs_2 { get; set; }
        public string Sub_Title_WhyChooseUs_3_Ar { get; set; }
        public string Sub_Title_WhyChooseUs_3 { get; set; }
        public string Sub_Title_WhyChooseUs_4_Ar { get; set; }
        public string Sub_Title_WhyChooseUs_4 { get; set; }
        public string Descr_WhyChooseUs_1_Ar { get; set; }
        public string Descr_WhyChooseUs_1 { get; set; }
        public string Descr_WhyChooseUs_2_Ar { get; set; }
        public string Descr_WhyChooseUs_2 { get; set; }
        public string Descr_WhyChooseUs_3_Ar { get; set; }
        public string Descr_WhyChooseUs_3 { get; set; }
        public string Descr_WhyChooseUs_4_Ar { get; set; }
        public string Descr_WhyChooseUs_4 { get; set; }
        public string Logo_WhyChooseUs_1_Ar { get; set; }
        public string Logo_WhyChooseUs_1 { get; set; }
        public string Logo_WhyChooseUs_2_Ar { get; set; }
        public string Logo_WhyChooseUs_2 { get; set; }
        public string Logo_WhyChooseUs_3_Ar { get; set; }
        public string Logo_WhyChooseUs_3 { get; set; }
        public string Logo_WhyChooseUs_4_Ar { get; set; }
        public string Logo_WhyChooseUs_4 { get; set; }
        public string Title_Products_Ar { get; set; }
        public string Title_Products { get; set; }
        public string Title_OurServices_Ar { get; set; }
        public string Title_OurServices { get; set; }
        public string Title_Plans_Ar { get; set; }
        public string Title_Plans { get; set; }
        public string Footer_Title_Ar { get; set; }
        public string Footer_Title { get; set; }
        public string Footer_Description_Ar { get; set; }
        public string Footer_Description { get; set; }
        public string Title_ContactUs_Ar { get; set; }
        public string Title_ContactUs { get; set; }
        public string Title_RequestAquote_Ar { get; set; }
        public string Title_RequestAquote { get; set; }
        public string Descr_RequestAquote_Ar { get; set; }
        public string Descr_RequestAquote { get; set; }
    }
}
