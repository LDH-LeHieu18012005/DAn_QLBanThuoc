using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_type
    {
        public BLL_type() { }
        public DataTable GetData(string keyword)
        {
            return SqlDataAccess.GetDataFromTable($"Medicine_Type where name_type like N'%{keyword}%' OR description like N'%{keyword}%'");
        }
        public void AddRecord(string nameType, string description)
        {
            string command = $"exec Proc_AddMedicineType N'{nameType}', N'{description}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void UpdateRecord(string id, string nameType, string description)
        {
            string command = $"exec Proc_UpdateMedicineType '{id}', N'{nameType}', N'{description}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void DeleteRecord(string id)
        {
            string command = $"exec Proc_DeleteType '{id}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public DataRow GetRecord(string id)
        {
            return SqlDataAccess.GetDataFromTable($"Medicine_Type where id_type = '{id}'").Rows[0];
        }

        public bool TypeNameExists(string nameType)
        {
            string cleanedName = nameType.Trim();
            DataTable dt = SqlDataAccess.GetDataFromTable($"SELECT 1 FROM Medicine_Type WHERE name_type = N'{cleanedName}'");
            return dt.Rows.Count > 0;
        }
    }
}
