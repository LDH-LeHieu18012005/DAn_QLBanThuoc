using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_supplier
    {
        public BLL_supplier() { }

        public void AddRecord(string name, string phone, string gmail, string address)
        {
            string command = $"exec Proc_AddSupplier N'{name}', '{phone}', '{gmail}', N'{address}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void UpdateRecord(string id, string name, string phone, string gmail, string address)
        {
            string command = $"exec Proc_UpdateSupplier '{id}', N'{name}', '{phone}', '{gmail}', N'{address}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }
        public void DeleteRecord(string id)
        {
            string command = $"exec Proc_DeleteSupplier '{id}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }
        public DataTable GetData(string keyword)
        {
            return SqlDataAccess.GetDataFromTable($"Supplier where name_supplier like N'%{keyword}%' OR address like N'%{keyword}%' OR phone like '{keyword}'");
        }
        public DataRow GetRecord(string ID)
        {
            return SqlDataAccess.GetDataFromTable($"Supplier where id_supplier = '{ID}'").Rows[0];
        }
    }
}
