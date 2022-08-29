using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;


namespace SheetToDB
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

            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\KoduvayurAghoraAravi\source\VS\ExcelTask\SheetToDB\Tasks - Copy.xlsx");

            _Worksheet excelSheet = excelBook.Sheets[1];

            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;

            int cols = excelRange.Columns.Count;

            for (int i = 2; i <= rows; i++)
            {
                int j = 1;

                while (j <= cols)
                {
                    string courseid = excelRange.Cells[i, j++].Value2.ToString();

                    string title = excelRange.Cells[i, j++].Value2.ToString();

                    string credits = excelRange.Cells[i, j++].Value2.ToString();

                    string deptid = excelRange.Cells[i, j++].Value2.ToString();

                    string insertquery = "INSERT INTO Course (CourseID,Title,Credits,DepartmentID) VALUES ('" + courseid + "','" + title + "','" + credits + "','" + deptid + "')";

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
