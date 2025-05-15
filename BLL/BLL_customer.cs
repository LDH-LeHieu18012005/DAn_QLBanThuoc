using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_customer
    {
        public BLL_customer() { }
        public DataTable GetData(string keyword)
        {
            return SqlDataAccess.GetDataFromTable($"Customer where name_customer like N'%{keyword}%' OR address like N'%{keyword}%' OR phone like '{keyword}'");
        }
        public DataRow GetRecord(string ID)
        {
            return SqlDataAccess.GetDataFromTable($"Customer where id_customer = '{ID}'").Rows[0];
        }
        public void AddRecord(string name, string age, string gender, string phone, string address)
        {
            string command = $"exec Proc_AddCustomer N'{name}', '{age}', N'{gender}', '{phone}', N'{address}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void UpdateRecord(string id, string name, string age, string gender, string phone, string address)
        {
            string command = $"exec Proc_UpdateCustomer '{id}', N'{name}', '{age}', N'{gender}', '{phone}', N'{address}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }
        public void DeleteRecord(string id)
        {
            SqlDataAccess.ExecuteNonQuery($"Exec Proc_rmCustomer '{id}'"); 
        }
    }
}
