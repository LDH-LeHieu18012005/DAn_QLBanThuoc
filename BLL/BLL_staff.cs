using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_staff
    {
        public BLL_staff() { }
        public DataTable GetData(string keyword)
        {
            return SqlDataAccess.GetDataFromTable($"Staff where name_staff like N'%{keyword}%' OR address like N'%{keyword}%' OR phone like '{keyword}' OR username like '{keyword}' OR gender like N'{keyword}'");
        }
        public void AddRecord(string name, string gender, string address, string gmail, string phone, DateTime startDate, string username, string password, string typeStaff, string isActive)
        {
            string formattedDate = startDate.ToString("yyyy-MM-dd");
            string command = $"exec Proc_AddStaff N'{name}', N'{gender}', N'{address}', '{gmail}', '{phone}', '{formattedDate}', '{username}', '{password}', N'{typeStaff}', '{isActive}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void UpdateRecord(string id, string name, string gender, string address, string gmail, string phone, DateTime startDate, string username, string password, string typeStaff, string isActive)
        {
            string formattedDate = startDate.ToString("yyyy-MM-dd");
            string command = $"exec Proc_UpdateStaff '{id}', N'{name}', N'{gender}', N'{address}', '{gmail}', '{phone}', '{formattedDate}', '{username}', '{password}', N'{typeStaff}', '{isActive}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void DeleteRecord(string id)
        {
            string command = $"exec Proc_DeleteStaff '{id}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public DataRow GetRecord(string id)
        {
            return SqlDataAccess.GetDataFromTable($"Staff where id_staff = '{id}'").Rows[0];
        }
    }
}
