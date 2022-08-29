using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ConToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfCustomers obj = new ListOfCustomers();

            Application excelApp = new Application();

            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\KoduvayurAghoraAravi\source\VS\ExcelTask\ExcelTasks\Schools_BTS2021_dump-SR-ExceptionList1.xlsx");

            _Worksheet excelSheet = excelBook.Sheets[1];

            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;

            int cols = excelRange.Columns.Count;

            for (int i = 2; i <= rows; i++)
            {
                int j = 1;

                while (j <= cols)
                {
                    string state = excelRange.Cells[i, j++].Value2.ToString(); ;
                    double districtpid = excelRange.Cells[i, j++].Value2;
                    string districtName = excelRange.Cells[i, j++].Value2.ToString();
                    string schoolpid = excelRange.Cells[i, j++].Value2.ToString();
                    string SchoolName = excelRange.Cells[i, j++].Value2.ToString();
                    string EdEnabled = excelRange.Cells[i, j++].Value2.ToString();
                    string CreatedDate = excelRange.Cells[i, j++].Value2.ToString();
                    string LastLoggedIn = excelRange.Cells[i, j++].Value2.ToString();
                    string schoolYear_startdate = excelRange.Cells[i, j++].Value2.ToString();
                    string schoolYear_enddate = excelRange.Cells[i, j++].Value2.ToString();
                    string SchoolYearActive = excelRange.Cells[i, j++].Value2.ToString();
                    string ela_subscription = excelRange.Cells[i, j++].Value2.ToString();
                    string math_subscription = excelRange.Cells[i, j++].Value2.ToString();
                    string sub_startdate = excelRange.Cells[i, j++].Value2.ToString();
                    string sub_enddate = excelRange.Cells[i, j++].Value2.ToString();
                    string sub_active = excelRange.Cells[i, j++].Value2.ToString();
                    string DistrictId = excelRange.Cells[i, j++].Value2.ToString();
                    string SchoolId = excelRange.Cells[i, j++].Value2.ToString();
                    string ssoProvider = excelRange.Cells[i, j++].Value2.ToString();
                    double IsArchived = excelRange.Cells[i, j++].Value2;
                    string Rollover2021 = excelRange.Cells[i, j++].Value2;
                    string Why = excelRange.Cells[i, j++].Value2.ToString();
                    string SRNOTES = excelRange.Cells[i, j++].Value2;
                    string FUTURE = excelRange.Cells[i, j++].Value2;

                    obj.customers.Add(new Customer(state, districtpid, districtName, schoolpid, SchoolName, EdEnabled, CreatedDate, LastLoggedIn, schoolYear_startdate, schoolYear_enddate, SchoolYearActive, ela_subscription, math_subscription, sub_startdate, sub_enddate, sub_active, DistrictId, SchoolId, ssoProvider, IsArchived, Rollover2021, Why, SRNOTES, FUTURE));

                }
            }
            List<Customer> customers2 = obj.customers.GroupBy(x => x.SchoolName).Select(y => y.First()).ToList();

            obj.ToDb(customers2);
        }
    }
    class Customer
    {
        public string state { get; set; }
        public double districtpid { get; set; }
        public string districtName { get; set; }
        public string schoolpid { get; set; }
        public string SchoolName { get; set; }
        public string EdEnabled { get; set; }
        public string CreatedDate { get; set; }
        public string LastLoggedIn { get; set; }
        public string schoolYear_startdate { get; set; }
        public string schoolYear_enddate { get; set; }
        public string SchoolYearActive { get; set; }
        public string ela_subscription { get; set; }
        public string math_subscription { get; set; }
        public string sub_startdate { get; set; }
        public string sub_enddate { get; set; }
        public string sub_active { get; set; }
        public string DistrictId { get; set; }
        public string SchoolId { get; set; }
        public string ssoProvider { get; set; }
        public double IsArchived { get; set; }
        public string Rollover2021 { get; set; }
        public string Why { get; set; }
        public string SRNOTES { get; set; }
        public string FUTURE { get; set; }

        public Customer(string state, double districtpid, string districtName, string schoolpid, string SchoolName, string EdEnabled, string CreatedDate, string LastLoggedIn, string schoolYear_startdate, string schoolYear_enddate, string SchoolYearActive, string ela_subscription, string math_subscription, string sub_startdate, string sub_enddate, string sub_active, string DistrictId, string SchoolId, string ssoProvider, double IsArchived, string Rollover2021, string Why, string SRNOTES, string FUTURE)
        {
            this.state = state;
            this.districtpid = districtpid;
            this.districtName = districtName;
            this.schoolpid = schoolpid;
            this.SchoolName = SchoolName;
            this.EdEnabled = EdEnabled;
            this.CreatedDate = CreatedDate;
            this.LastLoggedIn = LastLoggedIn;
            this.schoolYear_startdate = schoolYear_startdate;
            this.schoolYear_enddate = schoolYear_enddate;
            this.SchoolYearActive = SchoolYearActive;
            this.ela_subscription = ela_subscription;
            this.math_subscription = math_subscription;
            this.sub_startdate = sub_startdate;
            this.sub_enddate = sub_enddate;
            this.sub_active = sub_active;
            this.DistrictId = DistrictId;
            this.SchoolId = SchoolId;
            this.ssoProvider = ssoProvider;
            this.IsArchived = IsArchived;
            this.Rollover2021 = Rollover2021;
            this.Why = Why;
            this.SRNOTES = SRNOTES;
            this.FUTURE = FUTURE;
        }

    }
    class ListOfCustomers
    {
        public List<Customer> customers = new List<Customer>();

        //public List<Customer> customers2 = new List<Customer>();
        public void ToDb(List<Customer> customers2)
        {

            SqlConnection sqlconnection;

            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=True";

            sqlconnection = new SqlConnection(connectionstring);

            sqlconnection.Open();

            foreach (Customer c in customers2)
            {
                string insertquery = "INSERT INTO School(state,districtpid,districtName,	schoolpid,	SchoolName,	EdEnabled,	CreatedDate,	LastLoggedIn,	schoolYear_startdate,	schoolYear_enddate,	SchoolYearActive,	ela_subscription,	math_subscription,	sub_startdate,	sub_enddate,	sub_active,	DistrictId,	SchoolId,	ssoProvider,	IsArchived,	Rollover2021,	Why,	SRNOTES,	FUTURE) " +
                                     "VALUES ('" + c.state + "','" + c.districtpid + "','" + c.districtName + "','" + c.schoolpid + "','" + c.SchoolName + "','" + c.EdEnabled + "','" + c.CreatedDate + "','" + c.LastLoggedIn + "','" + c.schoolYear_startdate + "','" + c.schoolYear_enddate + "','" + c.SchoolYearActive + "','" + c.ela_subscription + "','" + c.math_subscription + "','" + c.sub_startdate + "','" + c.sub_enddate + "','" + c.sub_active + "','" + c.DistrictId + "','" + c.SchoolId + "','" + c.ssoProvider + "','" + c.IsArchived + "','" + c.Rollover2021 + "','" + c.Why + "','" + c.SRNOTES + "','" + c.FUTURE + "')";

                SqlCommand insertCommand = new SqlCommand(insertquery, sqlconnection);

                insertCommand.ExecuteNonQuery();
            }
            Console.WriteLine("Updated to DB Successfully");
        }
    }
}

