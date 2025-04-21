using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUpnQ8Api.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBrandsTbls",
                columns: table => new
                {
                    Company_Brand_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Brand_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Brand_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBrandsTbls", x => x.Company_Brand_ID);
                });

            migrationBuilder.CreateTable(
                name: "ContentsTbls",
                columns: table => new
                {
                    Content_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsTbls", x => x.Content_ID);
                });

            migrationBuilder.CreateTable(
                name: "CountriesTbls",
                columns: table => new
                {
                    Country_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_Flag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesTbls", x => x.Country_ID);
                });

            migrationBuilder.CreateTable(
                name: "DiscountsTbls",
                columns: table => new
                {
                    Discount_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount_Percent = table.Column<double>(type: "float", nullable: true),
                    Discount_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount_Statues = table.Column<bool>(type: "bit", nullable: true),
                    Discount_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount_End_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountsTbls", x => x.Discount_ID);
                });

            migrationBuilder.CreateTable(
                name: "DurationsTbls",
                columns: table => new
                {
                    Duration_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration_Value = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationsTbls", x => x.Duration_ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesTbls",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experince_Years = table.Column<int>(type: "int", nullable: true),
                    Birth_Day_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Personal_Phone_Number = table.Column<long>(type: "bigint", nullable: true),
                    Job_Phone_Number = table.Column<long>(type: "bigint", nullable: true),
                    Employee_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twiter_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkedin_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTbls", x => x.Employee_ID);
                });

            migrationBuilder.CreateTable(
                name: "HomeImagesTbls",
                columns: table => new
                {
                    Home_Image_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home_Image_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Home_Image_Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImagesTbls", x => x.Home_Image_ID);
                });

            migrationBuilder.CreateTable(
                name: "HomePageTbls",
                columns: table => new
                {
                    Home_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Happy_Client_Num = table.Column<int>(type: "int", nullable: true),
                    Projects_Done_Num = table.Column<int>(type: "int", nullable: true),
                    Win_Awards_Num = table.Column<int>(type: "int", nullable: true),
                    Title_AboutUS_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_AboutUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_AboutUS_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_AboutUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_1_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_2_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_3_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_4_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUS_Feature_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_WhyChooseUS_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_WhyChooseUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_1_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_2_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_3_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_4_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Title_WhyChooseUs_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_1_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_2_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_3_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_4_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_WhyChooseUs_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_1_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_2_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_3_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_4_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_WhyChooseUs_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_Products_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_Products = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_OurServices_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_OurServices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_Plans_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_Plans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Footer_Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Footer_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Footer_Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Footer_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_ContactUs_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_ContactUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_RequestAquote_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_RequestAquote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_RequestAquote_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr_RequestAquote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageTbls", x => x.Home_ID);
                });

            migrationBuilder.CreateTable(
                name: "HomeTitlesTbls",
                columns: table => new
                {
                    Home_Title_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Home_Title_Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTitlesTbls", x => x.Home_Title_ID);
                });

            migrationBuilder.CreateTable(
                name: "LoginUserTbls",
                columns: table => new
                {
                    Login_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IP_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Browser_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUserTbls", x => x.Login_ID);
                });

            migrationBuilder.CreateTable(
                name: "MaintinanceContractsTbls",
                columns: table => new
                {
                    Maintinance_Contract_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maintinance_Contract_Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintinance_Contract_Title_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintinance_Contract_Duration = table.Column<int>(type: "int", nullable: true),
                    Duration_By_Month = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintinanceContractsTbls", x => x.Maintinance_Contract_ID);
                });

            migrationBuilder.CreateTable(
                name: "NavbarCarsolsTbls",
                columns: table => new
                {
                    NavbarCarsol_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tilte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tilte_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarCarsolsTbls", x => x.NavbarCarsol_ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypesTbls",
                columns: table => new
                {
                    Payment_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypesTbls", x => x.Payment_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "PlansTbls",
                columns: table => new
                {
                    Plan_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plan_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plan_Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plan_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plan_Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price_6m = table.Column<double>(type: "float", nullable: true),
                    Price_1y = table.Column<double>(type: "float", nullable: true),
                    Price_2y = table.Column<double>(type: "float", nullable: true),
                    Price_1m = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlansTbls", x => x.Plan_ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailsTbls",
                columns: table => new
                {
                    Product_Detail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail_Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail_Description_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailsTbls", x => x.Product_Detail_ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypesTbls",
                columns: table => new
                {
                    Product_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Type_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Type_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypesTbls", x => x.Product_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "ServicesTbls",
                columns: table => new
                {
                    Service_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesTbls", x => x.Service_ID);
                });

            migrationBuilder.CreateTable(
                name: "SocialAccountsTbls",
                columns: table => new
                {
                    SocialAccount_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Social_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAccountsTbls", x => x.SocialAccount_ID);
                });

            migrationBuilder.CreateTable(
                name: "CitiesTbls",
                columns: table => new
                {
                    City_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesTbls", x => x.City_ID);
                    table.ForeignKey(
                        name: "FK_CitiesTbls_CountriesTbls_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "CountriesTbls",
                        principalColumn: "Country_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeNumbersTbls",
                columns: table => new
                {
                    Code_Number_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeNumbersTbls", x => x.Code_Number_ID);
                    table.ForeignKey(
                        name: "FK_CodeNumbersTbls_CountriesTbls_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "CountriesTbls",
                        principalColumn: "Country_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractConditionsTbls",
                columns: table => new
                {
                    Contract_Condition_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contract_Condition_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contract_Condition_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintinance_Contract_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractConditionsTbls", x => x.Contract_Condition_ID);
                    table.ForeignKey(
                        name: "FK_ContractConditionsTbls_MaintinanceContractsTbls_Maintinance_Contract_ID",
                        column: x => x.Maintinance_Contract_ID,
                        principalTable: "MaintinanceContractsTbls",
                        principalColumn: "Maintinance_Contract_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractServicesTbls",
                columns: table => new
                {
                    Contract_Service_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contract_Service_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contract_Service_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintinance_Contract_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractServicesTbls", x => x.Contract_Service_ID);
                    table.ForeignKey(
                        name: "FK_ContractServicesTbls_MaintinanceContractsTbls_Maintinance_Contract_ID",
                        column: x => x.Maintinance_Contract_ID,
                        principalTable: "MaintinanceContractsTbls",
                        principalColumn: "Maintinance_Contract_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanContentsTbls",
                columns: table => new
                {
                    Plan_Content_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content_ID = table.Column<int>(type: "int", nullable: false),
                    Plan_ID = table.Column<int>(type: "int", nullable: false),
                    Content_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_Value_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanContentsTbls", x => x.Plan_Content_ID);
                    table.ForeignKey(
                        name: "FK_PlanContentsTbls_ContentsTbls_Content_ID",
                        column: x => x.Content_ID,
                        principalTable: "ContentsTbls",
                        principalColumn: "Content_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanContentsTbls_PlansTbls_Plan_ID",
                        column: x => x.Plan_ID,
                        principalTable: "PlansTbls",
                        principalColumn: "Plan_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubTypesTbls",
                columns: table => new
                {
                    Product_Sub_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub_Type_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Type_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubTypesTbls", x => x.Product_Sub_Type_ID);
                    table.ForeignKey(
                        name: "FK_ProductSubTypesTbls_ProductTypesTbls_Product_Type_ID",
                        column: x => x.Product_Type_ID,
                        principalTable: "ProductTypesTbls",
                        principalColumn: "Product_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestsQuoteTbls",
                columns: table => new
                {
                    Request_Quote_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custom_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Request_Status = table.Column<bool>(type: "bit", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_ID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsQuoteTbls", x => x.Request_Quote_ID);
                    table.ForeignKey(
                        name: "FK_RequestsQuoteTbls_ServicesTbls_Service_ID",
                        column: x => x.Service_ID,
                        principalTable: "ServicesTbls",
                        principalColumn: "Service_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialFeaturesTbls",
                columns: table => new
                {
                    Special_Feature_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feature_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feature_Price = table.Column<double>(type: "float", nullable: true),
                    Service_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialFeaturesTbls", x => x.Special_Feature_ID);
                    table.ForeignKey(
                        name: "FK_SpecialFeaturesTbls_ServicesTbls_Service_ID",
                        column: x => x.Service_ID,
                        principalTable: "ServicesTbls",
                        principalColumn: "Service_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubServicesTbls",
                columns: table => new
                {
                    Sub_Service_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub_Service_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Service_Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Service_Price = table.Column<double>(type: "float", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubServicesTbls", x => x.Sub_Service_ID);
                    table.ForeignKey(
                        name: "FK_SubServicesTbls_ServicesTbls_Service_ID",
                        column: x => x.Service_ID,
                        principalTable: "ServicesTbls",
                        principalColumn: "Service_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersTbls",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth_Day_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone_Number_1 = table.Column<long>(type: "bigint", nullable: true),
                    Phone_Number_2 = table.Column<long>(type: "bigint", nullable: true),
                    Address_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_ID = table.Column<int>(type: "int", nullable: true),
                    City_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Register_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password_Confirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code_Number_ID_1 = table.Column<int>(type: "int", nullable: false),
                    IP_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersTbls", x => x.Customer_ID);
                    table.ForeignKey(
                        name: "FK_CustomersTbls_CitiesTbls_City_ID",
                        column: x => x.City_ID,
                        principalTable: "CitiesTbls",
                        principalColumn: "City_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersTbls_CodeNumbersTbls_Code_Number_ID_1",
                        column: x => x.Code_Number_ID_1,
                        principalTable: "CodeNumbersTbls",
                        principalColumn: "Code_Number_ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTbls",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number_Piecies = table.Column<int>(type: "int", nullable: true),
                    Sale_Price = table.Column<double>(type: "float", nullable: true),
                    Buy_Price = table.Column<double>(type: "float", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Sub_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Discount_Percent = table.Column<double>(type: "float", nullable: true),
                    Company_Brand_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTbls", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_ProductsTbls_CompanyBrandsTbls_Company_Brand_ID",
                        column: x => x.Company_Brand_ID,
                        principalTable: "CompanyBrandsTbls",
                        principalColumn: "Company_Brand_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsTbls_ProductSubTypesTbls_Product_Sub_Type_ID",
                        column: x => x.Product_Sub_Type_ID,
                        principalTable: "ProductSubTypesTbls",
                        principalColumn: "Product_Sub_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubTypeSpecificationsTbls",
                columns: table => new
                {
                    Product_Sub_Type_Specific_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub_Type_Specific_Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Type_Specific_Name_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Sub_Type_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubTypeSpecificationsTbls", x => x.Product_Sub_Type_Specific_ID);
                    table.ForeignKey(
                        name: "FK_ProductSubTypeSpecificationsTbls_ProductSubTypesTbls_Product_Sub_Type_ID",
                        column: x => x.Product_Sub_Type_ID,
                        principalTable: "ProductSubTypesTbls",
                        principalColumn: "Product_Sub_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubFeaturesTbls",
                columns: table => new
                {
                    Sub_Feature_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub_Feature_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Feature_Text_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Service_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFeaturesTbls", x => x.Sub_Feature_ID);
                    table.ForeignKey(
                        name: "FK_SubFeaturesTbls_SubServicesTbls_Sub_Service_ID",
                        column: x => x.Sub_Service_ID,
                        principalTable: "SubServicesTbls",
                        principalColumn: "Sub_Service_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintinanceRequestsTbls",
                columns: table => new
                {
                    Maintinance_Request_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maintinance_Contract_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Request_Statues = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintinanceRequestsTbls", x => x.Maintinance_Request_ID);
                    table.ForeignKey(
                        name: "FK_MaintinanceRequestsTbls_CustomersTbls_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CustomersTbls",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintinanceRequestsTbls_MaintinanceContractsTbls_Maintinance_Contract_ID",
                        column: x => x.Maintinance_Contract_ID,
                        principalTable: "MaintinanceContractsTbls",
                        principalColumn: "Maintinance_Contract_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanSubscripesTbls",
                columns: table => new
                {
                    Plan_Subscripe_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Subscription_Price = table.Column<double>(type: "float", nullable: true),
                    Plan_ID = table.Column<int>(type: "int", nullable: false),
                    Discount_ID = table.Column<int>(type: "int", nullable: false),
                    Subscription_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subscription_End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationInMonth = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subscripe_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSubscripesTbls", x => x.Plan_Subscripe_ID);
                    table.ForeignKey(
                        name: "FK_PlanSubscripesTbls_CustomersTbls_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CustomersTbls",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSubscripesTbls_DiscountsTbls_Discount_ID",
                        column: x => x.Discount_ID,
                        principalTable: "DiscountsTbls",
                        principalColumn: "Discount_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSubscripesTbls_PlansTbls_Plan_ID",
                        column: x => x.Plan_ID,
                        principalTable: "PlansTbls",
                        principalColumn: "Plan_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestsTbls",
                columns: table => new
                {
                    Service_Request_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Service_Request_Statues = table.Column<bool>(type: "bit", nullable: true),
                    Service_Request_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Service_Response_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sub_Service_ID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request_Status = table.Column<int>(type: "int", nullable: true),
                    Service_Active_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Requset_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finished_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Renewal_price = table.Column<double>(type: "float", nullable: true),
                    Renewal_request = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestsTbls", x => x.Service_Request_ID);
                    table.ForeignKey(
                        name: "FK_ServiceRequestsTbls_CustomersTbls_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CustomersTbls",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequestsTbls_SubServicesTbls_Sub_Service_ID",
                        column: x => x.Sub_Service_ID,
                        principalTable: "SubServicesTbls",
                        principalColumn: "Sub_Service_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRequestsTbls",
                columns: table => new
                {
                    Special_Request_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Requset_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRequestsTbls", x => x.Special_Request_ID);
                    table.ForeignKey(
                        name: "FK_SpecialRequestsTbls_CustomersTbls_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CustomersTbls",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialRequestsTbls_ServicesTbls_Service_ID",
                        column: x => x.Service_ID,
                        principalTable: "ServicesTbls",
                        principalColumn: "Service_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionsTbls",
                columns: table => new
                {
                    Subscription_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Subscription_Price = table.Column<double>(type: "float", nullable: true),
                    Princing_Duration_ID = table.Column<int>(type: "int", nullable: true),
                    Discount_ID = table.Column<int>(type: "int", nullable: false),
                    Payment_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Subscription_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subscription_End_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionsTbls", x => x.Subscription_ID);
                    table.ForeignKey(
                        name: "FK_SubscriptionsTbls_CustomersTbls_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CustomersTbls",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionsTbls_DiscountsTbls_Discount_ID",
                        column: x => x.Discount_ID,
                        principalTable: "DiscountsTbls",
                        principalColumn: "Discount_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionsTbls_PaymentTypesTbls_Payment_Type_ID",
                        column: x => x.Payment_Type_ID,
                        principalTable: "PaymentTypesTbls",
                        principalColumn: "Payment_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestmonialsTbls",
                columns: table => new
                {
                    Testmonial_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Rating_Stars = table.Column<int>(type: "int", nullable: true),
                    Testmonial_Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestmonialsTbls", x => x.Testmonial_ID);
                    table.ForeignKey(
                        name: "FK_TestmonialsTbls_CustomersTbls_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CustomersTbls",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationsTbls",
                columns: table => new
                {
                    Evaluation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Evaluation_Stars = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evaluation_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationsTbls", x => x.Evaluation_ID);
                    table.ForeignKey(
                        name: "FK_EvaluationsTbls_ProductsTbls_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "ProductsTbls",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSalesTbls",
                columns: table => new
                {
                    Product_Sale_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sale_Price = table.Column<double>(type: "float", nullable: true),
                    Sale_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSalesTbls", x => x.Product_Sale_ID);
                    table.ForeignKey(
                        name: "FK_ProductSalesTbls_ProductsTbls_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "ProductsTbls",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecificationsTbls",
                columns: table => new
                {
                    Product_Specificate_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Sub_Type_Specific_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Product_Specificate_Value_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Specificate_Value_Eng = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecificationsTbls", x => x.Product_Specificate_ID);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationsTbls_ProductSubTypeSpecificationsTbls_Product_Sub_Type_Specific_ID",
                        column: x => x.Product_Sub_Type_Specific_ID,
                        principalTable: "ProductSubTypeSpecificationsTbls",
                        principalColumn: "Product_Sub_Type_Specific_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationsTbls_ProductsTbls_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "ProductsTbls",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlanSubscripeContentsTbls",
                columns: table => new
                {
                    Subscripe_Content_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plan_Subscripe_ID = table.Column<int>(type: "int", nullable: false),
                    Content_ID = table.Column<int>(type: "int", nullable: false),
                    Current_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSubscripeContentsTbls", x => x.Subscripe_Content_ID);
                    table.ForeignKey(
                        name: "FK_PlanSubscripeContentsTbls_ContentsTbls_Content_ID",
                        column: x => x.Content_ID,
                        principalTable: "ContentsTbls",
                        principalColumn: "Content_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSubscripeContentsTbls_PlanSubscripesTbls_Plan_Subscripe_ID",
                        column: x => x.Plan_Subscripe_ID,
                        principalTable: "PlanSubscripesTbls",
                        principalColumn: "Plan_Subscripe_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRequestFeaturesTbls",
                columns: table => new
                {
                    Special_Request_Feature_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Special_Request_ID = table.Column<int>(type: "int", nullable: false),
                    Special_Feature_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRequestFeaturesTbls", x => x.Special_Request_Feature_ID);
                    table.ForeignKey(
                        name: "FK_SpecialRequestFeaturesTbls_SpecialFeaturesTbls_Special_Feature_ID",
                        column: x => x.Special_Feature_ID,
                        principalTable: "SpecialFeaturesTbls",
                        principalColumn: "Special_Feature_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialRequestFeaturesTbls_SpecialRequestsTbls_Special_Request_ID",
                        column: x => x.Special_Request_ID,
                        principalTable: "SpecialRequestsTbls",
                        principalColumn: "Special_Request_ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTbls_Country_ID",
                table: "CitiesTbls",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CodeNumbersTbls_Country_ID",
                table: "CodeNumbersTbls",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractConditionsTbls_Maintinance_Contract_ID",
                table: "ContractConditionsTbls",
                column: "Maintinance_Contract_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractServicesTbls_Maintinance_Contract_ID",
                table: "ContractServicesTbls",
                column: "Maintinance_Contract_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTbls_City_ID",
                table: "CustomersTbls",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTbls_Code_Number_ID_1",
                table: "CustomersTbls",
                column: "Code_Number_ID_1");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsTbls_Product_ID",
                table: "EvaluationsTbls",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintinanceRequestsTbls_Customer_ID",
                table: "MaintinanceRequestsTbls",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintinanceRequestsTbls_Maintinance_Contract_ID",
                table: "MaintinanceRequestsTbls",
                column: "Maintinance_Contract_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanContentsTbls_Content_ID",
                table: "PlanContentsTbls",
                column: "Content_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanContentsTbls_Plan_ID",
                table: "PlanContentsTbls",
                column: "Plan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSubscripeContentsTbls_Content_ID",
                table: "PlanSubscripeContentsTbls",
                column: "Content_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSubscripeContentsTbls_Plan_Subscripe_ID",
                table: "PlanSubscripeContentsTbls",
                column: "Plan_Subscripe_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSubscripesTbls_Customer_ID",
                table: "PlanSubscripesTbls",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSubscripesTbls_Discount_ID",
                table: "PlanSubscripesTbls",
                column: "Discount_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSubscripesTbls_Plan_ID",
                table: "PlanSubscripesTbls",
                column: "Plan_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSalesTbls_Product_ID",
                table: "ProductSalesTbls",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationsTbls_Product_ID",
                table: "ProductSpecificationsTbls",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationsTbls_Product_Sub_Type_Specific_ID",
                table: "ProductSpecificationsTbls",
                column: "Product_Sub_Type_Specific_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTbls_Company_Brand_ID",
                table: "ProductsTbls",
                column: "Company_Brand_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTbls_Product_Sub_Type_ID",
                table: "ProductsTbls",
                column: "Product_Sub_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubTypeSpecificationsTbls_Product_Sub_Type_ID",
                table: "ProductSubTypeSpecificationsTbls",
                column: "Product_Sub_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubTypesTbls_Product_Type_ID",
                table: "ProductSubTypesTbls",
                column: "Product_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsQuoteTbls_Service_ID",
                table: "RequestsQuoteTbls",
                column: "Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestsTbls_Customer_ID",
                table: "ServiceRequestsTbls",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestsTbls_Sub_Service_ID",
                table: "ServiceRequestsTbls",
                column: "Sub_Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialFeaturesTbls_Service_ID",
                table: "SpecialFeaturesTbls",
                column: "Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRequestFeaturesTbls_Special_Feature_ID",
                table: "SpecialRequestFeaturesTbls",
                column: "Special_Feature_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRequestFeaturesTbls_Special_Request_ID",
                table: "SpecialRequestFeaturesTbls",
                column: "Special_Request_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRequestsTbls_Customer_ID",
                table: "SpecialRequestsTbls",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRequestsTbls_Service_ID",
                table: "SpecialRequestsTbls",
                column: "Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubFeaturesTbls_Sub_Service_ID",
                table: "SubFeaturesTbls",
                column: "Sub_Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionsTbls_Customer_ID",
                table: "SubscriptionsTbls",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionsTbls_Discount_ID",
                table: "SubscriptionsTbls",
                column: "Discount_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionsTbls_Payment_Type_ID",
                table: "SubscriptionsTbls",
                column: "Payment_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubServicesTbls_Service_ID",
                table: "SubServicesTbls",
                column: "Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TestmonialsTbls_Customer_ID",
                table: "TestmonialsTbls",
                column: "Customer_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractConditionsTbls");

            migrationBuilder.DropTable(
                name: "ContractServicesTbls");

            migrationBuilder.DropTable(
                name: "DurationsTbls");

            migrationBuilder.DropTable(
                name: "EmployeesTbls");

            migrationBuilder.DropTable(
                name: "EvaluationsTbls");

            migrationBuilder.DropTable(
                name: "HomeImagesTbls");

            migrationBuilder.DropTable(
                name: "HomePageTbls");

            migrationBuilder.DropTable(
                name: "HomeTitlesTbls");

            migrationBuilder.DropTable(
                name: "LoginUserTbls");

            migrationBuilder.DropTable(
                name: "MaintinanceRequestsTbls");

            migrationBuilder.DropTable(
                name: "NavbarCarsolsTbls");

            migrationBuilder.DropTable(
                name: "PlanContentsTbls");

            migrationBuilder.DropTable(
                name: "PlanSubscripeContentsTbls");

            migrationBuilder.DropTable(
                name: "ProductDetailsTbls");

            migrationBuilder.DropTable(
                name: "ProductSalesTbls");

            migrationBuilder.DropTable(
                name: "ProductSpecificationsTbls");

            migrationBuilder.DropTable(
                name: "RequestsQuoteTbls");

            migrationBuilder.DropTable(
                name: "ServiceRequestsTbls");

            migrationBuilder.DropTable(
                name: "SocialAccountsTbls");

            migrationBuilder.DropTable(
                name: "SpecialRequestFeaturesTbls");

            migrationBuilder.DropTable(
                name: "SubFeaturesTbls");

            migrationBuilder.DropTable(
                name: "SubscriptionsTbls");

            migrationBuilder.DropTable(
                name: "TestmonialsTbls");

            migrationBuilder.DropTable(
                name: "MaintinanceContractsTbls");

            migrationBuilder.DropTable(
                name: "ContentsTbls");

            migrationBuilder.DropTable(
                name: "PlanSubscripesTbls");

            migrationBuilder.DropTable(
                name: "ProductSubTypeSpecificationsTbls");

            migrationBuilder.DropTable(
                name: "ProductsTbls");

            migrationBuilder.DropTable(
                name: "SpecialFeaturesTbls");

            migrationBuilder.DropTable(
                name: "SpecialRequestsTbls");

            migrationBuilder.DropTable(
                name: "SubServicesTbls");

            migrationBuilder.DropTable(
                name: "PaymentTypesTbls");

            migrationBuilder.DropTable(
                name: "DiscountsTbls");

            migrationBuilder.DropTable(
                name: "PlansTbls");

            migrationBuilder.DropTable(
                name: "CompanyBrandsTbls");

            migrationBuilder.DropTable(
                name: "ProductSubTypesTbls");

            migrationBuilder.DropTable(
                name: "CustomersTbls");

            migrationBuilder.DropTable(
                name: "ServicesTbls");

            migrationBuilder.DropTable(
                name: "ProductTypesTbls");

            migrationBuilder.DropTable(
                name: "CitiesTbls");

            migrationBuilder.DropTable(
                name: "CodeNumbersTbls");

            migrationBuilder.DropTable(
                name: "CountriesTbls");
        }
    }
}
