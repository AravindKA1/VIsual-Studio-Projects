using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ExcelTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlconnection;

            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=True";

            sqlconnection = new SqlConnection(connectionstring);

            sqlconnection.Open();

            Application excelApp = new Application();

            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\KoduvayurAghoraAravi\source\VS\ExcelTask\ExcelTasks\Schools_BTS2021_dump-SR-ExceptionList.xlsx");

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
                    string districtpid = excelRange.Cells[i, j++].Value2.ToString();
                    string districtName = excelRange.Cells[i, j++].Value2.ToString();
                    string schoolpid = excelRange.Cells[i, j++].Value2.ToString();
                    string SchoolName = excelRange.Cells[i, j++].Value2.ToString();
                    string EdEnabled = excelRange.Cells[i, j++].Value2.ToString();
                    string CreatedDate = excelRange.Cells[i, j++].Value2.ToString();
                    string LastLoggedIn = excelRange.Cells[i, j++].Value2.ToString();
                    string schoolYear_startdate = excelRange.Cells[i, j++].Value2.ToString();
                    string schoolYear_enddate= excelRange.Cells[i, j++].Value2.ToString();
                    string SchoolYearActive = excelRange.Cells[i, j++].Value2.ToString();
                    string ela_subscription = excelRange.Cells[i, j++].Value2.ToString();
                    string math_subscription = excelRange.Cells[i, j++].Value2.ToString();
                    string sub_startdate = excelRange.Cells[i, j++].Value2.ToString();
                    string sub_enddate = excelRange.Cells[i, j++].Value2.ToString();
                    string sub_active = excelRange.Cells[i, j++].Value2.ToString();
                    string DistrictId = excelRange.Cells[i, j++].Value2.ToString();
                    string SchoolId = excelRange.Cells[i, j++].Value2.ToString();
                    string ssoProvider = excelRange.Cells[i, j++].Value2.ToString();
                    string IsArchived = excelRange.Cells[i, j++].Value2.ToString();
                    string Rollover2021 = excelRange.Cells[i, j++].Value2.ToString();
                    string Why = excelRange.Cells[i, j++].Value2.ToString();
                    string SRNOTES = excelRange.Cells[i, j++].Value2;
                    string FUTURE = excelRange.Cells[i, j++].Value2;

                    string insertquery = "INSERT INTO School (state,districtpid,districtName,schoolpid,SchoolName,EdEnabled,CreatedDate,LastLoggedIn,schoolYear_startdate,schoolYear_enddate,SchoolYearActive,ela_subscription,math_subscription,sub_startdate,sub_enddate,sub_active,DistrictId,SchoolId,ssoProvider,IsArchived,Rollover2021,Why,SRNOTES,FUTURE)"+" VALUES ('" + state + "','" + districtpid + "','" + districtName + "',	'" + schoolpid + "','" + SchoolName + "','" + EdEnabled + "','" + CreatedDate + "','" + LastLoggedIn + "','" + schoolYear_startdate + "','" + schoolYear_enddate + "','" + SchoolYearActive + "','" + ela_subscription + "','" + math_subscription + "','" + sub_startdate + "','" + sub_enddate + "','" + sub_active + "','" + DistrictId + "','" + SchoolId + "','" + ssoProvider + "','" + IsArchived + "','" + Rollover2021 + "','" + Why + "','" + SRNOTES + "','" + FUTURE + "')";

                    SqlCommand insertCommand = new SqlCommand(insertquery, sqlconnection);

                    insertCommand.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Updated Successfully");
            excelApp.Quit();
            Console.ReadLine();
        }
    }
}


